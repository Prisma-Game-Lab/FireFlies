using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    // Segue o player verticalmente 
    // Pos player + um espaço

    private Vector3 centerCam;
    private GameObject player;

	private void OnEnable()
	{
        centerCam = this.transform.position;
        player = GameObject.Find("Player");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(player.transform.position.y > centerCam.y){
            updateCenterCam(player.transform.position.y);
        }
		
	}

    public void updateCenterCam(float YPos){

        this.transform.position = new Vector3(this.transform.position.x, YPos, this.transform.position.z);
        
    }
}
