using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJumpAgain : MonoBehaviour {

    private Controls ctrl;



	private void OnEnable()
	{
        ctrl = GameObject.Find("Main Camera").GetComponent<Controls>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log("Faz coisas perfeitamente");
        ctrl.isPerfectJump = true;
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
        
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
        ctrl.isPerfectJump = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log(this.name);
        if (collision.gameObject.layer == 8){
            ctrl.isAbleToJump = true;
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
      
	}

}
