using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

    private Slider loadingBar;
    private List<string> loadingMessages = new List<string>() { "...Setting the scene...", "...placing cameras...", "...recruiting player...", "...releasing enemies...", "...dropping loot...", "...tidying up...", "...Loading game..."};
    private Text curLoadingMessage;

	// Use this for initialization
	void Start ()
    {
        loadingBar = FindObjectOfType<Slider>();
        curLoadingMessage = GameObject.Find("LoadingMessage").GetComponent<Text>();

        //start async operation
        StartCoroutine(LoadAsyncOperation());
	}

    IEnumerator LoadAsyncOperation()
    {
        //create an async operation
        AsyncOperation asyncLoadGameScene = SceneManager.LoadSceneAsync("Game");

        float progress = asyncLoadGameScene.progress;
        float phaseLength = 1 / loadingMessages.Count;
        int curPhase = 1;
        //progress bar fill = async operation progress
        curLoadingMessage.text = loadingMessages[0];
        while (asyncLoadGameScene.progress < 1)
        {
            if (progress > (curPhase * phaseLength) && curPhase < 7)
            {
                curLoadingMessage.text = loadingMessages[curPhase];
                curPhase++;
            }

            loadingBar.value = progress;
            yield return new WaitForEndOfFrame();
        }
    }


}
