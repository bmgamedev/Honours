using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCompiler
{

    private List<DungeonProgram.IElement> _elements;
    private List<DungeonProgram.IElement> Elements
    {
        get
        {
            return _elements;
        }
    }

    public DungeonCompiler()
    {
        _elements = new List<DungeonProgram.IElement>();
    }

    public static DungeonProgram Compile(string source)
    {
        AntlrInputStream antlerStream = new AntlrInputStream(source);
        DungeonMapLexer lexer = new DungeonMapLexer(antlerStream);
        CommonTokenStream tokenStream = new CommonTokenStream(lexer);
        DungeonMapParser parser = new DungeonMapParser(tokenStream);

        parser.prog(); // <-- compile happens here (see .g4 file)

        DungeonCompiler compiler = parser.Compiler;
        DungeonProgram program = new DungeonProgram(compiler.Elements);

        return program;
    }

    public DungeonCompiler CreateInitialRoom(string exitDir)
    {
        DungeonProgram.Direction exitDirection;// = DungeonProgram.Direction.North;
        /*string dirSouth = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.South);
        string dirEast = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.East);
        string dirWest = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.West);*/

        if (exitDir.Equals("k"))
        {
            exitDirection = DungeonProgram.Direction.South;
        }
        else if (exitDir.Equals("l"))
        {
            exitDirection = DungeonProgram.Direction.East;
        }
        else if (exitDir.Equals("m"))
        {
            exitDirection = DungeonProgram.Direction.West;
        }
        else
        {
            exitDirection = DungeonProgram.Direction.North;
        }

        DungeonProgram.InitialRoom initialRoom = new DungeonProgram.InitialRoom(exitDirection);
        _elements.Add(initialRoom);

        return this;
    }

    public DungeonCompiler CreateRoom(string entryDir, string exitDir)
    {
        DungeonProgram.Direction exitDirection;// = DungeonProgram.Direction.North;
        /*string dirSouth = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.South);
        string dirEast = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.East);
        string dirWest = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.West);*/

        if (exitDir.Equals("k"))
        {
            exitDirection = DungeonProgram.Direction.South;
        }
        else if (exitDir.Equals("l"))
        {
            exitDirection = DungeonProgram.Direction.East;
        }
        else if (exitDir.Equals("m"))
        {
            exitDirection = DungeonProgram.Direction.West;
        }
        else
        {
            exitDirection = DungeonProgram.Direction.North;
        }

        DungeonProgram.Direction entryDirection;
        if (entryDir.Equals("g"))
        {
            entryDirection = DungeonProgram.Direction.South;
        }
        else if (entryDir.Equals("h"))
        {
            entryDirection = DungeonProgram.Direction.East;
        }
        else if (entryDir.Equals("i"))
        {
            entryDirection = DungeonProgram.Direction.West;
        }
        else
        {
            entryDirection = DungeonProgram.Direction.North;
        }

        DungeonProgram.RoomSegment roomSegment = new DungeonProgram.RoomSegment(entryDirection, exitDirection);
        _elements.Add(roomSegment);

        return this;
    }

    public DungeonCompiler CreateFirstPiece(string entryDir, string corrDir)
    {
        //Debug.Log("COMPILER entryDir: " + entryDir + ", corrDir: " + corrDir);

        DungeonProgram.Direction corrDirection;// = DungeonProgram.Direction.North;
        /*string dirSouth = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.South);
        string dirEast = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.East);
        string dirWest = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.West);*/

        if (corrDir.Equals("s"))
        {
            corrDirection = DungeonProgram.Direction.South;
        }
        else if (corrDir.Equals("e"))
        {
            corrDirection = DungeonProgram.Direction.East;
        }
        else if (corrDir.Equals("w"))
        {
            corrDirection = DungeonProgram.Direction.West;
        }
        else
        {
            corrDirection = DungeonProgram.Direction.North;
        }

        DungeonProgram.Direction entryDirection;// = DungeonProgram.Direction.North;

        if (entryDir.Equals("g"))
        {
            entryDirection = DungeonProgram.Direction.South;
        }
        else if (entryDir.Equals("h"))
        {
            entryDirection = DungeonProgram.Direction.East;
        }
        else if (entryDir.Equals("i"))
        {
            entryDirection = DungeonProgram.Direction.West;
        }
        else
        {
            entryDirection = DungeonProgram.Direction.North;
        }

        DungeonProgram.FirstCorrSegment firstCorrSegment = new DungeonProgram.FirstCorrSegment(entryDirection, corrDirection);
        _elements.Add(firstCorrSegment); 

        return this;
    }

    public DungeonCompiler CreateSecondPiece(string corrDir, string exitDir)
    {
        DungeonProgram.Direction exitDirection;// = DungeonProgram.Direction.North;
        /*string dirSouth = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.South);
        string dirEast = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.East);
        string dirWest = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.West);*/

        if (exitDir.Equals("k"))
        {
            exitDirection = DungeonProgram.Direction.South;
        }
        else if (exitDir.Equals("l"))
        {
            exitDirection = DungeonProgram.Direction.East;
        }
        else if (exitDir.Equals("m"))
        {
            exitDirection = DungeonProgram.Direction.West;
        }
        else
        {
            exitDirection = DungeonProgram.Direction.North;
        }

        DungeonProgram.Direction corrDirection;// = DungeonProgram.Direction.North;

        if (corrDir.Equals("s"))
        {
            corrDirection = DungeonProgram.Direction.South;
        }
        else if (corrDir.Equals("e"))
        {
            corrDirection = DungeonProgram.Direction.East;
        }
        else if (corrDir.Equals("w"))
        {
            corrDirection = DungeonProgram.Direction.West;
        }
        else
        {
            corrDirection = DungeonProgram.Direction.North;
        }

        DungeonProgram.SecondCorrSegment secondCorrSegment = new DungeonProgram.SecondCorrSegment(corrDirection, exitDirection);
        _elements.Add(secondCorrSegment);

        return this;
    }
}
