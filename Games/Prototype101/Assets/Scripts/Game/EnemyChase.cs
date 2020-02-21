using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public enum enemyState
{
    SEARCHING,
    ATTACKING,
    DEAD
}

public class EnemyChase : PhysicsObject {

    //public GameObject target; //target only needed for seeking 

    private Animator animator;
    public float sightRange; //TODO change to private after debugging

    /*enemyState thisEnemyState;

    void Update()
    {
        switch (thisEnemyState)
        {
            case enemyState.SEARCHING:
                //wander whilst using raycast to determine if player is "seen"
                //else if (player is found)
                //{ myEnemyState = enemyState.ATTACKING}
                break;
            case enemyState.ATTACKING:
                //attack player
                //if (player not within attack range)
                //{ move at maxspeed toward player whilst attacking }
                break;
            case enemyState.DEAD:
                //destroy gameObject
                break;
            default:
                break;
        }
    }*/

    private void Start()
    {
        targetVelocity = Vector2.right;
        animator = GetComponent<Animator>();
        sightRange = 100.0f;
    }

    private void Update()
    {
        //visual only for debugging. Remove after confirming
        Debug.DrawRay(transform.position, transform.forward, Color.red, sightRange);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, sightRange);
        if (hit.collider.tag == "Player"){
            Chase();
        }
        else{
            //warskeleanimator.movingstate.speed = 0.5;
            animator.speed = 0.5f;
        }
    }

    void Chase(){
        //warskeleanimator.movingstate.speed = 1.5 for X seconds;
        animator.speed = 1.5f; //FOR X SECS??

        //visual only for debugging. Remove after confirming
        Debug.DrawRay(transform.position, transform.forward, Color.red, sightRange);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, sightRange);
        if (hit.collider.tag != "Player"){
            //go in other direction
            if (targetVelocity == Vector2.left)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                targetVelocity = Vector2.right;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
                targetVelocity = Vector2.left;
            }
        }
    }

    void OnCollisionEnter2D (Collision2D collision) { 
        //TODO currently there's a random box collider with the Wall tag because the walls are currently on the tilemap tagged as Ground.
        //would prefer to check for this collision a better way - tagged ground but w/ a normal of a wall rather than the ground?!?
        if (collision.collider.tag == "Wall"){

            print("hit a wall");
            //go in other direction
            if (targetVelocity == Vector2.left)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                targetVelocity = Vector2.right;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
                targetVelocity = Vector2.left;
            }
        }
        else if (collision.otherCollider.tag == "Wall")
        {
            print("this is the correct collider dumbass");
        }
        else if (collision.otherCollider.gameObject.layer == 9)
        {
            print("this is an enemy (based on layer)");
        }
    }

    

}
