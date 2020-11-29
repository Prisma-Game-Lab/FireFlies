using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSkipper : MonoBehaviour {

	public GameObject BackToMenu;
	private int count = 0;

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			count++;
			if(count > 1) BackToMenu.SetActive(true);
		}
	}
}
