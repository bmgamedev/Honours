grammar DungeonMap;

@parser::header {#pragma warning disable 3021}
@lexer::header {#pragma warning disable 3021}

@members
{
	public DungeonCompiler Compiler = new DungeonCompiler(); //specific compiler file in the Unity project
}

prog : elem+ ;

/// what constitutes a single creation element
elem : ( createInitialRoom | createFirstCorrSect | createSecondCorrSect | createRoom ) NEWLINE ;

//build dungeon map
createInitialRoom : INITROOM EXIT { Compiler.CreateInitialRoom($EXIT.text); };
createFirstCorrSect : ENTRY DIRECTION { Compiler.CreateFirstPiece($ENTRY.text, $DIRECTION.text); };
createSecondCorrSect : DIRECTION EXIT { Compiler.CreateSecondPiece($EXIT.text, $DIRECTION.text); };
createRoom : EXIT ROOM ENTRY { Compiler.CreateRoom($EXIT.text, $ENTRY.text); };

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