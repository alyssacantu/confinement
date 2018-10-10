using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;

public class GroundBehavior : MonoBehaviour
{

    public List<GroundType> GroundTypes = new List<GroundType>();
    public FirstPersonController FPC; //this may have to be worked around
    string currentGround;

    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        setGroundType(GroundTypes[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0)
        {
            source.enabled = true;
            source.loop = true;
        }
        else
        {
            source.enabled = false;
            source.loop = false;
        }

    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Concrete")
            setGroundType(GroundTypes[1]);
        else if (hit.collider.tag == "Wet Concrete")
            setGroundType(GroundTypes[2]);
        else
            setGroundType(GroundTypes[0]);

        //Debug.Log(hit.collider.tag);
    }

    public void setGroundType(GroundType ground)
    {
        if (currentGround != ground.name)
        {
            //change n_footsteosounds from private to public in FPC first
            //FPC.m_FootStepSounds = ground.footstepsounds;

            //FPC.n_walkspeed = ground.walkspeed;
            //FPC.n_RunSpeed = ground.runspeed;
            source.Stop();

            source.clip = ground.FootStepSounds;
            source.Play();

            //Debug.Log("YOU CHANGED FLOORS");
             currentGround = ground.name;

        }
    }



}

[System.Serializable]
public class GroundType
{
    public string name;
    //needs at least 2 footsteps sounds
    public AudioClip FootStepSounds;
    //you can also add jump and landing sounds here
    public float walkspeed = 1;
    public float runspeed = 10;
}