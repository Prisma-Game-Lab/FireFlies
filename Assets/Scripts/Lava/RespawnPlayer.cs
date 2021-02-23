using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {

    [HideInInspector]
    public Vector3 RespawnPosition;
    public float lavaRespawn = 35;
    private bool respawning = false;
    public GameObject deathParticle;

    public GameManager gm;

	private void OnEnable()
	{
        RespawnPosition = GameObject.Find("Player").transform.position;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        RespawnaPlayer(collision.gameObject.transform);
	}

    public void RespawnaPlayer(Transform go){

        if(go.tag == "Player" && !respawning){
            StartCoroutine(RespawnCoroutine(0.7f, go));
        }
    }

    IEnumerator RespawnCoroutine (float t, Transform go) {
        respawning = true;

        //play Death particle
        if(deathParticle != null){
            GameObject part = Instantiate(deathParticle, go);
            part.GetComponent<ParticleSystem>().Play();
        }

        //Desliga simulação (para não atualizar câmera durante transição)
        Rigidbody2D goRb = go.GetComponent<Rigidbody2D>();
        goRb.velocity = Vector2.zero;
        goRb.simulated = false;

        //Desliga Graphics
        go.GetChild(0).gameObject.SetActive(false);

        gm.SceneTransition("fadeIn");
        yield return new WaitForSeconds(t);
        gm.SceneTransition("fadeOut");

        go.GetChild(0).gameObject.SetActive(true);

        // Volta o player pra respawn position (que é atualizada a cada checkpoint que ele pega)
        go.transform.position = RespawnPosition;

        // Seta a velocidade do player como zero após a troca de posição
        goRb.velocity = Vector2.zero;
        goRb.simulated = true;

        GameObject.Find("Camera").GetComponent<FollowPlayer>().updateCenterCam(RespawnPosition.y + 5);

        //Acabou de respawnar o player no checkpoint
        GameObject.Find("Lava").GetComponent<LavaRising>().justRespawned = true;

        // coloca a lava abaixo do respawn do player
        GameObject.Find("Lava").transform.position = new Vector3(GameObject.Find("Lava").transform.position.x, RespawnPosition.y - lavaRespawn, 0);
        respawning = false;
    }
}
