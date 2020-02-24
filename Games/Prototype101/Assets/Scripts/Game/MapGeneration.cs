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

    private enum DominantDirection { NORTH, SOUTH, EAST, WEST }
    private DominantDirection domDir;
    //private GameProgram.SkillLevel difficulty;

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
    public IEnumerator GeneratePlatformerMap(GameProgram.MapSize mapSize)
    {
        //Randomly choose the number of rooms (from a range, based on size)
        int iterations = 0;
        if (mapSize == GameProgram.MapSize.Small) { iterations = 20; }
        else if (mapSize == GameProgram.MapSize.Medium) { iterations = 30; }
        else if (mapSize == GameProgram.MapSize.Large) { iterations = 40; }

        string path = PlatformerPathString(iterations);
        //StopAllCoroutines(); //feel like keeping this will cause problems cause this particular script iw a coroutine

        Debug.Log("path: " + path);

        _pProgram = PlatformerCompiler.Compile(path);
        //StartCoroutine(_pProgram.Run());
        yield return _pProgram.Run();
    }

    public IEnumerator GenerateDungeonMap(GameProgram.MapSize mapSize) {

        //Randomly choose dominant direction
        domDir = DominantDirection.NORTH;

        //Randomly choose the number of rooms (from a range, based on size)
        int maxRooms = 0;
        if (mapSize == GameProgram.MapSize.Small) { maxRooms = 10; }
        else if (mapSize == GameProgram.MapSize.Medium) { maxRooms = 10; }
        else if (mapSize == GameProgram.MapSize.Large) { maxRooms = 10; }

        //Randomly choose the number of iterations required to build the corridor
        //(is it possibly to do something like always using a multiple of four or something = a complete corridor? Because can't end a corridor in the middle of a tuple)
        int maxIterations = 10;

        //build a random corridor to connection each room:
        string path = "";

        for (int i = 0; i < maxRooms; i++)
        {
            string firstChar;
            if(i == 0) { firstChar = "z"; }
            else { firstChar = "r"; }
            path += DungeonPathString(maxIterations, firstChar);
            //path += "r";
        }

        //StopAllCoroutines(); //feel like keeping this will cause problems cause this particular script iw a coroutine
        //_dProgram = DungeonCompiler.Compile(path);
        //yield return _dProgram.Run();

        //debugging:
        Debug.Log(path);
        yield return null;
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

    private string DungeonPathString(int maxIterations, string firstChar)
    {
        //Remember: Proportions need to total 1

        //Need a different set of rewrite options for each different dominant direction
        //all chars to be rewritten: z (initial room), fghi, jklm, nsew

        //initial room
        var rewriteZn = new[]
        {
            ProportionValue.Create(0.33, "aj.F"),
            ProportionValue.Create(0.33, "cl.H"),
            ProportionValue.Create(0.34, "dm.I"),
        };

        var rewriteZs = new[]
        {
            ProportionValue.Create(0.33, "bk.G"),
            ProportionValue.Create(0.33, "cl.H"),
            ProportionValue.Create(0.34, "dm.I"),
        };

        var rewriteZe = new[]
        {
            ProportionValue.Create(0.33, "aj.F"),
            ProportionValue.Create(0.33, "bk.G"),
            ProportionValue.Create(0.34, "cl.H"),
        };

        var rewriteZw = new[]
        {
            ProportionValue.Create(0.33, "aj.F"),
            ProportionValue.Create(0.33, "bk.G"),
            ProportionValue.Create(0.34, "dm.I"),
        };

        //subsequent rooms room
        var rewriteRn = new[]
        {
            ProportionValue.Create(0.33, "rj.F"),
            ProportionValue.Create(0.33, "rl.H"),
            ProportionValue.Create(0.34, "rm.I"),
        };

        var rewriteRs = new[]
        {
            ProportionValue.Create(0.33, "rk.G"),
            ProportionValue.Create(0.33, "rl.H"),
            ProportionValue.Create(0.34, "rm.I"),
        };

        var rewriteRe = new[]
        {
            ProportionValue.Create(0.33, "rj.F"),
            ProportionValue.Create(0.33, "rk.G"),
            ProportionValue.Create(0.34, "rl.H"),
        };

        var rewriteRw = new[]
        {
            ProportionValue.Create(0.33, "rj.F"),
            ProportionValue.Create(0.33, "rk.G"),
            ProportionValue.Create(0.34, "rm.I"),
        };

        //entry
        //Fn - fnN, feE, fwW
        var rewriteFn = new[]
        {
            ProportionValue.Create(0.33, "fnN"),
            ProportionValue.Create(0.33, "feE"),
            ProportionValue.Create(0.34, "fwW"),
        };
        //Fe - fnN, feE, fsS
        var rewriteFe = new[]
        {
            ProportionValue.Create(0.33, "fnN"),
            ProportionValue.Create(0.33, "feE"),
            ProportionValue.Create(0.34, "fsS"),
        };
        //Fw - fnN, fsS, fwW
        var rewriteFw = new[]
        {
            ProportionValue.Create(0.33, "fnN"),
            ProportionValue.Create(0.33, "fwW"),
            ProportionValue.Create(0.34, "fsS"),
        };
        //Hn - hnN, heE, hwW
        var rewriteHn = new[]
        {
            ProportionValue.Create(0.33, "hnN"),
            ProportionValue.Create(0.33, "heE"),
            ProportionValue.Create(0.34, "hwW"),
        };
        //Hs - hsS, heE, hwW
        var rewriteHs = new[]
        {
            ProportionValue.Create(0.33, "hsS"),
            ProportionValue.Create(0.33, "heE"),
            ProportionValue.Create(0.34, "hwW"),
        };
        //He - hnN, heE, hsS
        var rewriteHe = new[]
        {
            ProportionValue.Create(0.33, "hnN"),
            ProportionValue.Create(0.33, "heE"),
            ProportionValue.Create(0.34, "hsS"),
        };
        //Gs - gsS, geE, gwW
        var rewriteGs = new[]
        {
            ProportionValue.Create(0.33, "gsS"),
            ProportionValue.Create(0.33, "geE"),
            ProportionValue.Create(0.34, "gwW"),
        };
        //Ge - gnN, geE, gsS
        var rewriteGe = new[]
        {
            ProportionValue.Create(0.33, "gnN"),
            ProportionValue.Create(0.33, "geE"),
            ProportionValue.Create(0.34, "gsS"),
        };
        //Gw - gnN, gsS, gwW
        var rewriteGw = new[]
        {
            ProportionValue.Create(0.33, "gnN"),
            ProportionValue.Create(0.33, "gsS"),
            ProportionValue.Create(0.34, "gwW"),
        };
        //In - inN, ieE, iwW
        var rewriteIn = new[]
        {
            ProportionValue.Create(0.33, "inN"),
            ProportionValue.Create(0.33, "ieE"),
            ProportionValue.Create(0.34, "iwW"),
        };
        //Is - isS, ieE, iwW
        var rewriteIs = new[]
        {
            ProportionValue.Create(0.33, "isS"),
            ProportionValue.Create(0.33, "ieE"),
            ProportionValue.Create(0.34, "iwW"),
        };
        //Iw - inN, isS, iwW
        var rewriteIw = new[]
        {
            ProportionValue.Create(0.33, "isS"),
            ProportionValue.Create(0.33, "inN"),
            ProportionValue.Create(0.34, "iwW"),
        };

        //direction
        //Nn - nj.F, nl.H, nm.I
        var rewriteNn = new[]
        {
            ProportionValue.Create(0.33, "nj.F"),
            ProportionValue.Create(0.33, "nl.H"),
            ProportionValue.Create(0.34, "nm.I"),
        };
        //Ne - nj.F, nl.H, nk.G
        var rewriteNe = new[]
        {
            ProportionValue.Create(0.33, "nj.F"),
            ProportionValue.Create(0.33, "nl.H"),
            ProportionValue.Create(0.34, "nk.G"),
        };
        //Nw - nj.F, nm.I, nk.G
        var rewriteNw = new[]
        {
            ProportionValue.Create(0.33, "nj.F"),
            ProportionValue.Create(0.33, "nm.I"),
            ProportionValue.Create(0.34, "nk.G"),
        };
        //En - ej.F, el.H, em.I
        var rewriteEn = new[]
        {
            ProportionValue.Create(0.33, "ej.F"),
            ProportionValue.Create(0.33, "el.H"),
            ProportionValue.Create(0.34, "em.I"),
        };
        //Es - em.I, ek.G, el.H
        var rewriteEs = new[]
        {
            ProportionValue.Create(0.33, "ek.G"),
            ProportionValue.Create(0.33, "el.H"),
            ProportionValue.Create(0.34, "em.I"),
        };
        //Ee - ej.F, el.H, ek.G
        var rewriteEe = new[]
        {
            ProportionValue.Create(0.33, "ek.G"),
            ProportionValue.Create(0.33, "el.H"),
            ProportionValue.Create(0.34, "ej.F"),
        };
        //Ss - sm.I, sk.G, sl.H
        var rewriteSs = new[]
        {
            ProportionValue.Create(0.33, "sk.G"),
            ProportionValue.Create(0.33, "sl.H"),
            ProportionValue.Create(0.34, "sm.I"),
        };
        //Sw - sj.F, sm.I, sk.G
        var rewriteSw = new[]
        {
            ProportionValue.Create(0.33, "sk.G"),
            ProportionValue.Create(0.33, "sj.F"),
            ProportionValue.Create(0.34, "sm.I"),
        };
        //Se - sj.F, sl.H, sk.G
        var rewriteSe = new[]
        {
            ProportionValue.Create(0.33, "sk.G"),
            ProportionValue.Create(0.33, "sj.F"),
            ProportionValue.Create(0.34, "sl.H"),
        };
        //Ww - wj.F, wm.I, wk.G
        var rewriteWw = new[]
        {
            ProportionValue.Create(0.33, "wk.G"),
            ProportionValue.Create(0.33, "wj.F"),
            ProportionValue.Create(0.34, "wm.I"),
        };
        //Wn - wj.F, wl.H, wm.I
        var rewriteWn = new[]
        {
            ProportionValue.Create(0.33, "wl.H"),
            ProportionValue.Create(0.33, "wj.F"),
            ProportionValue.Create(0.34, "wm.I"),
        };
        //Ws - wm.I, wk.G, wl.H
        var rewriteWs = new[]
        {
            ProportionValue.Create(0.33, "wl.H"),
            ProportionValue.Create(0.33, "wk.G"),
            ProportionValue.Create(0.34, "wm.I"),
        };



        string lastString = firstChar;
        string curString = "";

        for (int i = 0; i < maxIterations; i++)
        {

            //curString = lastString;

            foreach (char c in lastString)
            {
                if (domDir == DominantDirection.NORTH)
                {
                    switch (c)
                    {
                        case 'I':
                            curString += rewriteIn.ChooseByRandom();
                            break;
                        case 'R':
                            curString += rewriteRn.ChooseByRandom();
                            break;
                        case 'F':
                            curString += rewriteFn.ChooseByRandom();
                            break;
                        case 'Z':
                            curString += rewriteZn.ChooseByRandom();
                            break;
                        case 'W':
                            curString += rewriteWn.ChooseByRandom();
                            break;
                        case 'E':
                            curString += rewriteEn.ChooseByRandom();
                            break;
                        case 'N':
                            curString += rewriteNn.ChooseByRandom();
                            break;
                        case 'H':
                            curString += rewriteHn.ChooseByRandom();
                            break;
                        default: //not a non-terminal symbol
                            curString += c;
                            break;
                    }
                }
                else if (domDir == DominantDirection.SOUTH)
                {
                    switch (c)
                    {
                        case 'I':
                            curString += rewriteIs.ChooseByRandom();
                            break;
                        case 'R':
                            curString += rewriteRs.ChooseByRandom();
                            break;
                        case 'G':
                            curString += rewriteGs.ChooseByRandom();
                            break;
                        case 'Z':
                            curString += rewriteZs.ChooseByRandom();
                            break;
                        case 'W':
                            curString += rewriteWs.ChooseByRandom();
                            break;
                        case 'E':
                            curString += rewriteEs.ChooseByRandom();
                            break;
                        case 'S':
                            curString += rewriteSs.ChooseByRandom();
                            break;
                        case 'H':
                            curString += rewriteHs.ChooseByRandom();
                            break;
                        default: //not a non-terminal symbol
                            curString += c;
                            break;
                    }
                }
                else if (domDir == DominantDirection.EAST)
                {
                    switch (c)
                    {
                        case 'F':
                            curString += rewriteFe.ChooseByRandom();
                            break;
                        case 'R':
                            curString += rewriteRe.ChooseByRandom();
                            break;
                        case 'G':
                            curString += rewriteGe.ChooseByRandom();
                            break;
                        case 'Z':
                            curString += rewriteZe.ChooseByRandom();
                            break;
                        case 'N':
                            curString += rewriteNe.ChooseByRandom();
                            break;
                        case 'E':
                            curString += rewriteEe.ChooseByRandom();
                            break;
                        case 'S':
                            curString += rewriteSe.ChooseByRandom();
                            break;
                        case 'H':
                            curString += rewriteHe.ChooseByRandom();
                            break;
                        default: //not a non-terminal symbol
                            curString += c;
                            break;
                    }
                }
                else if (domDir == DominantDirection.WEST)
                {
                    switch (c)
                    {
                        case 'F':
                            curString += rewriteFw.ChooseByRandom();
                            break;
                        case 'R':
                            curString += rewriteRw.ChooseByRandom();
                            break;
                        case 'G':
                            curString += rewriteGw.ChooseByRandom();
                            break;
                        case 'Z':
                            curString += rewriteZw.ChooseByRandom();
                            break;
                        case 'N':
                            curString += rewriteNw.ChooseByRandom();
                            break;
                        case 'W':
                            curString += rewriteWw.ChooseByRandom();
                            break;
                        case 'S':
                            curString += rewriteSw.ChooseByRandom();
                            break;
                        case 'I':
                            curString += rewriteIw.ChooseByRandom();
                            break;
                        default: //not a non-terminal symbol
                            curString += c;
                            break;
                    }
                }
            }

            //for each iteration, cur string = concatenate the combination of string returns from choosebyrandom and any terminals that aren't changed
            lastString = curString;
            curString = "";
        }

        return lastString;
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
