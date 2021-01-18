using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerInput = Vector3.zero;
    private CharacterController cc;
    private float yVelocity = 0f;   //track it sperately
    private float mouseSensitivity = 3f;
    private float pitch = 0f;

    [Tooltip("need player camera to pitch it up and down")]
    public Transform cameraTransform;

    [Range(3f, 15f)]
    public float playerSpeed = 5f;

    [Range(5f, 20f)]
    public float gravity = 10f;

    [Range(3f, 15f)]
    public float jumpSpeed = 5f;

    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        HideCursor(true);
    }

    private void OnDisable()
    {
        HideCursor(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        HandleMouseInput();
        move = transform.TransformVector(playerInput * playerSpeed);
        //now gravity
        if (CloseToGround())
        {
            //set it to be a little down

            if (Input.GetButtonDown("Jump"))
            {
                //jump!
                yVelocity = jumpSpeed;
            }
            else
            {
                //kind of zero out the y velocity
                yVelocity = 0f;
            }
        }
        else
        {
            //accelerate downwards
            yVelocity -= gravity * Time.deltaTime;
        }
        //set the y velocity of the move vector
        move.y = yVelocity;

        //move it
        cc.Move(move * Time.deltaTime);
    }


    private void HandleMouseInput()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -45, 45);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }


    private void GetPlayerInput()
    {
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");
        playerInput = Vector3.ClampMagnitude(playerInput, 1f);
        //deal with jumping?
    }

    void HideCursor(bool state)
    {
        Cursor.lockState = state ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = state ? false : true;
    }

    bool CloseToGround()
    {
        bool result = false;
        Ray ray = new Ray(transform.position, Vector3.down);
        //cast a ray down that is slightly bugger than the player- if it hits we are close to the ground
        if (Physics.Raycast(ray,1.2f))
        {
            result = true;
        }
        return result;
    }
}
