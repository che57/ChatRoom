using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TCPSender : MonoBehaviour
{
    //public Button goButton;
    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    private GameController gameController;
    private RoomController roomController;
    private int port = 9631;
    private string ip = "35.162.177.130";
    // Use this for initialization 
    void Start()
    {
        ConnectToTcpServer();
        gameController = FindObjectOfType<GameController>();
        roomController = FindObjectOfType<RoomController>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void ConnectToTcpServer()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }
    }

    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient(ip, port);
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                // Get a stream object for reading 				
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    // Read incomming stream into byte arrary. 					
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        // Convert byte array to string message. 						
                        string serverMessage = Encoding.ASCII.GetString(incommingData);
                        Debug.Log("sender message received as: " + serverMessage);
                        //serverMessage = "welcome|0123|3|100|101|102";
                        string[] msgSemgents = serverMessage.Split('|');
                        handleMsg(msgSemgents, serverMessage);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    public void SendMsg(string msg)
    {
        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                string clientMessage = msg;
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Sender: " + msg);
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }
    public void handleMsg(string[] segs, string msg)
    {
        switch (segs[0])
        {
            case "welcome":
                gameController.clientId = segs[1];
                //roomController.flag = true;
                break;
            default:
                Debug.Log("Sender's wrong");
                break;
        }
    }
}
