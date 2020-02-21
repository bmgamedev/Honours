using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{

    /* 
     NOTE: Physics materials won't work with this because this is basically just re-writing the Physics2D system.
     if you want to use the in-built phsyics to use materials like bounciness, you can't use this.
     IF you want to use this and get things like bounciness, that needs to be coded
    */

    public float gravityModifier = 1.0f;
    public float minGroundNormalY = 0.65f;

    protected bool isGrounded;
    protected Vector2 groundNormal;
    protected Vector2 targetVelocity;
    protected Vector2 velocity;
    protected Rigidbody2D rb2d;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDist = 0.001f;
    protected const float shellRadius = 0.01f;

    void OnEnable()
    {

        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    private void Update()
    {
        targetVelocity = Vector2.zero; //so that we're not using target velocity from previous frame - it should always be the new velocity we've just calculated

        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {

    }

    private void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime; //gravity modifier
        velocity.x = targetVelocity.x;

        isGrounded = false;

        Vector2 deltaPos = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x); //gives a vector perpendicular to groundNormal

        //calculate and carry out x-axis (horizontal/walking) movement:
        Vector2 move = moveAlongGround * deltaPos.x;
        Movement(move, false); //false because x movement means NOT moving along y axis

        //calculate and carry out y-axis (vertical/jumping) movement:
        move = Vector2.up * deltaPos.y;
        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDist)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius); //add shellRadius stops the object getting stuck in colliders

            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal; //this is used to check if the player is standing on the ground based on the ground only every having a specific normal range (only specific slopes and flat ground will work) - won't work for slopes but stops walls triggering grounded. Why not just use layers and base it on where the collision object is on the ground layer???
                if (currentNormal.y > minGroundNormalY)
                {
                    isGrounded = true;
                    if (yMovement) //if moving along y axis
                    {
                        //TODO explain this...
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0) //ensure hitting sloped ceiling allows you to crape along rather than drop to floor
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
                /*
                    This is the same as:
                    
                    if (modifiedDistance < distance) {
                        distance = modifiedDistance
                    }
                    else {
                        distance = distance;
                    }
                */
            }
        }

        rb2d.position += move.normalized * distance;
    }
}
