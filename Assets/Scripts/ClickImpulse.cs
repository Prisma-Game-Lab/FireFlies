using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickImpulse : MonoBehaviour {

    [Tooltip("forca que é aplicada a qualquer vetor de pulo")]
    public float ImpulseForce = 1.0f;
  
    private Rigidbody2D rb;
    private Vector3 currentImpulse = Vector3.zero;

	private void OnEnable()
	{
        rb = this.GetComponent<Rigidbody2D>();
	}

	// Faz o pulo do jogador
    public void CreateImpulse(Vector3 mousePosition){
        currentImpulse = new Vector3(mousePosition.x, mousePosition.y, 0) * ImpulseForce;
    }

    public void Jump(bool perfect){
        
        if (perfect)
        {
            rb.AddForce(currentImpulse * 1.2f);
        }
        else
        {
            rb.AddForce(currentImpulse);
        }
    }
}
