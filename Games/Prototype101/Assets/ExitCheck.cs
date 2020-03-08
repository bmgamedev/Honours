using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCheck : MonoBehaviour {

    private GameMgmt gameMgmt;

    private void Awake()
    {
        gameMgmt = GameObject.Find("GameMgmt").GetComponent<GameMgmt>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            gameMgmt.finishedPlayers++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            gameMgmt.finishedPlayers--;
        }
    }
}
