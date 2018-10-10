using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPersonController : MonoBehaviour {

    //public, so you can change this for play testing
    public float MOVEMENT_SPEED = 4.0f;
    public float MOUSE_SENSITIVITY = 1.0f;
    public float NECK_RANGE = 60.0f; // how far you can look up and down

  

    float forawrdSpeed;
    float sideSpeed;

    float rotationX;
    float verticalRotation = 0;

    // Use this for initialization
    void Start () {

        //hides the cursor when you start playing, hit ESC to get out of it
        //////////////////// THIS WILL HAVE TO BE MODIFIED WHEN YOU ARE SETTING A GAME SCREEN OR ANYTHING ELSE ////////////////////////////////////////////////
                                                    Cursor.lockState = CursorLockMode.Locked;
        //////////////////// THIS WILL HAVE TO BE MODIFIED WHEN YOU ARE SETTING A GAME SCREEN OR ANYTHING ELSE ////////////////////////////////////////////////
    }

    // Update is called once per frame
    void Update () {

        //////////////////////////Rotation Part///////////////////////////////////

        //unity axis implemented already
        rotationX = Input.GetAxis("Mouse X") * MOUSE_SENSITIVITY;
        transform.Rotate(0, rotationX, 0);

        //rotates the camera so you dont get a pitch
        verticalRotation += Input.GetAxis("Mouse Y") * MOUSE_SENSITIVITY;
        verticalRotation = Mathf.Clamp(verticalRotation, -NECK_RANGE, NECK_RANGE);
        Camera.main.transform.localRotation = Quaternion.Euler(-verticalRotation, 0, 0);



        ////////////////////////////Movement//////////////////////////////////////////

        //unity axis implemented already, mapped by default to W and S
        forawrdSpeed = Input.GetAxis("Vertical") * MOVEMENT_SPEED;
        sideSpeed = Input.GetAxis("Horizontal") * MOVEMENT_SPEED;

        //the location of the new place where you are going
        Vector3 speed = new Vector3(sideSpeed, 0, forawrdSpeed);

        //this allows the speed to adjust acording to the direction youre facing
        speed = transform.rotation * speed;

        CharacterController player = GetComponent<CharacterController>();
        player.SimpleMove(speed);

		if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            SceneManager.LoadScene("Menu");
        }

	}
}
