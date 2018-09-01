using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJumpAgain : MonoBehaviour {

    private Controls ctrl;

	private void OnEnable()
	{
        ctrl = this.GetComponent<Controls>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}

}
