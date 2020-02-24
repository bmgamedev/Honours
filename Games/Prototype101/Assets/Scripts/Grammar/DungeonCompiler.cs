using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;

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
        DungeonProgram.Direction exitDirection = DungeonProgram.Direction.North;
        string dirSouth = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.South);
        string dirEast = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.East);
        string dirWest = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.West);

        if (exitDir.ToUpper().Equals(dirSouth.ToUpper()))
        {
            exitDirection = DungeonProgram.Direction.South;
        }
        else if (exitDir.ToUpper().Equals(dirEast.ToUpper()))
        {
            exitDirection = DungeonProgram.Direction.East;
        }
        else if (exitDir.ToUpper().Equals(dirWest.ToUpper()))
        {
            exitDirection = DungeonProgram.Direction.West;
        }

        DungeonProgram.InitialRoom initialRoom = new DungeonProgram.InitialRoom(exitDirection);
        _elements.Add(initialRoom);

        return this;
    }

    public DungeonCompiler CreateRoom(string entryDir, string exitDir)
    {
        DungeonProgram.Direction exitDirection = DungeonProgram.Direction.North;
        string dirSouth = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.South);
        string dirEast = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.East);
        string dirWest = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.West);

        if (exitDir.ToUpper().Equals(dirSouth.ToUpper()))
        {
            exitDirection = DungeonProgram.Direction.South;
        }
        else if (exitDir.ToUpper().Equals(dirEast.ToUpper()))
        {
            exitDirection = DungeonProgram.Direction.East;
        }
        else if (exitDir.ToUpper().Equals(dirWest.ToUpper()))
        {
            exitDirection = DungeonProgram.Direction.West;
        }

        DungeonProgram.Direction entryDirection = DungeonProgram.Direction.North;

        if (entryDir.ToUpper().Equals(dirSouth.ToUpper()))
        {
            entryDirection = DungeonProgram.Direction.South;
        }
        else if (entryDir.ToUpper().Equals(dirEast.ToUpper()))
        {
            entryDirection = DungeonProgram.Direction.East;
        }
        else if (entryDir.ToUpper().Equals(dirWest.ToUpper()))
        {
            entryDirection = DungeonProgram.Direction.West;
        }

        DungeonProgram.RoomSegment roomSegment = new DungeonProgram.RoomSegment(entryDirection, exitDirection);
        _elements.Add(roomSegment);

        return this;
    }

    public DungeonCompiler CreateFirstPiece(string entryDir, string corrDir)
    {
        DungeonProgram.Direction corrDirection = DungeonProgram.Direction.North;
        string dirSouth = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.South);
        string dirEast = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.East);
        string dirWest = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.West);

        if (corrDir.ToUpper().Equals(dirSouth.ToUpper()))
        {
            corrDirection = DungeonProgram.Direction.South;
        }
        else if (corrDir.ToUpper().Equals(dirEast.ToUpper()))
        {
            corrDirection = DungeonProgram.Direction.East;
        }
        else if (corrDir.ToUpper().Equals(dirWest.ToUpper()))
        {
            corrDirection = DungeonProgram.Direction.West;
        }

        DungeonProgram.Direction entryDirection = DungeonProgram.Direction.North;

        if (entryDir.ToUpper().Equals(dirSouth.ToUpper()))
        {
            entryDirection = DungeonProgram.Direction.South;
        }
        else if (entryDir.ToUpper().Equals(dirEast.ToUpper()))
        {
            entryDirection = DungeonProgram.Direction.East;
        }
        else if (entryDir.ToUpper().Equals(dirWest.ToUpper()))
        {
            entryDirection = DungeonProgram.Direction.West;
        }

        DungeonProgram.FirstCorrSegment firstCorrSegment = new DungeonProgram.FirstCorrSegment(entryDirection, corrDirection);
        _elements.Add(firstCorrSegment); 

        return this;
    }

    public DungeonCompiler CreateSecondPiece(string corrDir, string exitDir)
    {
        DungeonProgram.Direction exitDirection = DungeonProgram.Direction.North;
        string dirSouth = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.South);
        string dirEast = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.East);
        string dirWest = Enum.GetName(typeof(DungeonProgram.Direction), DungeonProgram.Direction.West);

        if (exitDir.ToUpper().Equals(dirSouth.ToUpper()))
        {
            exitDirection = DungeonProgram.Direction.South;
        }
        else if (exitDir.ToUpper().Equals(dirEast.ToUpper()))
        {
            exitDirection = DungeonProgram.Direction.East;
        }
        else if (exitDir.ToUpper().Equals(dirWest.ToUpper()))
        {
            exitDirection = DungeonProgram.Direction.West;
        }

        DungeonProgram.Direction corrDirection = DungeonProgram.Direction.North;

        if (corrDir.ToUpper().Equals(dirSouth.ToUpper()))
        {
            corrDirection = DungeonProgram.Direction.South;
        }
        else if (corrDir.ToUpper().Equals(dirEast.ToUpper()))
        {
            corrDirection = DungeonProgram.Direction.East;
        }
        else if (corrDir.ToUpper().Equals(dirWest.ToUpper()))
        {
            corrDirection = DungeonProgram.Direction.West;
        }

        DungeonProgram.SecondCorrSegment secondCorrSegment = new DungeonProgram.SecondCorrSegment(corrDirection, exitDirection);
        _elements.Add(secondCorrSegment);

        return this;
    }
}
