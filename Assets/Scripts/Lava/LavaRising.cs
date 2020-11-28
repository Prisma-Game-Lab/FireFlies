using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour {

    // É a variavel que espera 1 segundo quando o player respawna
    public float initialDelay = 1.0f;
    public float risePercent = 0.1f;
    //public float secondsforRise = 1.0f;

    [HideInInspector]
    // Assim que foi respawnado
    public bool justRespawned = true;

    private float currentInitialDelay = 0;
    private float currentSecondsForRise = 0;

    // Espera um tempo inicial antes de começara subir a lava
    private bool isRising = false;


	// Update is called once per frame
	void LateUpdate () {

        // Ele respawnou e ajeitou a variável isRising
        if (!justRespawned) {

            // Se a lava não está subindo, é porque ele tá esperando você respawnar para subir
            if(!isRising){

                // Quando o player acaba de respawnar, espera um tempo antes de fazer a lava subir
                currentInitialDelay += Time.deltaTime;

                // Quando passa um segundo ele faz a lava subir
                if(currentInitialDelay >= initialDelay){
                    isRising = true;
                }

            // Esperou o tempo que precisava para o player respawnar
            } else {

                // Sobe a lava a cada frame em cima da porcentagem indicada
                this.transform.position += new Vector3(0, risePercent, 0); 
            }
         
        // Ele acabou de respawnar
        } else {

            // Para de movimentar a lava 
            isRising = false;
            justRespawned = false;

            // Reinicia o timer para esperar para que a lava suba
            currentInitialDelay = 0;
        }

    }

}
