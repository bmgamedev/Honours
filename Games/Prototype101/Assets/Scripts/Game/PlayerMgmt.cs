using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgmt : MonoBehaviour {

    //TODO
    //store start pos for reset function
    //store score.. or time.. or something I guess...
    //store count for pickups picked up

    private int pickupCount = 0;

    private Vector3 startPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "MeleeEnemy")
        {
            //if player is above the enemy then kill it and don't reset the player
            if (gameObject.transform.position.y > collision.collider.transform.position.y) { }
            if (gameObject.GetComponent<Collider2D>().bounds.min.y > (collision.collider.bounds.max.y - 0.1f))
            {
                Debug.Log("jumped on enemy's head");
            }
            //else, reset the player (or take health off if going that route)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            Reset();
        }

        if (collision.tag == "Pickup")
        {
            pickupCount++;
        }
    }

    public void SetStartPos(Vector3 startPosition)
    {
        startPos = startPosition;
    }

    private void Reset()
    {
        transform.position = startPos;
    }
}
