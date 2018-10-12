using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty { easy, medium, hard };

public class Module {

	// Tamanho do módulo
	int Size;
    Difficulty Difficulty;
    GameObject ModuleObject;
    bool isEnabledInGame = false;
    int ListIndex = 0;

	// Iniacializa o módulo
	public Module (int moduleYSize, Difficulty difficulty, GameObject moduleObject){

		this.Size = moduleYSize;
        this.Difficulty = difficulty;
        this.ModuleObject = moduleObject;
	}

}
