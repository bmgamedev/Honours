using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCheck : MonoBehaviour {

    private GameMgmt gameMgmt;
    Sprite activeButton, inactiveButton;

    private void Awake()
    {
        gameMgmt = GameObject.Find("GameMgmt").GetComponent<GameMgmt>();
        activeButton = Resources.Load("triggers_0", typeof(Sprite)) as Sprite;
        inactiveButton = Resources.Load("triggers_1", typeof(Sprite)) as Sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            gameMgmt.finishedPlayers++;

            /*if (collision.name == "EndPosDungeon")
            {
                collision.GetComponent<SpriteRenderer>().sprite = activeButton;
            }*/
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            gameMgmt.finishedPlayers--;

            /*if (collision.name == "EndPosDungeon")
            {
                collision.GetComponent<SpriteRenderer>().sprite = inactiveButton;
            }*/
        }
    }
}
