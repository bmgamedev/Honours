using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGeneration : MonoBehaviour {

    static MapGeneration instance = null;

    private PlatformerProgram _pProgram;
    private DungeonProgram _dProgram;

    static public List<Vector3> _playerPositions = new List<Vector3>(); //Can't decided if I'm going to need to store multiple or not yet
    static public List<Vector3> _pickupPositions = new List<Vector3>();
    static public List<Vector3> _enemyPositions = new List<Vector3>();
    static public float enemyPaceDist;

    public List<Vector3> GetPlayerPositions() { return _playerPositions; }
    public List<Vector3> GetPickupPositions() { return _pickupPositions; }
    public List<Vector3> GetEnemyPositions() { return _enemyPositions; }
    public float GetEnemyPaceDist() { return enemyPaceDist; }

    public void SetPlayerPositions(List<Vector3> playerPos) { _playerPositions = playerPos; Debug.Log("mapG # player pos: " + _playerPositions.Count); }
    public void SetPickupPositions(List<Vector3> pickupPos) { _pickupPositions = pickupPos; }
    public void SetEnemyPositions(List<Vector3> enemyPos) { _enemyPositions = enemyPos; }
    public void SetEnemyPaceDist(float paceDist) { enemyPaceDist = paceDist; }

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

    //public void GeneratePlatformerMap(int iterations)
    public IEnumerator GeneratePlatformerMap(int iterations)
    {
        string path = PlatformerPathString(iterations);
        //StopAllCoroutines(); //feel like keeping this will cause problems cause this particular script iw a coroutine

        Debug.Log("path: " + path);

        _pProgram = PlatformerCompiler.Compile(path);
        //StartCoroutine(_pProgram.Run());
        yield return _pProgram.Run();
    }

    public void GenerateDungeonMap(int iterations) {
        /*
         string path = DungeonPathString(iterations);
        //StopAllCoroutines(); //feel like keeping this will cause problems cause this particular script iw a coroutine
        _dProgram = DungeonCompiler.Compile(path);
        StartCoroutine(_dProgram.Run());
         */
    }


    private string PlatformerPathString (int maxIterations)
    {
        //if wanting to customise the way the path is generated such as the number of iterations or the probabilities, then what?

        //TODO make the probabilities available for customisation with slider bars??
        var rewriteS = new[]
        {
            ProportionValue.Create(0.1, "sffF"),
            ProportionValue.Create(0.45, "sffP"),
            ProportionValue.Create(0.45, "sffG"),
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

        //string path = "S";

        //path += ""; //that appends - how to replace...??? Will I need two strings at once? The current finished iteration and the currently being edited one??

        string lastString = "S";
        string curString = "";

        for (int i = 0; i < maxIterations; i++)
        {

            //curString = lastString;

            foreach (char c in lastString)
            {
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

        //Debug.Log(lastString += "e"); //still need to append a finish line segment
        return lastString += "e";
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
