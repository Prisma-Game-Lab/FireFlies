using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public GameObject Arrow;

    private GameObject player;
    private ClickImpulse clickImpulsePlayerComponent;
    private LineRenderer line;

    private Vector3 currentMousePosition = Vector3.zero;
    private Vector3 initialMousePosition = Vector3.zero;

    [HideInInspector]
    public bool isAbleToJump = true;

	private void Update()
	{
        if(Input.GetMouseButtonDown(0)){
            OnMouseDown();
        }
        
        if(Input.GetMouseButton(0)){
            OnMouseDrag();
        } 

        if (Input.GetMouseButtonUp(0)){
            OnMouseUp();
        }
	}

	private void OnEnable()
	{
        player = GameObject.Find("Player");
        line = player.GetComponent<LineRenderer>();
        clickImpulsePlayerComponent = player.GetComponent<ClickImpulse>();
        lineSetup();
	}

    private void lineSetup(){

        // line
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.widthMultiplier = 0.2f;
        line.positionCount = 2;

    } 

    // Clicou
	private void OnMouseDown()
	{
        initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
    }

    // Está clicando
    private void OnMouseDrag()
    {
        if (isAbleToJump)
        {
            line.enabled = true;
            currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
            //Debug.Log(initialMousePosition - currentMousePosition);
            line.SetPosition(0, player.transform.position + (initialMousePosition - currentMousePosition));
            line.SetPosition(1, player.transform.position + (initialMousePosition - currentMousePosition) * -1);
            Arrow.SetActive(true);
            Arrow.transform.position = line.GetPosition(0);
        }
    }

    // Soltou o clique
	private void OnMouseUp()
	{
        line.enabled = false;
        clickImpulsePlayerComponent.CreateImpulse(initialMousePosition - currentMousePosition);
        currentMousePosition = Vector3.zero;
        initialMousePosition = Vector3.zero;
        isAbleToJump = false;
        Arrow.SetActive(false);
	}

}
