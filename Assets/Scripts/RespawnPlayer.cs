using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {

    [HideInInspector]
    public Vector3 RespawnPosition;
    public float lavaRespawn = 50;

	private void OnTriggerEnter2D(Collider2D collision)
	{

        RespawnaPlayer(collision.gameObject.transform,true);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}

    public void RespawnaPlayer(Transform go, bool isLava){

        if(go.tag == "Player"){
            go.transform.position = RespawnPosition;
            GameObject player = GameObject.Find("Player");
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            playerRb.velocity = Vector2.zero;

            if(isLava){
                this.GetComponent<LavaRising>().isNotRespawn = false;
                Vector3 realLavaPos = Camera.main.ScreenToWorldPoint(this.transform.position);
                Vector3 realRespawnPos = Camera.main.ScreenToWorldPoint(RespawnPosition);
                this.transform.position = new Vector3(this.transform.position.x, realRespawnPos.y - lavaRespawn, 0);
                this.GetComponent<LavaRising>().StartLavaRising();
            } 
        }
    }
}
