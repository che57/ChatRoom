using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBtn : MonoBehaviour {
    public Button goBtn;
    public GameController gameController;
	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();
        goBtn.onClick.AddListener(GoClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void GoClick()
    {
        gameController.SendClientId();
        SceneManager.LoadScene("Chatting Room");
    }
}
