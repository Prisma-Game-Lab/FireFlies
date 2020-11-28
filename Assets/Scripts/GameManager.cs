using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject PausePanel;
    public TimeManager time;

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
        SceneManager.LoadScene("StartScene");
    }

    public void Victory()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Pause() {

        time.pauseTime();
        PausePanel.SetActive(true);

    }

    public void UnPause() {

        PausePanel.SetActive(false);
        time.normalTime();

    }

}
