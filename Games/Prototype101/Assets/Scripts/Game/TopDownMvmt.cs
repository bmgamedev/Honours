using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMvmt : MonoBehaviour {

    private float inputDeadzone = 0.1f;
    private float walkSpeed = 2;
    private float runSpeed = 4;
    //public float turnSpeed = 10;
    //public float strafeSpeed = 5;
    private bool running = false;

    //public LayerMask groundLayerMask;

    private Vector2 input;
    //private Vector3 movement;
    //private Quaternion targetRotation;
    //private Rigidbody2D rb;

    // Use this for initialization
    void Start() 
    {
        //rb = GetComponent<Rigidbody2D>();
        //targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        //Turn();
        Move();
    }

    void GetInput()
    {
        // get input
        //input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // toggle running
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            running = !running;
            //Debug.Log("Running Toggled");
        }
    }

    void FixedUpdate()
    {
        //Move();
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
            // move
            //rb.velocity = transform.forward * input.normalized * movementSpeed;
            transform.Translate(input.normalized * movementSpeed * Time.deltaTime, 0);
        }
        else
        {
            //rb.velocity = Vector3.zero;
        }


        /*if (Mathf.Abs(input.y) > inputDeadzone)
        {
            // move
            rb.velocity = transform.forward * input.y * movementSpeed;
        }
        else if (Mathf.Abs(input.x) > inputDeadzone)
        {
            // move
            rb.velocity = transform.right * input.x * movementSpeed;
        }
        else
        {
            // zero velocity
            rb.velocity = Vector3.zero;
        }*/
    }

    /*void Turn()
    {
        
		//if(Mathf.Abs(input.x) > inputDeadzone)
		//{
		//	targetRotation *= Quaternion.AngleAxis(turnSpeed * input.x * Time.deltaTime, Vector3.up);
		//}
		//transform.rotation = targetRotation;
		

        // get mouse point
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // if mouse if far enough away
        RaycastHit hit;

        // if (Physics.Raycast(cameraRay.direction, Vector3.down, out hit, Mathf.Infinity, groundLayerMask)){
        if (Physics.Raycast(cameraRay, out hit, Mathf.Infinity, groundLayerMask))
        {
            // get point to look at
            Vector3 pointToLookAt = hit.point;
            // modify y so we don't look at the ground
            pointToLookAt.y = transform.position.y;
            // TODO use turn speed to lerp toward pointToLookAt
            transform.LookAt(pointToLookAt);
            // transform.LookAt(transform.position + pointToLookAt, Vector3.up);
        }


    }*/

}