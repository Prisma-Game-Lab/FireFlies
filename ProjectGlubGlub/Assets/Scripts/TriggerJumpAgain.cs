using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJumpAgain : MonoBehaviour {

    private Controls ctrl;

	private void OnEnable()
	{
        ctrl = GameObject.Find("Main Camera").GetComponent<Controls>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        ctrl.isAbleToJump = true;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        ctrl.isAbleToJump = true;
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        ctrl.isAbleToJump = false;
	}

}
