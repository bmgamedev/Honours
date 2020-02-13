using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorDisplay : MonoBehaviour {

    private Text scriptDisplay;
    private ToggleGroup[] toggleGroups;
    
	void Start () {
        scriptDisplay = GameObject.Find("ScriptDisplay").GetComponent<Text>();
        toggleGroups = FindObjectsOfType<ToggleGroup>();

        //Debug.Log("# toggle groups: " + toggleGroups.Length);
	}

	public void CreateScript () {

        //Debug.Log("# of game input elements: " + GrammarGenerator._GameScriptElements.Count);

        GrammarGenerator.ClearScript();
        foreach (var tgroup in toggleGroups) {
            tgroup.GetComponent<ToggleMenu>().UpdateGrammarInput();
        }

        scriptDisplay.text = "";
		foreach (var elem in GrammarGenerator._GameScriptElements) {
            scriptDisplay.text += elem;
            scriptDisplay.text += " ";
        }
	}
}
