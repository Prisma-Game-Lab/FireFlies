using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeToGame(){
        SceneManager.LoadScene("Volcano");
    }

    public void BackToMenu(){
        SceneManager.LoadScene("MenuScene");
    }

    public void Victory()
    {
        SceneManager.LoadScene("Credits");
    }
}
