grammar proto101;

@members
{
	public PrototypeCompiler Compiler = new PrototypeCompiler(); //this will be the compiler file in the Unity project
}

prog : elem+ ;

/// what constitutes a single creation element. Going to keep them seperated by newlines for ease (for now at least)
/// e.g. elem : (move | rotate) NEWLINE ;
elem : ( createPlayer | createMap | createEnemies ) NEWLINE ;

//TODO want to add in createGame which basically allows for different types of games to be made - could intitially prototype with text vs whatever 2D version I decide on

/// all the required game creation commands and the related compiler functions:
/// e.g. move : MOV DIR VAL { Compiler.AddMoveCommand($DIR.text, $VAL.text); };
//create player - possible options for user: skillset, gender, sprite set (i.e. appearance - this approach is designed for people who are providing the art probably)
createPlayer : PC NUM { Compiler.CreatePlayer($NUM.text); }; //how many players, to add: what skill level

//create map
createMap : MAP SIZE { Compiler.CreateMap($SIZE.text); }; //pcg what each size generates - can expand later to perhaps generate based on some sort of dungeon generation approach for a whole map?

//create enemies - what, how many, how difficult?? PCG the placement?
createEnemies : ENEMY TYPE NUM SKILL { Compiler.CreateEnemy($TYPE.text, $NUM.text, $SKILL.text); }; //how many of each type of enemy at a particular skill level

/// the building blocks for the game creation elements
/// e.g. DIR : 'fwd' | 'bwd' ; or VAL : INT ;
PC : 'player' ;
NUM : INT ;
SKILL : 'basic' | 'balanced' | 'skilled' ;
MAP : 'map' ;
SIZE : 'small' | 'med' | 'large' ;
ENEMY : 'enemy' ;
TYPE : 'typeA' | 'typeB' ;


/// some basic definitions
INT : '-'? ('0'..'9')+ ;
NEWLINE:'\r'? '\n' ;
WS : [ \t\r\n]+ -> skip ;