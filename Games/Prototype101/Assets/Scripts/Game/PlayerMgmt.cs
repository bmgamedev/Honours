using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgmt : MonoBehaviour {

    private GameObject runtimeScriptable;
    private GameMgmt gameMgmt;

    private int pickupCount = 0;
    private int pickupScore = 50;

    private Vector3 startPos;

    private void Awake()
    {
        runtimeScriptable = GameObject.Find("RuntimeScript");
        gameMgmt = GameObject.Find("GameMgmt").GetComponent<GameMgmt>();
        gameMgmt.AddPlayer();
    }

    private void Update()
    {
        gameMgmt.ShowScores(gameObject.name);
        gameMgmt.ShowDeaths(gameObject.name);
        gameMgmt.ShowLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 10) //10 = layer 'Enemy'
        {
            Reset();
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
            ScoreMgmt.IncreaseScore(gameObject.name, pickupScore);
            gameMgmt.ShowScores(gameObject.name);
            gameMgmt.ShowDeaths(gameObject.name);
        }
    }

    public void SetStartPos(Vector3 startPosition)
    {
        startPos = startPosition;
    }

    private void Reset()
    {
        ScoreMgmt.IncreaseDeaths(gameObject.name);
        ScoreMgmt.DecreaseScore(gameObject.name, 25);
        gameMgmt.ShowScores(gameObject.name);
        gameMgmt.ShowDeaths(gameObject.name);
        transform.position = startPos;
    }

    public void AddPoints(int points)
    {
        ScoreMgmt.IncreaseScore(gameObject.name, points);
        gameMgmt.ShowScores(gameObject.name);
        gameMgmt.ShowDeaths(gameObject.name);
    }
}
