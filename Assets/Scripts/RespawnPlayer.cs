using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {

    [HideInInspector]
    public Vector3 RespawnPosition;
    public float lavaRespawn = 50;

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.tag == "Player"){
            collision.transform.position = RespawnPosition;
            GameObject player = GameObject.Find("Player");
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            playerRb.velocity = Vector2.zero;
            Debug.Log(player.transform.position.y);
            Vector3 realLavaPos = Camera.main.ScreenToWorldPoint(this.transform.position);
            Vector3 realRespawnPos = Camera.main.ScreenToWorldPoint(RespawnPosition);
            Debug.Log(realRespawnPos);
            this.transform.position = new Vector3(realLavaPos.x, realRespawnPos.y - lavaRespawn, realLavaPos.x);
        }
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}
}
