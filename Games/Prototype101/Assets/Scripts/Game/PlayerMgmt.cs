using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgmt : MonoBehaviour {

    //TODO
    //store score.. or time.. or something I guess...

    private GameObject runtimeScriptable;

    private int pickupCount = 0;
    private int score = 0;
    int pickupScore = 100;

    private Vector3 startPos;

    private void Awake()
    {
        runtimeScriptable = GameObject.Find("RuntimeScript");
        score = 0;
        pickupCount = 0;
    }

    private void Update()
    {
        //UI text = score

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 10) //10 = layer 'Enemy'
        {
            score -= 25;
            Reset();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            score -= 25;
            Reset();
        }

        if (collision.tag == "Pickup")
        {
            pickupCount++;
            score += pickupScore;
        }

        if (collision.tag == "Exit")
        {
            if (runtimeScriptable != null)
            {
                runtimeScriptable.GetComponent<RuntimeScriptable>().CompileNextLevel();
            }
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

    public void AddPoints(int points)
    {
        score += points;
    }
}
