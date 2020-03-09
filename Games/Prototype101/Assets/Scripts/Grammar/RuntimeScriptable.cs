using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RuntimeScriptable : MonoBehaviour 
{
	private GameProgram _program;

    static RuntimeScriptable instance = null;
    static string generatorText;

    [SerializeField]
    private Text debugText;
    [SerializeField]
    private Text grammarDisplay;

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

    public void CompileAndRun()
	{
        grammarDisplay = GameObject.Find("ScriptDisplay").GetComponent<Text>();

        if (GrammarGenerator._FullGameScript == null || GrammarGenerator._FullGameScript.Equals(""))
        {
            grammarDisplay.text = "Remember to press 'Generate Script' before creating the game!";
        }
        else
        {
            generatorText = GrammarGenerator._FullGameScript;
            StopAllCoroutines();
            _program = GameCompiler.Compile(GrammarGenerator._FullGameScript);
            StartCoroutine(_program.Run());
        }
    }

    public void CompileNextLevel()
    {
        if (GrammarGenerator._FullGameScript != null)
        {
            generatorText = GrammarGenerator._FullGameScript;
            StopAllCoroutines();
            _program = GameCompiler.Compile(GrammarGenerator._FullGameScript);
            StartCoroutine(_program.Run());
        }
    }

    /*public void DebugRun(GameObject debugtext)
    {
        string generatorText2 = "initialise dungeon easy difficulty small players 1 finalise";
        StopAllCoroutines();
        _program = GameCompiler.Compile(generatorText2); 
        StartCoroutine(_program.Run());
    }*/
}