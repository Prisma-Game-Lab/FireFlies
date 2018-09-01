using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    private ClickImpulse clickImpulsePlayerComponent;
    private LineRenderer lineBack;
    private LineRenderer lineFront;

    private Vector3 currentMousePosition = Vector3.zero;

	private void OnEnable()
	{
        lineBack = this.GetComponent<LineRenderer>();
        lineFront = this.gameObject.AddComponent<LineRenderer>();
        clickImpulsePlayerComponent = this.GetComponent<ClickImpulse>();
        lineSetup();
	}

    private void lineSetup(){

        // back line
        lineBack.material = new Material(Shader.Find("Particles/Additive"));
        lineBack.widthMultiplier = 0.2f;
        lineBack.positionCount = 2;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.cyan, 0.0f), new GradientColorKey(Color.green, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineBack.colorGradient = gradient;

        // line front
        lineFront.material = new Material(Shader.Find("Particles/Additive"));
        lineFront.widthMultiplier = 0.2f;
        lineFront.positionCount = 2;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha2 = 1.0f;
        Gradient gradient2 = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.cyan, 0.0f), new GradientColorKey(Color.green, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha2, 0.0f), new GradientAlphaKey(alpha2, 1.0f) }
            );
        lineFront.colorGradient = gradient2;
    } 

    // Clicou
	private void OnMouseDown()
	{

    }

    // Está clicando
    private void OnMouseDrag()
    {
        Debug.Log(Input.mousePosition);
        currentMousePosition = Input.mousePosition;
        lineBack.SetPosition(0, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineBack.SetPosition(1, this.transform.position);
        lineFront.SetPosition(0, Camera.main.ScreenToWorldPoint(Input.mousePosition) * -1);
        lineFront.SetPosition(1, this.transform.position);
        //line.SetPosition(1, Input.mousePosition);

       /* line.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        line.transform.position = new Vector3(GameObject.Find("Line").transform.position.x, GameObject.Find("Line").transform.position.y, 0);

        end_x = GameObject.Find("Line").transform.position.x;
        end_y = GameObject.Find("Line").transform.position.y;

        //arrow.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //arrow.transform.position = new Vector3(GameObject.Find("Line").transform.position.x, GameObject.Find("Line").transform.position.y, 0);
        //arrow.transform.rotation = GameObject.Find("Line").transform.rotation;


        if (GetComponent<LineRenderer>() != null)
        {
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetVertexCount(2);
            GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, transform.position.y, 1));
            GetComponent<LineRenderer>().SetPosition(1, new Vector3(GameObject.Find("Line").transform.position.x, GameObject.Find("Line").transform.position.y, 1));
            GetComponent<LineRenderer>().SetWidth(0f, 1f);
            GetComponent<LineRenderer>().sortingLayerName = ("myLayer");
            GetComponent<LineRenderer>().sortingOrder = 10;
        }

        line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));*/
    }

    // Soltou o clique
	private void OnMouseUp()
	{
        clickImpulsePlayerComponent.CreateImpulse(currentMousePosition);
        currentMousePosition = Vector3.zero;
	}

}
