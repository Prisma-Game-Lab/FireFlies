using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjectSound : MonoBehaviour {

    //public GameObject projectile;
    public AudioClip shootSound;
    public AudioClip aimSound;


    //private float throwSpeed = 2000f;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    void Awake () {
    
        source = GetComponent<AudioSource>();

    }


    void Update () {

        if (Input.GetButtonUp("Fire1"))
        {
            float vol = Random.Range (volLowRange, volHighRange);
            source.PlayOneShot(shootSound,vol);
            //GameObject throwThis = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
            //throwThis.GetComponent<Rigidbody>().AddRelativeForce (new Vector3(0,0,throwSpeed));
        }

        if (Input.GetButtonDown("Fire1"))
        {
            float vol = Random.Range (volLowRange, volHighRange);
            source.PlayOneShot(aimSound,vol);
        }
    
    }
}
