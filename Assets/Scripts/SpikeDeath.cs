using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDeath : MonoBehaviour {

    [HideInInspector]
    

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
            GameObject.Find("Lava").GetComponent<RespawnPlayer>().RespawnaPlayer(collision.transform);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}
 }
