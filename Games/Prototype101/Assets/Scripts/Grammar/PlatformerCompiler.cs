using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.Collections.Generic;

public class PlatformerCompiler
{

    private List<PlatformerProgram.IElement> _elements;
    private List<PlatformerProgram.IElement> Elements
    {
        get
        {
            return _elements;
        }
    }

    public PlatformerCompiler()
    {
        _elements = new List<PlatformerProgram.IElement>();
    }

    public static PlatformerProgram Compile(string source)
    {
        AntlrInputStream antlerStream = new AntlrInputStream(source);
        PlatformerMapLexer lexer = new PlatformerMapLexer(antlerStream);
        CommonTokenStream tokenStream = new CommonTokenStream(lexer);
        PlatformerMapParser parser = new PlatformerMapParser(tokenStream);

        parser.prog(); // <-- compile happens here (see .g4 file)

        PlatformerCompiler compiler = parser.Compiler;
        PlatformerProgram program = new PlatformerProgram(compiler.Elements);

        return program;
    }

    public PlatformerCompiler CreatePathStart()
    {
        PlatformerProgram.StartSegment startSegment = new PlatformerProgram.StartSegment();
        _elements.Add(startSegment);

        return this;
    }

    public PlatformerCompiler CreateFlatPath()
    {
        PlatformerProgram.FlatSegment flatSegment = new PlatformerProgram.FlatSegment();
        _elements.Add(flatSegment);

        return this;
    }

    public PlatformerCompiler CreateLowPlatform()
    {
        PlatformerProgram.LowPlatSegment lowPlatSegment = new PlatformerProgram.LowPlatSegment();
        _elements.Add(lowPlatSegment);

        return this;
    }

    public PlatformerCompiler CreateHighPlatform()
    {
        PlatformerProgram.HighPlatSegment highPlatSegment = new PlatformerProgram.HighPlatSegment();
        _elements.Add(highPlatSegment);

        return this;
    }

    public PlatformerCompiler CreatePathGap()
    {
        PlatformerProgram.GapSegment gapSegment = new PlatformerProgram.GapSegment();
        _elements.Add(gapSegment);

        return this;
    }

    public PlatformerCompiler CreateFinishLine()
    {
        PlatformerProgram.FinalSegment finalSegment = new PlatformerProgram.FinalSegment();
        _elements.Add(finalSegment);

        return this;
    }
}
