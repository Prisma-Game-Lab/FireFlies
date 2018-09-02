using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour {

    [HideInInspector]
    private RespawnPlayer respawnPlayerComponent;
    private GameObject lava;

    public AudioClip collectSound;
    private AudioSource source;

	private void OnEnable()
	{
        lava = GameObject.Find("Lava");
        respawnPlayerComponent = lava.GetComponent<RespawnPlayer>();
        source = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.tag == "Player"){
            respawnPlayerComponent.RespawnPosition = this.transform.position;
            this.gameObject.SetActive(false);
			source.PlayOneShot(collectSound);
        }
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}
}
