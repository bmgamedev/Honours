grammar GameSetup;

@parser::header {#pragma warning disable 3021}
@lexer::header {#pragma warning disable 3021}

@members
{
	public GameCompiler Compiler = new GameCompiler(); //the specific compiler file in the Unity project
}

prog : elem+ ;

/// what constitutes a single creation element
elem : ( initialiseGame | defineGame | createPlayer | createEnemies | finishGameSetup ) NEWLINE ;

initialiseGame : INITIALISE { Compiler.InitialiseGame(); };

//want to add in createGame which basically allows for different types of games to be made - could intitially prototype with text vs whatever 2D version I decide on
defineGame : GAMETYPE SKILLLEVEL DIFFICULTY SIZE { Compiler.DefineGame($GAMETYPE.text, $SKILLLEVEL.text, $SIZE.text); };

/// all the required game creation commands and the related compiler functions:
createPlayer : PC NUM { Compiler.CreatePlayer($NUM.text); }; //how many players, to add: what skill level

createEnemies : ATTACKSTYLE ENEMY { Compiler.CreateEnemy($ATTACKSTYLE.text); }; //defined enemy type

finishGameSetup : FINALISE { Compiler.FinishSetup(); }; //handle anything that needs to happen once everything is in place e.g moving away from loading screen

/// the building blocks for the game creation elements
INITIALISE : 'initialise' ;
FINALISE : 'finalise' ;
GAMETYPE : DUNGEON | PLATFORMER ;
PC : 'players' ;
NUM : INT ;
DIFFICULTY : 'difficulty' ;
SKILLLEVEL : 'easy' | 'regular' | 'hard' ;
SKILLSET : 'basic' | 'balanced' | 'skilled' ;
DUNGEON : 'dungeon' ;
PLATFORMER : 'platformer' ;
//MAPSIZE : SIZE MAP ;
MAP : 'map' ;
SIZE : 'small' | 'medium' | 'large' ;
ENEMY : 'enemy' | 'enemies';
ATTACKSTYLE : 'moving' | 'static' | 'varied' | 'combo';

/// some basic definitions
INT : '-'? ('0'..'9')+ ;
NEWLINE:'\r'? '\n' ;
WS : [ \t\r\n]+ -> skip ;