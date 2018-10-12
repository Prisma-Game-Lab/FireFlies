using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty { easy, medium, hard };

public class Module {

	// Tamanho do módulo
	public int Size;
    public int PosMin;
    public Difficulty Difficulty;
    public GameObject ModuleObject;
    public bool isEnabledInGame = false;
    public int ListIndex = 0;

	// Iniacializa o módulo
	public Module (int moduleYSize, int posPrevious, Difficulty difficulty, GameObject moduleObject, bool enabled, int index){

		this.Size = moduleYSize;
        this.PosMin = posPrevious;
        this.Difficulty = difficulty;
        this.ModuleObject = moduleObject;
        this.isEnabledInGame = enabled;
        this.ListIndex = index;
    }

}
