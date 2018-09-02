using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTransition : MonoBehaviour {

    //public GameManager gm; 

    public GameObject vict;

	private void OnTriggerEnter2D(Collider2D collision)
	{
        vict.gameObject.SetActive(true); 
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}

}
