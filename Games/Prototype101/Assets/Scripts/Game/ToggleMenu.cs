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

    //private string fieldValue;

    void Start () {
        PopulateDictionary();
        toggleGroup = GetComponent<ToggleGroup>();
        //if(IndexNum < 0) { IndexNum = 0; }

        /*if (grammarInputDict.ContainsKey(CurrentSelection.gameObject.name))
        {
            GrammarInput = grammarInputDict[CurrentSelection.gameObject.name];
        }
        else { GrammarInput = ""; }
        GrammarGenerator.UpdateScript(IndexNum, GrammarInput);*/
    }

    public void UpdateGrammarInput()
    {
        //Debug.Log(CurrentSelection.gameObject.GetComponentInChildren<Text>().text);

        //DECIDED AGAINST THIS WAY:
        //fieldValue = CurrentSelection.gameObject.name;
        //Can be either the text field value: CurrentSelection.gameObject.GetComponentInChildren<Text>().text;
        //or the toggle object name CurrentSelection.gameObject.name;
        //currently opting for name so that the display text can be more descriptive if needed

        if (grammarInputDict.ContainsKey(CurrentSelection.gameObject.name))
        {
            GrammarInput = grammarInputDict[CurrentSelection.gameObject.name];
        }
        else { GrammarInput = ""; }
        GrammarGenerator.PopulateScript(GrammarInput);
    }

    //programmatically set a toggle. Not necessary in this instance (toggles index from 0)
    /*public void SelectToggle(int id) {
        var toggles = toggleGroup.GetComponentsInChildren<Toggle>();
        toggles[id].isOn = true;
    }*/

    private void PopulateDictionary() {
        //Probably not the best way to do this but just going to keep a dictionary of toggle gameobject names and corresponding grammar input

        //game types:
        grammarInputDict.Add("GTPlatformer", "platformer");
        grammarInputDict.Add("GTDungeon", "dungeon");
        grammarInputDict.Add("GTVerticalScroller", "vertical scroller");

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
        grammarInputDict.Add("EShooting", "projectile enemy");
        grammarInputDict.Add("EMelee", "melee enemy");
        grammarInputDict.Add("EBoth", "varied enemies");

        //map size
        grammarInputDict.Add("MSmall", "small map");
        grammarInputDict.Add("MMedium", "medium map");
        grammarInputDict.Add("MLarge", "large map");
    }
}
