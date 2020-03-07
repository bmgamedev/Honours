using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorDisplay : MonoBehaviour
{
    private GameProgram _program;

    private Text scriptDisplay;
    [SerializeField]
    private ToggleGroup[] toggleGroups;

    void Start()
    {
        scriptDisplay = GameObject.Find("ScriptDisplay").GetComponent<Text>();
        //Debug.Log("# toggle groups: " + toggleGroups.Length);
    }

    public void DisplayScript()
    {
        GrammarGenerator.ClearScript();
        foreach (var tgroup in toggleGroups)
        {
            tgroup.GetComponent<ToggleMenu>().UpdateGrammarInput();
        }

        scriptDisplay.text = "initialise \n";
        foreach (var elem in GrammarGenerator._GameScriptElements)
        {
            scriptDisplay.text += elem;
            scriptDisplay.text += "\n";
        }

        scriptDisplay.text += "finalise";

        SubmitScript();
    }

    public void SubmitScript()
    {
        //GrammarGenerator.SetString("initialise " + GeneratePath(maxIterations) + " " + scriptDisplay.text.Replace("\n", " "));
        GrammarGenerator.SetString("initialise " + scriptDisplay.text.Replace("\n", " ") + "finalise");
    }
}