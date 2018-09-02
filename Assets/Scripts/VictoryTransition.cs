using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTransition : MonoBehaviour {

    public GameManager gm;

	private void OnTriggerEnter2D(Collider2D collision)
	{
        gm.Victory();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}

}
