using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviour {
    public string[] dialog = new string[15];
    public int index;
    public TCPReceiver tCPReceiver;
    public TCPSender tCPSender;
    public GameController gameController;
    public Text dialogDisplay;
	// Use this for initialization
	void Start () {
        index = 0;
        gameController = FindObjectOfType<GameController>();
        tCPReceiver = gameController.tCPReceiver;
        tCPSender = gameController.tCPSender;
        //SendClientId();
    }

    // Update is called once per frame
    void Update () {
        if (gameController.flag)
        {
            gameController.flag = false;
            AddDialog(gameController.temp);
        }
        //AddDialog("6");
    }
    public void AddDialog(string msg)
    {
        dialogDisplay.text = "";
        if (index <= 14)
        {
            dialog[index] = msg;
            index++;
        }
        else
        {
            for (int i = 0; i < 14; i++)
            {
                dialog[i] = dialog[i + 1];
            }
            dialog[14] = msg;
        }
        foreach(var a in dialog)
        {
            dialogDisplay.text += a;
        }
    }
    public void SendDiaLog(string input)
    {
        tCPSender.SendMsg("dialog|" + input);
    }
    public void SendClientId()
    {
        tCPReceiver.SendMsg("thread|0" + gameController.clientId);
    }
    public void SendDone()
    {
        tCPSender.SendMsg("done");
    }
}
