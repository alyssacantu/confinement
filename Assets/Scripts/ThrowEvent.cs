using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ThrowEvent : MonoBehaviour {

    public GameObject projectile;
    public AudioClip shootSound;


    private float throwSpeed = 2000f;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    void Awake()
    {

        //source = GetComponent<AudioSource>();
        //source.Play();

    }


    void Update()
    {
        
        //if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0)
        //{
        //    source.enabled = true;
        //    source.loop = true;
        //}
        //else
        //{
        //    source.enabled = false;
        //    source.loop = false;
        //}

    }

    

}