using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscBtn : MonoBehaviour {
    public Button disBtn;
    public RoomController roomController;

	// Use this for initialization
	void Start () {
        roomController = FindObjectOfType<RoomController>();
        disBtn.onClick.AddListener(ClickDone);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ClickDone()
    {
        roomController.SendDone();
        Application.Quit();
    }
}
