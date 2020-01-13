using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;

public class RuntimeScriptable : MonoBehaviour 
{
	private PrototypeProgram _program;

    static RuntimeScriptable instance = null;

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
        string code = text.text;
        StopAllCoroutines();
		_program = PrototypeCompiler.Compile(code); //.compile() returns a PrototypeProgram object. We give it the text from the input - soon to be seperate screen.
        //StartCoroutine(_program.Run(gameObject));
        StartCoroutine(_program.Run());
        //Debug.Log(code);
    }

}
