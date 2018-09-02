using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour {

    public float initialDelay = 1.0f;
    public float risePercent = 0.1f;
    public float secondsforRise = 1.0f;

    [HideInInspector]
    public bool isNotRespawn = true;

	// Use this for initialization
	void Start () {
        StartLavaRising();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartLavaRising(){
        StartCoroutine(waitStart());
    }

    IEnumerator waitStart(){

        isNotRespawn = true;
        yield return new WaitForSeconds(initialDelay);

        StartCoroutine(riseLava());
    }

    IEnumerator riseLava(){

        while(isNotRespawn){
            Debug.Log("this is it");
            yield return new WaitForSeconds(secondsforRise);
            this.transform.position += new Vector3(0,risePercent,0);
        }
    }
}
