using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickImpulse : MonoBehaviour {

    [Tooltip("forca que é aplicada a qualquer vetor de pulo")]
    public float ImpulseForce = 1.0f;
    [Tooltip("se 0 ele não possui um limite de pulo")]
    public float MaxImpulseForceVertical = 0;
    [Tooltip("se 0 ele não possui um limite de pulo")]
    public float MaxImpulseForceHorizontal = 0;

    private Rigidbody2D rb;
    private Vector3 currentImpulse = Vector3.zero;

	private void Update()
	{
		
	}

	private void OnEnable()
	{
        rb = this.GetComponent<Rigidbody2D>();
	}

	// Faz o pulo do jogador
    public bool CreateImpulse(Vector3 mousePosition){
        bool verticalFlag = false, horizontalFlag = false;
        currentImpulse = new Vector3(mousePosition.x, mousePosition.y, 0) * ImpulseForce;

        if (MaxImpulseForceHorizontal != 0 && (currentImpulse.x > MaxImpulseForceHorizontal)){
            currentImpulse = new Vector3(0, currentImpulse.y, 0) + Vector3.right * MaxImpulseForceHorizontal;
            horizontalFlag = true;
        }

        if (MaxImpulseForceVertical != 0 && (currentImpulse.y > MaxImpulseForceVertical)){
            currentImpulse = new Vector3(currentImpulse.x, 0, 0) + Vector3.up * MaxImpulseForceVertical;
            verticalFlag = true;
        }

        if (verticalFlag || horizontalFlag)
            return true;

        return false;
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
