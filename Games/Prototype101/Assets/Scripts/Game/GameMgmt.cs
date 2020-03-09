using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgmt : MonoBehaviour {

    static GameMgmt instance = null;

    public int finishedPlayers;

    private Text p1Score, p2Score, p1Deaths, p2Deaths, levelCount;
    //private int levelNum = 1;
    private int totalPlayers;
    private GameObject runtimeScriptable;

    void Awake()
    {
        runtimeScriptable = GameObject.Find("RuntimeScript");
        finishedPlayers = 0;

        if (GameObject.Find("P1Score") != null)
        {
            p1Score = GameObject.Find("P1Score").GetComponent<Text>();
        }

        if (GameObject.Find("P2Score") != null)
        {
            p2Score = GameObject.Find("P2Score").GetComponent<Text>();
        }

        if (GameObject.Find("P1Deaths") != null)
        {
            p1Deaths = GameObject.Find("P1Deaths").GetComponent<Text>();
        }

        if (GameObject.Find("P2Deaths") != null)
        {
            p2Deaths = GameObject.Find("P2Deaths").GetComponent<Text>();
        }

        if (GameObject.Find("LevelNum") != null)
        {
            levelCount = GameObject.Find("LevelNum").GetComponent<Text>();
        }
    }

    void Update ()
    {
        if (SceneManager.GetActiveScene().name != "Setup")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GrammarGenerator.ClearString();
                GameObject.Find("LoadingText").GetComponent<Text>().text = "Quitting";
                GameObject.Find("LoadingCam").GetComponent<Camera>().enabled = true;
                ScoreMgmt.ClearScores();
                ScoreMgmt.ClearDeaths();
                ScoreMgmt.ClearLevel();
                SceneManager.LoadScene("Setup");
            }
        }

        if (finishedPlayers == totalPlayers && totalPlayers !=0)
        {
            NextLevel();
        }
	}

    public void ShowScores(string player)
    {
        if (player.Equals("Player2"))
        {
            if (p2Score != null)
            {
                p2Score.text = "P2 Score: " + ScoreMgmt.GetScore("Player2").ToString();
            }
        }
        else
        {
            if (p1Score != null)
            {
                p1Score.text = "P1 Score: " + ScoreMgmt.GetScore("Player1").ToString();
            }
        }
    }

    public void ShowDeaths(string player)
    {
        if (player.Equals("Player2"))
        {
            if (p2Deaths != null)
            {
                p2Deaths.text = "P2 Deaths: " + ScoreMgmt.GetDeaths("Player2").ToString();
            }
        }
        else
        {
            if (p1Deaths != null)
            {
                p1Deaths.text = "P1 Deaths: " + ScoreMgmt.GetDeaths("Player1").ToString();
            }
        }
    }

    public void ShowLevel()
    {
        levelCount.text = "Level " + ScoreMgmt.GetLevel();
    }

    void NextLevel()
    {
        ScoreMgmt.IncreaseLevel();

        if (runtimeScriptable != null)
        {
            runtimeScriptable.GetComponent<RuntimeScriptable>().CompileNextLevel();
        }
    }

    public void AddPlayer()
    {
        totalPlayers++;
    }
}
