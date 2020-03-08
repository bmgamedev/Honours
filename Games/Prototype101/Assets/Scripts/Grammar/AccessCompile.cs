using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCompile : MonoBehaviour {

    private GameObject runtimeScriptable;

	void Start () {
        runtimeScriptable = GameObject.Find("RuntimeScript");
	}
	
	// Update is called once per frame
	public void Compile () {
        if (runtimeScriptable != null)
        {
            runtimeScriptable.GetComponent<RuntimeScriptable>().CompileAndRun();
        }
	}
}
