using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update private GameObject playerGameObject;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    [SerializeField] private GameObject characterListObject;
    Camera camera;


    private Vector3 moveDirection;
    private Vector3 velocity;
    private Animator animator;

    private CharacterController controller;
    private int index;
    private GameObject[] myCharacters;
    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        myCharacters = new GameObject[characterListObject.transform.childCount];
        for (int i = 0; i < characterListObject.transform.childCount; i++)
        {
            myCharacters[i] = characterListObject.transform.GetChild(i).gameObject;

        }
        foreach (GameObject go in myCharacters)
        {
            go.SetActive(false);
        }
        if (myCharacters[index])
        {
            myCharacters[index].SetActive(true);
        }
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        print("where is the " + animator);
    }
    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //     Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            //     RaycastHit hit;
            //     if (Physics.Raycast(ray, out hit, 100))
            //     {
            //         InteractingController interactable = hit.collider.GetComponent<InteractingController>();
            //         if (interactable != null)
            //         {
            //             SetFocus(interactable);
            //         }
            //     }
        }
    }
    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        print(moveZ);
        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        // if (isGrounded)
        // {
        print("Reached  Function");
        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            //walk
            print("Reached  Walk");

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

        // }
        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    private void Idle()
    {
        animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    private void Walk()
    {
        moveSpeed = walkSpeed;
        animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

    }
    private void Run()
    {
        moveSpeed = runSpeed;
        animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);


    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
    private IEnumerator Attack()
    {
        animator.SetLayerWeight(animator.GetLayerIndex("Attack Layer"), 1);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.9f);
        animator.SetLayerWeight(animator.GetLayerIndex("Attack Layer"), 0);
    }

}
