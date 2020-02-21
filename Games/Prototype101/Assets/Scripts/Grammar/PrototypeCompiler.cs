using UnityEngine;
using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.Collections.Generic;


public class PrototypeCompiler
{
    private List<PrototypeProgram.IElement> _elements;
    private List<PrototypeProgram.IElement> Elements
    {
        get
        {
            return _elements;
        }
    }

    public PrototypeCompiler()
    {
        _elements = new List<PrototypeProgram.IElement>();
    }

    public static PrototypeProgram Compile(string source)
    {
        AntlrInputStream antlerStream = new AntlrInputStream(source);
        proto101Lexer lexer = new proto101Lexer(antlerStream);
        CommonTokenStream tokenStream = new CommonTokenStream(lexer);
        proto101Parser parser = new proto101Parser(tokenStream);

        parser.prog(); // <-- compile happens here (see .g4 file)
 
        PrototypeCompiler compiler = parser.Compiler;
        PrototypeProgram program = new PrototypeProgram(compiler.Elements);

        return program;
    }

    public PrototypeCompiler InitialiseGame()
    {
        PrototypeProgram.GameInitialisation gameInitialisation = new PrototypeProgram.GameInitialisation();
        _elements.Add(gameInitialisation);

        return this;
    }

    public PrototypeCompiler DefineGame(string type, string difficulty)
    {
        PrototypeProgram.GameType gameType = PrototypeProgram.GameType.Platformer;
        string dungeonGame = Enum.GetName(typeof(PrototypeProgram.GameType), PrototypeProgram.GameType.Dungeon);
 
        if (type.ToUpper().Equals(dungeonGame.ToUpper())) {
            gameType = PrototypeProgram.GameType.Dungeon;
        }

        PrototypeProgram.SkillLevel gameDifficulty = PrototypeProgram.SkillLevel.Easy;
        string regDifficulty = Enum.GetName(typeof(PrototypeProgram.SkillLevel), PrototypeProgram.SkillLevel.Regular);
        string hardDifficulty = Enum.GetName(typeof(PrototypeProgram.SkillLevel), PrototypeProgram.SkillLevel.Hard);

        if (difficulty.ToUpper().Equals(regDifficulty.ToUpper()))
        {
            gameDifficulty = PrototypeProgram.SkillLevel.Regular;
        }
        else if (difficulty.ToUpper().Equals(hardDifficulty.ToUpper()))
        {
            gameDifficulty = PrototypeProgram.SkillLevel.Hard;
        }

        PrototypeProgram.GameTypeSetup gameTypeSetup = new PrototypeProgram.GameTypeSetup(gameType, gameDifficulty);
        _elements.Add(gameTypeSetup);

        return this;
    }

    public PrototypeCompiler CreatePlayer(string num)
    {
        int numPlayers = int.Parse(num);

        PrototypeProgram.PlayerElement playerElement = new PrototypeProgram.PlayerElement(numPlayers);
        _elements.Add(playerElement);

        return this;
    }

    public PrototypeCompiler CreateDungeon(string size)
    {
        PrototypeProgram.DungeonElement.Size mapSize = PrototypeProgram.DungeonElement.Size.SMALL; //Default to small for ease - will only update if user has correctly specified M or L
        string strMed = Enum.GetName(typeof(PrototypeProgram.DungeonElement.Size), PrototypeProgram.DungeonElement.Size.MED);
        string strLarge = Enum.GetName(typeof(PrototypeProgram.DungeonElement.Size), PrototypeProgram.DungeonElement.Size.LARGE);


        if (size.ToUpper().Equals(strMed))
        {
            mapSize = PrototypeProgram.DungeonElement.Size.MED;
        }
        else if (size.ToUpper().Equals(strLarge))
        {
            mapSize = PrototypeProgram.DungeonElement.Size.LARGE;
        }

        PrototypeProgram.DungeonElement mapElement = new PrototypeProgram.DungeonElement(mapSize);
        _elements.Add(mapElement);

        return this;
    }

    /*
    public PrototypeCompiler CreateMap()
    {
        PrototypeProgram.MapElement mapElement = new PrototypeProgram.MapElement();
        _elements.Add(mapElement);

        return this;
    }
    */

    //public PrototypeCompiler CreateEnemy(string type, string num, string skill)
    public PrototypeCompiler CreateEnemy(string type)
    {
        PrototypeProgram.EnemyElement.Type enemyType = PrototypeProgram.EnemyElement.Type.MELEE; //Default to type A for ease - will only update if user has correctly specified B
        string strProjectile = Enum.GetName(typeof(PrototypeProgram.EnemyElement.Type), PrototypeProgram.EnemyElement.Type.PROJECTILE);
        string strVaried = Enum.GetName(typeof(PrototypeProgram.EnemyElement.Type), PrototypeProgram.EnemyElement.Type.VARIED);

        if (type.ToUpper().Equals(strProjectile))
        {
            enemyType = PrototypeProgram.EnemyElement.Type.PROJECTILE;
        }
        else if (type.ToUpper().Equals(strVaried))
        {
            enemyType = PrototypeProgram.EnemyElement.Type.VARIED;
        }

        //int enemyNum = int.Parse(num);

        /*PrototypeProgram.EnemyElement.Skill enemySkill = PrototypeProgram.EnemyElement.Skill.BASIC; //Default to basic for ease - will only update if user has correctly specified balanced or skilled
        string strBalanced = Enum.GetName(typeof(PrototypeProgram.EnemyElement.Skill), PrototypeProgram.EnemyElement.Skill.BALANCED);
        string strskilled = Enum.GetName(typeof(PrototypeProgram.EnemyElement.Skill), PrototypeProgram.EnemyElement.Skill.SKILLED);

        if (skill.ToUpper().Equals(strBalanced))
        {
            enemySkill = PrototypeProgram.EnemyElement.Skill.BALANCED;
        }
        else if (skill.ToUpper().Equals(strskilled))
        {
            enemySkill = PrototypeProgram.EnemyElement.Skill.SKILLED;
        }*/

        //PrototypeProgram.EnemyElement enemyElement = new PrototypeProgram.EnemyElement(enemyType, enemyNum, enemySkill);
        PrototypeProgram.EnemyElement enemyElement = new PrototypeProgram.EnemyElement(enemyType);
        _elements.Add(enemyElement);

        return this;
    }

    public PrototypeCompiler CreatePathStart()
    {
        PrototypeProgram.StartSegment startSegment = new PrototypeProgram.StartSegment();
        _elements.Add(startSegment);

        return this;
    }

    public PrototypeCompiler CreateFlatPath()
    {
        PrototypeProgram.FlatSegment flatSegment = new PrototypeProgram.FlatSegment();
        _elements.Add(flatSegment);

        return this;
    }

    public PrototypeCompiler CreateLowPlatform()
    {
        PrototypeProgram.LowPlatSegment lowPlatSegment = new PrototypeProgram.LowPlatSegment();
        _elements.Add(lowPlatSegment);

        return this;
    }

    public PrototypeCompiler CreateHighPlatform()
    {
        PrototypeProgram.HighPlatSegment highPlatSegment = new PrototypeProgram.HighPlatSegment();
        _elements.Add(highPlatSegment);

        return this;
    }

    public PrototypeCompiler CreatePathGap()
    {
        PrototypeProgram.GapSegment gapSegment = new PrototypeProgram.GapSegment();
        _elements.Add(gapSegment);

        return this;
    }

    public PrototypeCompiler CreateFinishLine()
    {
        PrototypeProgram.FinalSegment finalSegment = new PrototypeProgram.FinalSegment();
        _elements.Add(finalSegment);

        return this;
    }
}
