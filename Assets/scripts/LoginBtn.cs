using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginBtn : MonoBehaviour {
    public Button loginBtn;
    public GameController gameController;
    public Text uName;
    public Text rId;
	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();
        loginBtn.onClick.AddListener(LoginClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void LoginClick()
    {
        gameController.userName = uName.text;
        gameController.roomId = rId.text;
        gameController.SendHey();
        gameController.SendRoom();
    }
}
