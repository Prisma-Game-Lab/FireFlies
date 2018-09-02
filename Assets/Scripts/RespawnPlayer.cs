using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {

    [HideInInspector]
    public Vector3 RespawnPosition;
    public float lavaRespawn = 50;

	private void OnEnable()
	{
        RespawnPosition = GameObject.Find("Player").transform.position;
	}

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
            GameObject.Find("Camera").GetComponent<FollowPlayer>().updateCenterCam(RespawnPosition.y + 5);

            if (isLava){
                this.GetComponent<LavaRising>().isNotRespawn = false;
                this.transform.position = new Vector3(this.transform.position.x, RespawnPosition.y - lavaRespawn, 0);
                this.GetComponent<LavaRising>().StartLavaRising();
            } else {
                GameObject.Find("Lava").GetComponent<LavaRising>().isNotRespawn = false;
                GameObject.Find("Lava").transform.position = new Vector3(this.transform.position.x, RespawnPosition.y - lavaRespawn, 0);
                GameObject.Find("Lava").GetComponent<LavaRising>().StartLavaRising();
            }
        }
    }
}
