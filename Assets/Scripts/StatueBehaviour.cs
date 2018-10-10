using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class StatueBehaviour : MonoBehaviour
{

    enum STATE { IDLE, CHASE };
    STATE _currentState;

    NavMeshAgent _controller;
    public GameObject _player;
    public AudioSource chase;
    public AudioSource screech;
    Animator anim;

    Renderer rend;
    bool visible;
    float distanceToTarget;


    bool open = true; //checks if the player is not behind a wall
    public float viewAngle = 90f;



    void Update()
    {
        
        RaycastHit hit;
        if (Physics.Linecast(transform.position + transform.up, _player.transform.position, out hit)) //asks if theres something inbetween, have to set player, mosnter and floor to not collide
        {
            //Debug.Log(hit);
            //Debug.DrawLine(transform.position, _player.transform.position);
            //Debug.Log("Blocked by : " + hit.collider.ToString());

            open = false;

        }
        else
            open = true;


        //Vector3 directionToTarget = (_player.transform.position - transform.position).normalized;
        //if (Vector3.Angle(_player.transform.forward, directionToTarget) < viewAngle / 2)
        //{
        //    visible = true;
        //}
        //else
        //    visible = false;


   
  

    }



    IEnumerator Start()
    {
        _controller = GetComponent<NavMeshAgent>();
        rend = GetComponent<Renderer>();
       // chase = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        




        _currentState = STATE.IDLE;

        while (true)
        {
            switch (_currentState)
            {
                case STATE.IDLE:
                   // Debug.Log("IDLE STATE");
                    Idle();
                    break;

                case STATE.CHASE:
                   // Debug.Log("CHASE STATE");
                    Chase();
                    break;
            }

            yield return 0;
        }
    }

    //Idle method
    void Idle()
    {
        this.gameObject.GetComponent<AudioSource>().enabled = true;
        chase.Play();
        screech.Play();

       



        _controller.enabled = false;
        distanceToTarget = Vector3.Distance(transform.position, _player.transform.position);

        if (distanceToTarget < 4)
        {
            SceneManager.LoadScene("gameover");
            //Debug.Log("gameoverrrrrrr");
        }

        if (!visible && distanceToTarget < 30 && open)
        {
            _currentState = STATE.CHASE;

        }


    }

    //Chase method
    void Chase()
    {
        
        _controller.enabled = true;
        //this.gameObject.GetComponent<AudioSource>().enabled = true;

        //screech.Play();
        anim.Play("walk");
        _controller.SetDestination(_player.transform.position);
        distanceToTarget = Vector3.Distance(transform.position, _player.transform.position);



        if (distanceToTarget < 4 && !visible)
        {
            SceneManager.LoadScene("gameover");
            //Debug.Log("gameoverrrrrrr");
        }


        if (visible || distanceToTarget > 30 || !open)
        {
            _currentState = STATE.IDLE;

        }

    }


    private void OnBecameVisible()
    {
        visible = true;
    }

    private void OnBecameInvisible()
    {
        visible = false;

    }


}
