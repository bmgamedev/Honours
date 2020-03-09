using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_mvmt : MonoBehaviour {

    [SerializeField] private float Speed = 10.0f;
    private float inputDeadzone = 0.1f;
    [SerializeField] private float walkSpeed = 2;
    [SerializeField] private float runSpeed = 4;
    //public float turnSpeed = 10;
    //public float strafeSpeed = 5;
    private bool running = false;

    //public LayerMask groundLayerMask;

    private Vector2 input;
    private Vector3 movement;
    private Quaternion targetRotation;
    private Rigidbody2D rb;
    private Animator animator;

    private string inputJump, inputHor, inputVert;
    private KeyCode inputFire, inputRun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetRotation = transform.rotation;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        Move();
    }

    void GetInput()
    {
        //define inputs for each player
        if (gameObject.name == "Player1")
        {
            inputHor = "Horizontal";
            inputVert = "Vertical";
            inputFire = KeyCode.E;
            inputRun = KeyCode.LeftShift;
        }
        else
        {
            inputHor = "Horizontal2";
            inputVert = "Vertical2";
            inputFire = KeyCode.Alpha0;
            inputRun = KeyCode.RightShift;
        }
        input = new Vector2(Input.GetAxisRaw(inputHor), Input.GetAxisRaw(inputVert));

        // toggle running
        if (Input.GetKeyDown(inputRun))
        {
            running = !running;
        }
    }

    void Move()
    {
        float movementSpeed;
        if (running)
        {
            movementSpeed = runSpeed;
        }
        else
        {
            movementSpeed = walkSpeed;
        }

        if (Mathf.Abs(input.y) > inputDeadzone || Mathf.Abs(input.x) > inputDeadzone)
        {
            transform.Translate(input.normalized * movementSpeed * Time.deltaTime, 0);

            animator.SetFloat("YMovement", input.y);
            animator.SetFloat("XMovement", input.x);
        }

    }
}
