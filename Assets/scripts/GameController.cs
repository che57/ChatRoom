using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public string userName;
    public string clientId;
    public string roomId;
    public TCPSender tCPSender;
    public TCPReceiver tCPReceiver;
    public bool flag = false;
    public string temp;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        tCPSender = GetComponent<TCPSender>();
        tCPReceiver = GetComponent<TCPReceiver>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SendHey()
    {
        tCPSender.SendMsg("hey|" + userName);
    }
    public void SendRoom()
    {
        tCPSender.SendMsg("room|" + roomId);
    }
    public void SendClientId()
    {
        tCPReceiver.SendMsg("thread|" + clientId);
    }
}
