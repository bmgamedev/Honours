using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgmt : MonoBehaviour {

    static GameMgmt instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GrammarGenerator.ClearString();
            GameObject.Find("LoadingCam").GetComponent<Camera>().enabled = true;
            SceneManager.LoadScene("Setup");
        }
	}
}
