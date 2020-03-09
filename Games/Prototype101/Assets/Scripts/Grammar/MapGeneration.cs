using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGeneration : MonoBehaviour {

    static MapGeneration instance = null;

    private PlatformerProgram _pProgram;
    private DungeonProgram _dProgram;

    static public List<Vector3> _playerPositions = new List<Vector3>(); 
    static public List<Vector3> _pickupPositions = new List<Vector3>();
    static public List<Vector3> _enemyPositions = new List<Vector3>();
    static public List<string> _enemyAxes = new List<string>();

    private enum DominantDirection { NORTH, SOUTH, EAST, WEST }
    private DominantDirection domDir;

    public List<Vector3> GetPlayerPositions() { return _playerPositions; }
    public List<Vector3> GetPickupPositions() { return _pickupPositions; }
    public List<Vector3> GetEnemyPositions() { return _enemyPositions; }

    public void SetPlayerPositions(List<Vector3> playerPos) { _playerPositions = playerPos; }
    public void SetPickupPositions(List<Vector3> pickupPos) { _pickupPositions = pickupPos; }
    public void SetEnemyPositions(List<Vector3> enemyPos) { _enemyPositions = enemyPos; }

    public string GetDominantDirection()
    {
        if (domDir == DominantDirection.NORTH) { return "North"; }
        else if (domDir == DominantDirection.SOUTH) { return "South"; }
        else if (domDir == DominantDirection.EAST) { return "East"; }
        else { return "West"; }
    }

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

    public IEnumerator GeneratePlatformerMap(GameProgram.MapSize mapSize)
    {
        //Randomly choose the number of rooms (from a range, based on size)
        int iterations = 10;
        if (mapSize == GameProgram.MapSize.Small) { iterations = UnityEngine.Random.Range(30, 40); }
        else if (mapSize == GameProgram.MapSize.Medium) { iterations = UnityEngine.Random.Range(41, 60); ; }
        else if (mapSize == GameProgram.MapSize.Large) { iterations = UnityEngine.Random.Range(61, 80); }

        string path = PlatformerPathString(iterations);
        Debug.Log("path: " + path);

        _pProgram = PlatformerCompiler.Compile(path);
        yield return _pProgram.Run();
    }

    public IEnumerator GenerateDungeonMap(GameProgram.MapSize mapSize)
    {
        //Randomly choose dominant direction
        domDir = (DominantDirection)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(DominantDirection)).Length));

        //Randomly choose the number of rooms (from a range, based on size)
        int maxRooms = 1;
        if (mapSize == GameProgram.MapSize.Small) { maxRooms = UnityEngine.Random.Range(4, 6); }
        else if (mapSize == GameProgram.MapSize.Medium) { maxRooms = UnityEngine.Random.Range(7, 10); ; }
        else if (mapSize == GameProgram.MapSize.Large) { maxRooms = UnityEngine.Random.Range(11, 15); }

        int completedCorrSegments = 5;
        int maxIterations = (completedCorrSegments * 4) - 1;

        //build a random corridor to connection each room:
        string path = "";

        for (int i = 0; i < maxRooms; i++)
        {
            string firstChar;

            if (i == 0) { firstChar = "X"; }
            else { firstChar = "R"; }

            path += DungeonPathString(maxIterations, firstChar);
        }

        path += DungeonPathString(maxIterations, "Z");
        path = path.ToLower();

        Debug.Log(domDir);
        Debug.Log(path);

        //TESTING:
        //path = "aj.fnnj.fnnl.hnnm.innl.hnnj.fnnm.innj";                                                                       //Testing all DD:North connections
        //path = "bk.gssk.gssl.hssm.issl.hssk.jssm.issj";                                                                       //Testing all DD:South connections
        //path = "cl.heel.heek.geej.feek.geel.heej.feel";                                                                       //Testing all DD:East connections
        //path = "dm.iwwm.iwwk.gwwj.fwwk.gwwm.iwwj.fwwm";                                                                       //Testing all DD:West connections
        //path = "aj.fnnj.feej.fnnj.frm.iwwj.feel.hnnm.innj.frm.iwwm.innj.frm.innl.heej.frl.heej.fnnj.frm.iwwm.innj.fz";        //testing rooms going north
        //path = "bk.gssk.gssl.hssm.iwwk.grl.heel.hssk.grm.issl.heek.gwwm.iwwk.grl.hssm.issk.grl.heel.hssk.grm.issl.hssk.gz";   //testing rooms going south
        //path = "cl.heel.heel.hrj.fnnl.heel.hrk.gssl.hssl.hrj.feej.feel.hrj.feej.feek.geel.hz";                                //testing rooms going east
        //path = "dm.iwwm.iwwm.issm.irk.gssm.issm.iwwm.iwwm.irk.gssm.innj.fwwm.irj.fwwk.gwwk.gwwm.irj.fnnm.iwwm.iz";            //testing rooms going west

        _dProgram = DungeonCompiler.Compile(path);
        yield return _dProgram.Run();
    }


    private string PlatformerPathString (int maxIterations)
    {
        var rewriteS = new[]
        {
            ProportionValue.Create(0.33, "sffF"), 
            ProportionValue.Create(0.33, "sffP"), 
            ProportionValue.Create(0.34, "sffG"), 
        };

        var rewriteP = new[]
        {
            ProportionValue.Create(0.25, "pP"), 
            ProportionValue.Create(0.25, "pH"),
            ProportionValue.Create(0.25, "pG"), 
            ProportionValue.Create(0.25, "pF"), 
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
            ProportionValue.Create(0.33, "fF"), 
            ProportionValue.Create(0.33, "fP"), 
            ProportionValue.Create(0.34, "fG"), 
        };

        var rewriteG = new[]
        {
            ProportionValue.Create(0.33, "gfP"), 
            ProportionValue.Create(0.33, "gfG"), 
            ProportionValue.Create(0.34, "gfF"), 
        };

        string lastString = "S";
        string curString = "";

        for (int i = 0; i < maxIterations; i++)
        {
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

        return lastString += "e";
    }

    private string DungeonPathString(int maxIterations, string firstChar)
    {
        //Need a different set of rewrite options for each different dominant direction

        //initial room
        var rewriteXn = new[]
        {
            ProportionValue.Create(1, "aj.fnnj.F"),
        };

        var rewriteXs = new[]
        {
            ProportionValue.Create(1, "bk.gssk.G"),
        };

        var rewriteXe = new[]
        {
            ProportionValue.Create(1, "cl.heel.H"),
        };

        var rewriteXw = new[]
        {
            ProportionValue.Create(1, "dm.iwwm.I"),
        };

        //final room
        var rewriteZn = new[]
        {
            ProportionValue.Create(1.0, "nnj.fz"),
        };

        var rewriteZs = new[]
        {
            ProportionValue.Create(1.0, "ssk.gz"),
        };

        var rewriteZe = new[]
        {
            ProportionValue.Create(1.0, "eel.hz"),
        };

        var rewriteZw = new[]
        {
            ProportionValue.Create(1.0, "wwm.iz"),
        };

        //subsequent rooms room
        var rewriteRn = new[]
        {
            ProportionValue.Create(0.5, "nnj.frl.H"), //exit room east
            ProportionValue.Create(0.5, "nnj.frm.I"), //exit room west
        };

        var rewriteRs = new[]
        {
            ProportionValue.Create(0.5, "ssk.grl.H"), //exit room east
            ProportionValue.Create(0.5, "ssk.grm.I"), //exit room west
        };

        var rewriteRe = new[]
        {
            ProportionValue.Create(0.5, "eel.hrj.F"), //exit room north
            ProportionValue.Create(0.5, "eel.hrk.G"), //exit room south
        };

        var rewriteRw = new[]
        {
            ProportionValue.Create(0.5, "wwm.irj.F"), //exit room north
            ProportionValue.Create(0.5, "wwm.irk.G"), //exit room south
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
            ProportionValue.Create(0.5, "fnN"),
            ProportionValue.Create(0.5, "feE"),
        };
        //Fw - fnN, fsS, fwW
        var rewriteFw = new[]
        {
            ProportionValue.Create(0.5, "fnN"),
            ProportionValue.Create(0.5, "fwW"),
        };
        //Hn - hnN, heE, hwW
        var rewriteHn = new[]
        {
            ProportionValue.Create(0.5, "hnN"),
            ProportionValue.Create(0.5, "heE"),
        };
        //Hs - hsS, heE, hwW
        var rewriteHs = new[]
        {
            ProportionValue.Create(0.5, "hsS"),
            ProportionValue.Create(0.5, "heE"),
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
            ProportionValue.Create(0.5, "geE"),
            ProportionValue.Create(0.5, "gsS"),
        };
        //Gw - gnN, gsS, gwW
        var rewriteGw = new[]
        {
            ProportionValue.Create(0.5, "gsS"),
            ProportionValue.Create(0.5, "gwW"),
        };
        //In - inN, ieE, iwW
        var rewriteIn = new[]
        {
            ProportionValue.Create(0.5, "inN"),
            ProportionValue.Create(0.5, "iwW"),
        };
        //Is - isS, ieE, iwW
        var rewriteIs = new[]
        {
            ProportionValue.Create(0.5, "isS"),
            ProportionValue.Create(0.5, "iwW"),
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
            ProportionValue.Create(0.5, "nj.F"),
            ProportionValue.Create(0.5, "nl.H"),
        };
        //Nw - nj.F, nm.I, nk.G
        var rewriteNw = new[]
        {
            ProportionValue.Create(0.5, "nj.F"),
            ProportionValue.Create(0.5, "nm.I"),
        };
        //En - ej.F, el.H, em.I
        var rewriteEn = new[]
        {
            ProportionValue.Create(0.5, "ej.F"),
            ProportionValue.Create(0.5, "el.H"),
        };
        //Es - em.I, ek.G, el.H
        var rewriteEs = new[]
        {
            ProportionValue.Create(0.5, "ek.G"),
            ProportionValue.Create(0.5, "el.H"),
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
            ProportionValue.Create(0.5, "sk.G"),
            ProportionValue.Create(0.5, "sm.I"),
        };
        //Se - sj.F, sl.H, sk.G
        var rewriteSe = new[]
        {
            ProportionValue.Create(0.5, "sk.G"),
            ProportionValue.Create(0.5, "sl.H"),
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
            ProportionValue.Create(0.5, "wj.F"),
            ProportionValue.Create(0.5, "wm.I"),
        };
        //Ws - wm.I, wk.G, wl.H
        var rewriteWs = new[]
        {
            ProportionValue.Create(0.5, "wk.G"),
            ProportionValue.Create(0.5, "wm.I"),
        };



        string lastString = firstChar;
        string curString = "";

        for (int i = 0; i < maxIterations; i++)
        {
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
                        case 'X':
                            curString += rewriteXn.ChooseByRandom();
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
                        case 'X':
                            curString += rewriteXs.ChooseByRandom();
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
                        case 'X':
                            curString += rewriteXe.ChooseByRandom();
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
                        case 'X':
                            curString += rewriteXw.ChooseByRandom();
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
