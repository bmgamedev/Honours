grammar proto101;

@parser::header {#pragma warning disable 3021}
@lexer::header {#pragma warning disable 3021}

@members
{
	public PrototypeCompiler Compiler = new PrototypeCompiler(); //this will be the compiler file in the Unity project
}

prog : elem+ ;

/// what constitutes a single creation element. Going to keep them seperated by newlines for ease (for now at least)
/// e.g. elem : (move | rotate) NEWLINE ;
elem : ( createGame | createPlayer | createDungeon | createEnemies | addStartSegment | addFlatPathSegment | addLowPlatformSegment | addHighPlatformSegment | addPathGapSegment | addFinishLineSegment ) NEWLINE ;

//want to add in createGame which basically allows for different types of games to be made - could intitially prototype with text vs whatever 2D version I decide on
createGame : GAMETYPE {Compiler.CreateGame($GAMETYPE.text);};

/// all the required game creation commands and the related compiler functions:
/// e.g. move : MOV DIR VAL { Compiler.AddMoveCommand($DIR.text, $VAL.text); };
//create player - possible options for user: skillset, gender, sprite set (i.e. appearance - this approach is designed for people who are providing the art probably)
createPlayer : PC NUM { Compiler.CreatePlayer($NUM.text); }; //how many players, to add: what skill level

//create map
createDungeon : DUNGEON SIZE { Compiler.CreateDungeon($SIZE.text); }; //pcg what each size generates - can expand later to perhaps generate based on some sort of dungeon generation approach for a whole map?

//create enemies - what, how many, how difficult?? PCG the placement?
createEnemies : ENEMY ENEMYTYPE NUM SKILL { Compiler.CreateEnemy($ENEMYTYPE.text, $NUM.text, $SKILL.text); }; //how many of each type of enemy at a particular skill level

//build the path from segments
addStartSegment : START { Compiler.CreatePathStart(); };
addFlatPathSegment : FLATPATH { Compiler.CreateFlatPath(); };
addLowPlatformSegment : LOWPLATFORM { Compiler.CreateLowPlatform(); };
addHighPlatformSegment : HIGHPLATFORM { Compiler.CreateHighPlatform(); };
addPathGapSegment : PATHGAP { Compiler.CreatePathGap(); };
addFinishLineSegment : FINISHLINE { Compiler.CreateFinishLine(); };

/// the building blocks for the game creation elements
/// e.g. DIR : 'fwd' | 'bwd' ; or VAL : INT ;
GAMETYPE : DUNGEON | PLATFORMER ;
PC : 'player' ;
NUM : INT ;
SKILL : 'basic' | 'balanced' | 'skilled' ;
DUNGEON : 'dungeon' ;
PLATFORMER : 'platformer' ;
SIZE : 'small' | 'med' | 'large' ;
ENEMY : 'enemy' ;
ENEMYTYPE : 'typeA' | 'typeB' ;

//path generation
START : ('s'|'S') ; //including capitals since the string isn't guaranteed to be fully rewritten if based on x iterations
FLATPATH : ('f'|'F') ;
LOWPLATFORM : ('p'|'P');
HIGHPLATFORM : ('h'|'H');
PATHGAP : ('g'|'G');
FINISHLINE : ('e'|'E') ;


/// some basic definitions
INT : '-'? ('0'..'9')+ ;
NEWLINE:'\r'? '\n' ;
WS : [ \t\r\n]+ -> skip ;