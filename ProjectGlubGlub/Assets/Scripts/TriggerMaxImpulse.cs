using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMaxImpulse : MonoBehaviour {

    private CircleCollider2D circle; 

	private void OnEnable()
	{
        circle = this.gameObject.GetComponent<CircleCollider2D>();
        Camera.main.GetComponent<Controls>().MaxImpulseRadius = circle.radius;
	}
}
