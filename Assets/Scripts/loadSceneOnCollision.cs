using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadSceneOnCollision : MonoBehaviour {

    public GameObject gameManager;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().ChangeToGame();
        }
    }
}
