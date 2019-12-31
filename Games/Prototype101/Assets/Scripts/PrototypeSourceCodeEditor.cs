using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrototypeSourceCodeEditor : MonoBehaviour {
	
    //These are visible on the UI object.
    //runtimeScriptableObject is the turtle sprite w/ the runtimescriptable script on it
	public Text SourceCodeText;
	public RuntimeScriptable RuntimeScriptableObject;

	public void OnCompileAndRunClick()
	{
		/*if(RuntimeScriptableObject != null)
		{
			RuntimeScriptableObject.CompileAndRun(SourceCodeText.text); //When the "go"/compile and run button is clicked, take the text and pass it into the turtle's compile and run method
		}*/
	}
}
