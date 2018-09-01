using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {

    public Vector3 RespawnPosition;

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.tag == "Player"){
            collision.transform.position = RespawnPosition;
            Rigidbody2D playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            playerRb.velocity = Vector2.zero;
        }
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}
}
