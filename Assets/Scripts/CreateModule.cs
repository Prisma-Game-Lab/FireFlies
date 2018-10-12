using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateModule : MonoBehaviour {

    public Difficulty Difficulty;

    private Module thisModule;

	// Use this for initialization
	void Start () {

		Module Modulescript = GameObject.Find("MainScripts").GetComponent<Module>();

		thisModule = new Module((int) this.GetComponent<BoxCollider2D>().size.y, Difficulty, this.gameObject);
	}

    public Module GetModule()
    {
        return thisModule;
    }

}
