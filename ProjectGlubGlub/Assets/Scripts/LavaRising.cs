using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour {

    public float risePercent = 0.1f;
    public float secondsforRise = 1.0f; 

	// Use this for initialization
	void Start () {
        StartCoroutine(riseLava());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator riseLava(){

        while(true){
            yield return new WaitForSeconds(secondsforRise);
            this.transform.position += new Vector3(0,risePercent,0);
        }
    }
}
