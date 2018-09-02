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

        yield return new WaitForSeconds(initialDelay);
        isNotRespawn = true;
        StartCoroutine(riseLava());
    }

    IEnumerator riseLava(){

        while(isNotRespawn){
            yield return new WaitForSeconds(secondsforRise);
            this.transform.position += new Vector3(0,risePercent,0);
        }
    }
}
