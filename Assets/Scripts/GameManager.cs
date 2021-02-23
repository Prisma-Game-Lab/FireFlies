using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject PausePanel;
    public TimeManager time;
    public Animator transitionAnim;

    public void ChangeToGame(){
        SceneManager.LoadScene("Volcano");
        //StartCoroutine(TransitionToGame(0.5f));
    }

    public void BackToMenu(){
        SceneManager.LoadScene("MenuScene");
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

    public void SceneLoader (string s){

    }

    public IEnumerator TransitionToGame (float t){
        SceneTransition("fadeIn");
        yield return new WaitForSeconds(t);
    }

    public void SceneTransition(string state){
        transitionAnim.SetTrigger(state);
    }

}
