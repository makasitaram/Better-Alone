using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private GameObject playerGameObject;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;


    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, moveZ);
        if (isGrounded)
        {

            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //walk
                Walk();


            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                //Idle
                Idle();
            }
            moveDirection *= moveSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void Idle()
    {

    }
    private void Walk()
    {
        moveSpeed = walkSpeed;
    }
    private void Run()
    {
        moveSpeed = runSpeed;

    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
    // {

    //     float speed = 2;
    //     float rotSpeed = 80;
    //     float gravity = 8;
    //     float rot = 0;
    //     float jumpSpeed =2;


    //     Vector3 moveDir = Vector3.zero;
    //     CharacterController controller;
    //     private float ySpeed;
    //     Animator animator;

    //     // Start is called before the first frame update
    //     void Start()
    //     {
    //         controller = GetComponent<CharacterController>();
    //         animator = GetComponent<Animator>();
    //     }

    //     // Update is called once per frame
    //     void Update()
    //     {
    //        Movement();
    //        GetInput();
    //     }
    //     void Movement()
    //     {
    //          if (controller.isGrounded)
    //         {
    //             if (Input.GetKey(KeyCode.W))
    //             {
    //                 animator.SetBool("running",true);
    //                 animator.SetInteger("condition",1);
    //                 moveDir = new Vector3(0, 0, 1);
    //                 moveDir = moveDir * speed;
    //                 moveDir = transform.TransformDirection(moveDir);
    //             }
    //             if (Input.GetKeyUp(KeyCode.W))
    //             {
    //                 animator.SetBool("running",false);

    //                 animator.SetInteger("condition",0);

    //                 moveDir = new Vector3(0, 0, 0);
    //             }
    //         }
    //         rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
    //         transform.eulerAngles = new Vector3(0, rot, 0);
    //         moveDir.y -= gravity * Time.deltaTime;
    //         controller.Move(moveDir * Time.deltaTime);
    //     }
    //     void GetInput()
    //     {
    //         if(controller.isGrounded)
    //         {
    //             if(Input.GetKey(KeyCode.Space))
    //             {
    //                 Jumping();
    //             }
    //         }
    //     }
    //     void Jumping()
    //     {
    //         animator.SetBool("jumping",true);
    // animator.SetInteger("condition",2);
    // StartCoroutine(AttackRoutine());
    // animator.SetInteger("condition",0);
    // animator.SetBool("jumping",false);
    //     }
    //     IEnumerator AttackRoutine()
    //     {
    //         yield return new WaitForSeconds(1);
    //     }
}
