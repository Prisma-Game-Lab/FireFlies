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

	private void OnEnable()
	{
        rb = this.GetComponent<Rigidbody2D>();
	}

	// Faz o pulo do jogador
	public void CreateImpulse(Vector3 mousePosition){

        Vector3 impulse = new Vector3(mousePosition.x * -1, mousePosition.y * -1, 0) * ImpulseForce;

        if (MaxImpulseForceHorizontal != 0 && (impulse.x > MaxImpulseForceHorizontal)){
            Debug.Log("Limite Horizontal Maximo");
            impulse = new Vector3(-1, mousePosition.y * -1, 0) * MaxImpulseForceHorizontal;
        }

        if (MaxImpulseForceVertical != 0 && (impulse.y > MaxImpulseForceVertical)) {
            Debug.Log("Limite Vertical Maximo");
            impulse = new Vector3(impulse.x, -1, 0) * MaxImpulseForceHorizontal;
        }

        rb.AddForce(impulse);
    }
}
