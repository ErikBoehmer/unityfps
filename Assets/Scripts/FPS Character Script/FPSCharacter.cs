using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    private Transform firstperson_view;
    private Transform firsperson_camera;
    private Vector3 firstperson_view_rotation = Vector3.zero;

    public float walkSpeed = 6.75;
    public float runSpeed = 10f;
    public float crouchSpeed = 4f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    private float Speed;

    private bool is_Moving, is_Grounded; is_Crouching;
    private float inputX, inputY;
    private float inputX_Set, inputY_Set;
    private float inputModifyFactor;
    private bool limitDiagionalSpeed = true;
    private float antiBumpFactor = 0.75f;
    private Vector3 moveDirection = 0f;






    // Start is called before the first frame update




    void Start()
    {
        firstperson_view = transform.Find("FPS View").transform;
        charController = GetComponent<CharacterController>();
        Speed = walkSpeed;
        is_Moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

    }
    void PlayerMovement()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey.S)){
            if(Input.GetKey(KeyCode.W))
            {
                inputY_Set = 1f;
            }
            else
            {
                inputY_Set = -1f;
            }
            else
            {
                inputY_Set = 0f;
            }
            if(input.GetKey(KeyCode.A) || input.GetKey(KeyCode.D))
            {
                if (input.GetKey(KeyCode.A))
                {
                    inputX_Set = -1f;
                }
                else
                {
                    inputX_Set = 1f;
                }
                else
                {
                    inputX_Set = 0f;
                }


            }

            inputY = Mathf.Lerp(inputY, inputY_Set, Time.deltaTime * 19f);
            inputX = Mathf.Lerp(inputY, inputX_Set, Time.deltaTime * 19f);

            inputModifyFactor = Mathf.Lerp(inputModifyFactor, (inputY_Set != 0 && inputX_Set != 0 && limitDiagionalSpeed) ? 0.75f : 1.0f,
                Time.deltaTime * 19f);


            firstperson_view_rotation = Vector3.Lerp(firstperson_view_rotation, Vector3.zero, Time.deltaTime * 5f);
            firstperson_view.localEulerAngles = firstperson_view_rotation; 

            if(is_Grounded)
            {
                moveDirection = new Vector3(inputX * inputModifyFactor, -antibumpfactor, inputY * inputModifyFactor);
                moveDirection = transform.TransformDirection(moveDirection) * Speed;

            }

            moveDirection.y -= gravity * Time.deltaTime;

            is_Grounded = (charController.Move(moveDirection * Time.deltaTime) & CollisionFlags.Below) !=0;
            is_Moving = charController.velocity.magnitude > 0.15f; 


        }
    }











}