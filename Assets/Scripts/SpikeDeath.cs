using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDeath : MonoBehaviour {

    [HideInInspector]
    

	private void OnTriggerEnter2D(Collider2D collision)
	{
        GameObject.Find("Lava").GetComponent<RespawnPlayer>().RespawnaPlayer(collision.transform, false);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}
 }
