using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjectSound : MonoBehaviour {

    public AudioClip shootSound;
    public AudioClip aimSound;


    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    private bool canJump = true;
    private GameObject mainCamera;

    public SpriteRenderer rostoBase;
    public SpriteRenderer rosto;
    public Color colorActive;
    public Color colorInactive;

    public ParticleSystem particula;
    public ParticleSystem particula2;
    private bool onecheck = true;

    void Awake () {
    
        source = GetComponent<AudioSource>();
        
    }
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update () {

        canJump = mainCamera.GetComponent<Controls>().isAbleToJump;
        if (canJump)
        {
            rostoBase.color = colorActive;
            rosto.color = Color.white;
            if (onecheck)
            {
                onecheck = false;
                particula.Play();
                particula2.Play();
            }
        }
        else
        {
            rostoBase.color = colorInactive;
            rosto.color = colorInactive;
            onecheck = true;
        }
    }
}
