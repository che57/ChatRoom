using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendBtn : MonoBehaviour {
    public Button sendBtn;
    public GameController gameController;
    public RoomController roomController;
    public Text input;
	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();
        roomController = FindObjectOfType<RoomController>();
        sendBtn.onClick.AddListener(ClickSend);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("enter"))
        {
            Debug.Log("0: " + input.text);

            ClickSend();
        }
    }
    void ClickSend()
    {
        roomController.SendDiaLog(input.text);
    }
}
