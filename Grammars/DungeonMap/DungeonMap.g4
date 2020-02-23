grammar DungeonMap;

@parser::header {#pragma warning disable 3021}
@lexer::header {#pragma warning disable 3021}

@members
{
	public DungeonCompiler Compiler = new DungeonCompiler(); //this will be the compiler file in the Unity project
}

prog : elem+ ;

/// what constitutes a single creation element. Going to keep them seperated by newlines for ease (for now at least)
/// e.g. elem : (move | rotate) NEWLINE ;
elem : ( createInitialRoom | createFirstCorrSect | createSecondCorrSect | createRoom ) NEWLINE ;

//build dungeon map
createInitialRoom : INITROOM EXIT { Compiler.CreateInitialRoom(); };
createFirstCorrSect : ENTRY DIRECTION { Compiler.CreateFirstPiece(); };
createSecondCorrSect : DIRECTION EXIT { Compiler.CreateSecondPiece(); };
createRoom : EXIT ROOM ENTRY { Compiler.CreateRoom(); };

//dungeon map generation
//order: N, S, E , W
INITROOM : ( 'a' | 'b' | 'c' | 'd' ) ;
ENTRY : ( 'f' | 'g' | 'h' | 'i' ) ;
EXIT : ( 'j' | 'k' | 'l' | 'm' ) ;
DIRECTION : ( 'n' | 's' | 'e' | 'w' ) ;
ROOM : 'r' ;
//SEPERATOR : '.' ; //Needed?

/// some basic definitions
INT : '-'? ('0'..'9')+ ;
NEWLINE:'\r'? '\n' ;
WS : [ \t\r\n]+ -> skip ;