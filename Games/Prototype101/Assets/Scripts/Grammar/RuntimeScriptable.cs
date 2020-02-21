using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RuntimeScriptable : MonoBehaviour 
{
	private PrototypeProgram _program;

    static RuntimeScriptable instance = null;

    static string generatorText;

    public Text debugText;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void CompileAndRun()
	{
        generatorText = GrammarGenerator._FullGameScript;
        //generatorText = generatorText.Replace("\n", " ");
        Debug.Log(generatorText);
        Debug.Log(GrammarGenerator._FullGameScript);
        StopAllCoroutines();
        _program = PrototypeCompiler.Compile(GrammarGenerator._FullGameScript); //move this to the game scene and load asyncronously
        StartCoroutine(_program.Run());
    }

    public void DebugRun(GameObject debugtext)
    {
        string generatorText2 = debugtext.GetComponent<InputField>().text;
        Debug.Log("..." + generatorText2);
        StopAllCoroutines();
        _program = PrototypeCompiler.Compile(generatorText2); 
        StartCoroutine(_program.Run());

        //GrammarGenerator._FullGameScript = text.text;
        //SceneManager.LoadScene("Loading");
    }
}
/*
public class ProportionValue<T>
{
    public double Proportion
    {
        get;
        set;
    }

    public T Value
    {
        get;
        set;
    }
}

public static class ProportionValue
{
    public static ProportionValue<T> Create<T>(double proportion, T value)
    {
        return new ProportionValue<T>
        {
            Proportion = proportion,
            Value = value
        };
    }

    static System.Random random = new System.Random();
    public static T ChooseByRandom<T>(this IEnumerable<ProportionValue<T>> collection)
    {

        double rnd = random.NextDouble();
        foreach (var item in collection)
        {
            if (rnd < item.Proportion)
            {
                return item.Value;
            }
            rnd -= item.Proportion;
        }

        throw new InvalidOperationException("The proportions in the collection do not add up to 1.");
    }
}
*/