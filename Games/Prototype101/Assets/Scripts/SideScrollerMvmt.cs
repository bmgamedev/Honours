using UnityEngine;
using System.Collections;


public class SideScrollerMvmt : MonoBehaviour {
	
	public float Speed = 10.0f;
	public float Jump = 0.3f;
    public LayerMask GroundLayer;

    private Animator animator;
	private Transform groundCheck;

    //NEW JUMP METHOD (20180626)
    private float distToGround;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;
    private bool isGrounded;

    //NEW JUMP METHOD (20180626)
    Rigidbody2D rb;

    void Start () 
	{
        animator = GetComponent<Animator>();
        //groundCheck = transform.Find("GroundCheck");

        //NEW JUMP METHOD (20180626)
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        rb = GetComponent<Rigidbody2D>();
    }

    //NEW JUMP METHOD (20180626)
    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier-1) * Time.deltaTime; //the -1 is supposed to account for the 1 of grav already applied but then just make fallmultiplier one less????
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        Debug.Log(isGrounded);
    }

    void FixedUpdate () 
	{
        //NEW JUMP METHOD (20180626)
        //bool isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.01f);
        //bool isGrounded = gameObject.GetComponentInChildren<GroundCheck>().isGrounded;

        //bool isGrounded = Physics2D.OverlapPoint (groundCheck.position, GroundLayer);

        if(Input.GetButton("Jump"))
        {
            if(isGrounded){
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            }
        }

       animator.SetBool("isGrounded", isGrounded);

        float hSpeed = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(hSpeed));
	
		if(hSpeed > 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}	
		else if (hSpeed < 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed * Speed, this.GetComponent<Rigidbody2D>().velocity.y);
	}

    //NEW JUMP METHOD (20180626)
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
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
