using UnityEngine;
using System.Collections;


public class SideScrollerMvmt1 : MonoBehaviour {

    [SerializeField] private float Speed = 10.0f;
    [SerializeField] private float JumpHorizontalVel = 0.1f;
    [SerializeField] private float Jump = 0.3f;
    [SerializeField] private float m_JumpForce = 400f;
    [SerializeField] private LayerMask GroundLayer;

    private Rigidbody2D rb;
    private Animator animator;
	private Transform groundCheck;

    private float distToGround;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;
    private bool isGrounded;

    private string inputJump, inputHor;

    void Start () 
	{
        //define inputs for each player
        if (gameObject.name == "Player2")
        {
            inputJump = "Jump2";
            inputHor = "Horizontal2";
        }
        else
        {
            inputJump = "Jump";
            inputHor = "Horizontal";
        }

        animator = GetComponent<Animator>();

        distToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () 
	{
        if (Input.GetButton(inputJump))
        {
            if(isGrounded){
                rb.AddForce(new Vector2(0f, m_JumpForce));
            }
        }
           
       animator.SetBool("isGrounded", isGrounded);

        //float hSpeed = Input.GetAxis("Horizontal");
        float hSpeed = Input.GetAxis(inputHor);
        animator.SetFloat("Speed", Mathf.Abs(hSpeed));
	
		if(hSpeed > 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}	
		else if (hSpeed < 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}

        if (!isGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed * JumpHorizontalVel, rb.velocity.y);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed * Speed, rb.velocity.y);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //Debug.Log("sitting on ground");
            isGrounded = true;
            //Debug.Log(isGrounded);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (isGrounded)
            {
                isGrounded = false;
            }
        }
    }
}
