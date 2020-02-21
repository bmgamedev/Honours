using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingText : MonoBehaviour {

    private Text message;
    private List<string> messages = new List<string>() { "Loading", "Loading.", "Loading..", "Loading..." };
    int messagesPointer = 0;

	void Awake ()
    {
        Debug.Log("loading 'screen'");
        message = this.GetComponent<Text>();
        //InvokeRepeating("CycleMessage", .0f, 1.0f);
    }

    void CycleMessage()
    {
        message.text = messages[messagesPointer];

        if (messagesPointer == 3)
        {
            messagesPointer = 0;
        }
        else
        {
            messagesPointer++;
        }


    }

}
