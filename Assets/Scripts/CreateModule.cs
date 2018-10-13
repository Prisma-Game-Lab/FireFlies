using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateModule : MonoBehaviour {

    public Difficulty Difficulty;

    private Module thisModule;

	// Use this for initialization
	void Start () {

		//thisModule = new Module((int) this.GetComponent<BoxCollider2D>().size.y, Difficulty, this.gameObject);
	}

    public Module CreateNewModule(int index, float posPrevious)
    {
        Debug.Log(this.GetComponent<BoxCollider2D>().size.y + " SIZE DO BICHO");
        Debug.Log(posPrevious + " POSPREV DO BICHO");
        thisModule = new Module(this.GetComponent<BoxCollider2D>().size.y, posPrevious, Difficulty, this.gameObject, true, index);
        return thisModule;
    }

}
