using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keylocation : MonoBehaviour {

    public Transform _player;
    public Transform door;
    Transform key;
    float distanceToDoor;
    float distanceToTarget;
    bool havekey;
    Vector3[] keyspawns = new Vector3[6];
    int random;

    public AudioSource keygrab;

    void Start()
    {
        keyspawns[0] = new Vector3(-66f, 1f, 23f);
        keyspawns[1] = new Vector3(-44f, 1f, -72f);
        keyspawns[2] = new Vector3(82f, 1f, -82f);
        keyspawns[3] = new Vector3(82f, 1f, 79f);
        keyspawns[4] = new Vector3(-71f, 1f, -69f);
        keyspawns[5] = new Vector3(-84f, 1f, -74f);
        random = Random.Range(0, 5);

        transform.position = keyspawns[random];
        havekey = false;

    }



    // Update is called once per frame
    void Update ()
    {
        
        //_player = GameObject.Find("Player").transform;
       // door = GameObject.Find("Door").transform;

        distanceToTarget = Vector3.Distance(transform.position, _player.position);
        distanceToDoor = Vector3.Distance(_player.position, door.position);

        

        if (distanceToTarget < 2)
        {
            if (havekey == false)
                keygrab.Play();// this wont work, its playing the sound (whose beginning is empty) on every frame

            // Debug.Log("YOU HAVE FOUND THE KEY");
            havekey = true;
            GameObject.Find("pPlane3").GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            
        }

        if(distanceToDoor < 2)
        {
           
            if (havekey == true)
            {
                SceneManager.LoadScene("gamewon");
            }
            else
            {
               // Debug.Log("Missing key");

            }
        }
    }
    
}
