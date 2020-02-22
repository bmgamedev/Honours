grammar PlatformerMap;

@parser::header {#pragma warning disable 3021}
@lexer::header {#pragma warning disable 3021}

@members
{
	public PlatformerCompiler Compiler = new PlatformerCompiler(); //this will be the compiler file in the Unity project
}

prog : elem+ ;

/// what constitutes a single creation element. Going to keep them seperated by newlines for ease (for now at least)
/// e.g. elem : (move | rotate) NEWLINE ;
elem : ( addStartSegment | addFlatPathSegment | addLowPlatformSegment | addHighPlatformSegment | addPathGapSegment | addFinishLineSegment ) NEWLINE ;

//build platformer path from segments
addStartSegment : START { Compiler.CreatePathStart(); };
addFlatPathSegment : FLATPATH { Compiler.CreateFlatPath(); };
addLowPlatformSegment : LOWPLATFORM { Compiler.CreateLowPlatform(); };
addHighPlatformSegment : HIGHPLATFORM { Compiler.CreateHighPlatform(); };
addPathGapSegment : PATHGAP { Compiler.CreatePathGap(); };
addFinishLineSegment : FINISHLINE { Compiler.CreateFinishLine(); };

//platformer path generation
START : ('s'|'S') ; //including capitals since the string isn't guaranteed to be fully rewritten if based on x iterations
FLATPATH : ('f'|'F') ;
LOWPLATFORM : ('p'|'P');
HIGHPLATFORM : ('h'|'H');
PATHGAP : ('g'|'G');
FINISHLINE : ('e'|'E') ; //todo: probably change this from talking about Finishing since it's destined to be infinite... one day

/// some basic definitions
INT : '-'? ('0'..'9')+ ;
NEWLINE:'\r'? '\n' ;
WS : [ \t\r\n]+ -> skip ;