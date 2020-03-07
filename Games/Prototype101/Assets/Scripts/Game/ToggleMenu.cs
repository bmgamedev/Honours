using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleMenu : MonoBehaviour {

    private ToggleGroup toggleGroup;
    private Dictionary<string, string> grammarInputDict = new Dictionary<string, string>();
    private string GrammarInput;

    public int IndexNum; 
    public Toggle CurrentSelection { get { return toggleGroup.ActiveToggles().FirstOrDefault(); } } //get the currently selected toggle

    void Start () {
        PopulateDictionary();
        toggleGroup = GetComponent<ToggleGroup>();
    }

    public void UpdateGrammarInput()
    {
        if (CurrentSelection != null)
        {
            if (grammarInputDict.ContainsKey(CurrentSelection.gameObject.name))
            {
                GrammarInput = grammarInputDict[CurrentSelection.gameObject.name];
            }
            else { GrammarInput = ""; }
            GrammarGenerator.PopulateScript(GrammarInput);
        }
    }
        

    private void PopulateDictionary() {
        //game types:
        grammarInputDict.Add("GTPlatformer", "platformer");
        grammarInputDict.Add("GTDungeon", "dungeon");
        //grammarInputDict.Add("GTVerticalScroller", "vertical scroller");

        //player setup:
        grammarInputDict.Add("1P", "players 1");
        grammarInputDict.Add("2P", "players 2");
        grammarInputDict.Add("3P", "players 3");
        grammarInputDict.Add("4P", "players 4");

        //game difficulty
        grammarInputDict.Add("DEasy", "easy difficulty");
        grammarInputDict.Add("DRegular", "regular difficulty");
        grammarInputDict.Add("DDifficult", "hard difficulty");

        //enemy types
        grammarInputDict.Add("EMoving", "moving enemy");
        grammarInputDict.Add("EStatic", "static enemy");
        grammarInputDict.Add("EBoth", "varied enemies");

        //map size
        grammarInputDict.Add("MSmall", "small");
        grammarInputDict.Add("MMedium", "medium");
        grammarInputDict.Add("MLarge", "large");
    }
}
