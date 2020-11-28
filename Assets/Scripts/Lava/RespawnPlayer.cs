using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {

    [HideInInspector]
    public Vector3 RespawnPosition; // VERIFICAR ONDE ELE ATUALIZA ESSE VALOR
    public float lavaRespawn = 35;

	private void OnEnable()
	{
        RespawnPosition = GameObject.Find("Player").transform.position;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        RespawnaPlayer(collision.gameObject.transform);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}


    public void RespawnaPlayer(Transform go){

        if(go.tag == "Player"){

            // Volta o player pra respawn position (que é atualizada a cada checkpoint que ele pega)
            go.transform.position = RespawnPosition;

            // Seta a velocidade do player como zero após a troca de posição
            go.GetComponent<Rigidbody2D>().velocity = Vector2.zero;


            GameObject.Find("Camera").GetComponent<FollowPlayer>().updateCenterCam(RespawnPosition.y + 5);

            //Acabou de respawnar o player no checkpoint
            GameObject.Find("Lava").GetComponent<LavaRising>().justRespawned = true;

            // coloca a lava abaixo do respawn do player
            GameObject.Find("Lava").transform.position = new Vector3(GameObject.Find("Lava").transform.position.x, RespawnPosition.y - lavaRespawn, 0);
            //GameObject.Find("Lava").GetComponent<LavaRising>().StartLavaRising();
        }
    }
}
