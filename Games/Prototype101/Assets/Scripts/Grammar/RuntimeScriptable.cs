using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class RuntimeScriptable : MonoBehaviour 
{
	private PrototypeProgram _program;

    static RuntimeScriptable instance = null;

    static string generatorText;

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

    public void CompileAndRun(Text text)
	{
        //int maxIterations = 20; a) for debugging, b) should be moved to game scene
        Debug.Log(text.text);
        generatorText = text.text;
        //string code = text.text + GeneratePath(maxIterations); //move GeneratePath to game scene
        StopAllCoroutines();
		_program = PrototypeCompiler.Compile(generatorText); //move this to the game scene and load asyncronously
        StartCoroutine(_program.Run());
    }

    //only public for testing:
    public void GeneratePath(int maxIterations) {
        //if wanting to customise the way the path is generated such as the number of iterations or the probabilities, then what?

        var rewriteS = new[]
        {
            ProportionValue.Create(0.1, "ffF"),
            ProportionValue.Create(0.45, "ffP"),
            ProportionValue.Create(0.45, "ffG"),
        };

        var rewriteP = new[]
        {
            ProportionValue.Create(0.1, "pP"),
            ProportionValue.Create(0.3, "pH"),
            ProportionValue.Create(0.3, "pG"),
            ProportionValue.Create(0.3, "pF"),
        };

        var rewriteH = new[]
        {
            ProportionValue.Create(0.1, "hH"),
            ProportionValue.Create(0.1, "hP"),
            ProportionValue.Create(0.1, "hF"),
            ProportionValue.Create(0.1, "hG"),

            ProportionValue.Create(0.15, "hghH"),
            ProportionValue.Create(0.15, "hghP"),
            ProportionValue.Create(0.15, "hghF"),
            ProportionValue.Create(0.15, "hghG"),
        };

        var rewriteF = new[]
        {
            ProportionValue.Create(0.2, "fF"),
            ProportionValue.Create(0.4, "fP"),
            ProportionValue.Create(0.4, "fG"),
        };

        var rewriteG = new[]
        {
            ProportionValue.Create(0.2, "gfP"),
            ProportionValue.Create(0.3, "gfG"),
            ProportionValue.Create(0.5, "gfF"),
        };

        string path = "S";

        //path += ""; //that appends - how to replace...??? Will I need two strings at once? The current finished iteration and the currently being edited one??

        string lastString = "S";
        string curString = "";

        for (int i = 0; i < maxIterations; i++)
        {

            //curString = lastString;
            
            foreach (char c in lastString) {
                //for each char in string:
                switch (c)
                {
                    case 'S':
                        curString += rewriteS.ChooseByRandom();
                        break;
                    case 'F':
                        curString += rewriteF.ChooseByRandom();
                        break;
                    case 'P':
                        curString += rewriteP.ChooseByRandom();
                        break;
                    case 'H':
                        curString += rewriteH.ChooseByRandom();
                        break;
                    case 'G':
                        curString += rewriteG.ChooseByRandom();
                        break;
                    default:
                        //not a non-terminal symbol
                        curString += c;
                        break;

                }
            }

            //for each iteration, cur string = concatenate the combination of string returns from choosebyrandom and any terminals that aren't changed
            lastString = curString;
            curString = "";
        }


        //return path;
        Debug.Log(lastString); //still need to append a finish line segment

    }
}

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
