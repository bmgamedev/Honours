using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
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

    public DungeonCompiler CreateRoom()
    {
        DungeonProgram.RoomSegment roomSegment = new DungeonProgram.RoomSegment();
        _elements.Add(roomSegment);

        return this;
    }

    public DungeonCompiler CreateFirstPiece()
    {
        DungeonProgram.FirstCorrSegment firstCorrSegment = new DungeonProgram.FirstCorrSegment();
        _elements.Add(firstCorrSegment); 

        return this;
    }

    public DungeonCompiler CreateSecondPiece()
    {
        DungeonProgram.SecondCorrSegment secondCorrSegment = new DungeonProgram.SecondCorrSegment();
        _elements.Add(secondCorrSegment);

        return this;
    }
}
