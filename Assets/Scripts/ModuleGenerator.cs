using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleGenerator : MonoBehaviour {

    public GameObject[] EasyModules;
    public GameObject[] MediumModules;
    public GameObject[] HardModules;

    private float initialPositionX = 3.88f;
    private float initialPositionY;

    private float MaxPositionWithLastModule;

    private List<Module> gameModules;
    private int currentIndex = 0;

    private Module currentModule;

    private GameObject player;
    private GameObject modulesGameObjects;

    /* 
	   2 - jogo começa com 3 módulos formados
	   3 - todos os módulos do jogo estarão presentes em uma lista que vai aumentando o tamanho conforme o jogo progride
	   4 - info de cada módulo: tamanho, dificuldade, gameObject com tudo, estado ativado ou desligado, index na lista de módulos. - uma classe
	   5 - uma variavel chamada current Module com o modulo atual. se esse módulo for o ultimo da lista, adiciona mais 3 modulos na lista
	   6 - se chegou no save, todos os módulos anteriores a lista são deletados
 	*/

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").gameObject;
        modulesGameObjects = GameObject.Find("Modules").gameObject;

        initialPositionY = player.transform.position.y;

        MaxPositionWithLastModule = initialPositionY;
        AddModuleInList(Difficulty.easy);
        currentIndex = 0;
        currentModule = gameModules[currentIndex];

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        foreach (Module module in gameModules)
        {
            // verificar se o player tá dentro desse modulo, se esse modulo for o ultimo módulo, gera um novo módulo
            if (player.transform.position.y >= MaxPositionWithLastModule && player.transform.position.y <= MaxPositionWithLastModule + module.Size)
            {
                currentModule = module;
                currentIndex = module.ListIndex;

                if(gameModules.Count == module.ListIndex)
                {
                    Debug.Log("Está no ultimo módulo, cria mais um módulo seguinte");
                    AddModuleInList((Difficulty)Random.Range(0,2));
                }
            }
        }
	}

    private void AddModuleInGame(Module module)
    {
        // posicao do modulo é a posicao min + metade do size
        module.ModuleObject.transform.position = new Vector3(initialPositionX,module.PosMin + (module.Size/2),0);
        
    }

    private void AddModuleInList(Difficulty difficulty)
    {
        Module lastModule = ModuleRandomGenerator(difficulty);
        gameModules.Add(lastModule);
        MaxPositionWithLastModule += lastModule.Size;
        AddModuleInGame(lastModule);
    }

    private Module ModuleRandomGenerator(Difficulty difficulty)
    {
        if (difficulty == Difficulty.easy)
        {
            if(EasyModules.Length > 0)
            {
                int index = Random.Range(0, EasyModules.Length);
                return EasyModules[index].GetComponent<CreateModule>().CreateNewModule(gameModules.Count, (int) MaxPositionWithLastModule);
            } else
            {
                Debug.Log("Não há módulos fáceis disponíveis, tentando achar um módulo médio");
                return ModuleRandomGenerator(Difficulty.medium);
            }
            
        } else if (difficulty == Difficulty.medium)
        {
            if (MediumModules.Length > 0)
            {
                int index = Random.Range(0, MediumModules.Length);
                return MediumModules[index].GetComponent<CreateModule>().CreateNewModule(gameModules.Count, (int) MaxPositionWithLastModule);
            }
            else
            {
                Debug.Log("Não há módulos médios disponíveis, tentando achar um módulo difícil");
                return ModuleRandomGenerator(Difficulty.hard);
            }

        } else if (difficulty == Difficulty.hard)
        {
            if (HardModules.Length > 0)
            {
                int index = Random.Range(0, HardModules.Length);
                return HardModules[index].GetComponent<CreateModule>().CreateNewModule(gameModules.Count, (int) MaxPositionWithLastModule);
            }
            else
            {
                Debug.Log("Não há módulos difíceis disponíveis, encerrando procura");
                return null;
            }
        }

        return null;
    }
}
