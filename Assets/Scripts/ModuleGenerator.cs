using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleGenerator : MonoBehaviour {

    public GameObject[] EasyModules;
    public GameObject[] MediumModules;
    public GameObject[] HardModules;

    private float initialPositionX = 3.88f;
    private float initialPositionY;

    private List<Module> gameModules;

    private Module currentModule;

    private GameObject player;

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

        initialPositionY = player.transform.position.y;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // Verifica em que modulo o player está atualmente
		
	}


    private Module ModuleGenerator(Difficulty difficulty)
    {
        if (difficulty == Difficulty.easy)
        {
            if(EasyModules.Length > 0)
            {
                int index = Random.Range(0, EasyModules.Length);
                return EasyModules[index].GetComponent<CreateModule>().GetModule();
            } else
            {
                Debug.Log("Não há módulos fáceis disponíveis, tentando achar um módulo médio");
                return ModuleGenerator(Difficulty.medium);
            }
            
        } else if (difficulty == Difficulty.medium)
        {
            if (MediumModules.Length > 0)
            {
                int index = Random.Range(0, MediumModules.Length);
                return MediumModules[index].GetComponent<CreateModule>().GetModule();
            }
            else
            {
                Debug.Log("Não há módulos médios disponíveis, tentando achar um módulo difícil");
                return ModuleGenerator(Difficulty.hard);
            }

        } else if (difficulty == Difficulty.hard)
        {
            if (MediumModules.Length > 0)
            {
                int index = Random.Range(0, MediumModules.Length);
                return MediumModules[index].GetComponent<CreateModule>().GetModule();
            }
            else
            {
                Debug.Log("Não há módulos difíceis disponíveis, encerrando procura");
                return null;
            }
        }
    }
}
