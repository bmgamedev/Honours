using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GrammarGenerator {

    public static List<string> _GameScriptElements = new List<string>();

    public static void PopulateScript(string value) { _GameScriptElements.Add(value); }

    public static void ClearScript() { _GameScriptElements.Clear(); }

    public static void UpdateScript(int i, string value) {
        _GameScriptElements[_GameScriptElements.FindIndex(ind => ind.Equals(i))] = value;
    }

}
