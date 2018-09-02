using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjectSound : MonoBehaviour {

    public AudioClip shootSound;
    public AudioClip aimSound;


    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;





    void Awake () {
    
        source = GetComponent<AudioSource>();

    }


    void Update () {
        
        if (Input.GetButtonUp("Fire1")) // solta
        {
            float vol = Random.Range (volLowRange, volHighRange);
            source.PlayOneShot(shootSound,vol);
        }

        if (Input.GetButtonDown("Fire1")) // pega
        {
            float vol = Random.Range (volLowRange, volHighRange);
            source.PlayOneShot(aimSound,vol);
        }
    
    }
}
