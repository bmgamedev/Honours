using UnityEngine;
using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.Collections.Generic;


public class GameCompiler
{
    private List<GameProgram.IElement> _elements;
    private List<GameProgram.IElement> Elements
    {
        get
        {
            return _elements;
        }
    }

    public GameCompiler()
    {
        _elements = new List<GameProgram.IElement>();
    }

    public static GameProgram Compile(string source)
    {
        AntlrInputStream antlerStream = new AntlrInputStream(source);
        GameSetupLexer lexer = new GameSetupLexer(antlerStream);
        CommonTokenStream tokenStream = new CommonTokenStream(lexer);
        GameSetupParser parser = new GameSetupParser(tokenStream);

        parser.prog(); // <-- compile happens here (see .g4 file)
 
        GameCompiler compiler = parser.Compiler;
        GameProgram program = new GameProgram(compiler.Elements);

        return program;
    }

    public GameCompiler InitialiseGame()
    {
        GameProgram.GameInitialisation gameInitialisation = new GameProgram.GameInitialisation();
        _elements.Add(gameInitialisation);

        return this;
    }

    public GameCompiler DefineGame(string type, string difficulty, string size)
    {
        GameProgram.GameType gameType = GameProgram.GameType.Platformer;
        string dungeonGame = Enum.GetName(typeof(GameProgram.GameType), GameProgram.GameType.Dungeon);
 
        if (type.ToUpper().Equals(dungeonGame.ToUpper())) {
            gameType = GameProgram.GameType.Dungeon;
        }

        GameProgram.SkillLevel gameDifficulty = GameProgram.SkillLevel.Easy;
        string regDifficulty = Enum.GetName(typeof(GameProgram.SkillLevel), GameProgram.SkillLevel.Regular);
        string hardDifficulty = Enum.GetName(typeof(GameProgram.SkillLevel), GameProgram.SkillLevel.Hard);

        if (difficulty.ToUpper().Equals(regDifficulty.ToUpper()))
        {
            gameDifficulty = GameProgram.SkillLevel.Regular;
        }
        else if (difficulty.ToUpper().Equals(hardDifficulty.ToUpper()))
        {
            gameDifficulty = GameProgram.SkillLevel.Hard;
        }

        GameProgram.MapSize mapSize = GameProgram.MapSize.Small;
        string medMap = Enum.GetName(typeof(GameProgram.MapSize), GameProgram.MapSize.Medium);
        string largeMap = Enum.GetName(typeof(GameProgram.MapSize), GameProgram.MapSize.Large);

        if (size.ToUpper().Equals(medMap.ToUpper()))
        {
            mapSize = GameProgram.MapSize.Medium;
        }
        else if (size.ToUpper().Equals(largeMap.ToUpper()))
        {
            mapSize = GameProgram.MapSize.Large;
        }

        GameProgram.GameTypeSetup gameTypeSetup = new GameProgram.GameTypeSetup(gameType, gameDifficulty, mapSize);
        _elements.Add(gameTypeSetup);

        return this;
    }

    public GameCompiler CreatePlayer(string num)
    {
        int numPlayers = int.Parse(num);

        GameProgram.PlayerElement playerElement = new GameProgram.PlayerElement(numPlayers);
        _elements.Add(playerElement);

        return this;
    }

    /*public GameCompiler CreateDungeon(string size)
    {
        GameProgram.DungeonElement.Size mapSize = GameProgram.DungeonElement.Size.SMALL; //Default to small for ease - will only update if user has correctly specified M or L
        string strMed = Enum.GetName(typeof(GameProgram.DungeonElement.Size), GameProgram.DungeonElement.Size.MED);
        string strLarge = Enum.GetName(typeof(GameProgram.DungeonElement.Size), GameProgram.DungeonElement.Size.LARGE);


        if (size.ToUpper().Equals(strMed))
        {
            mapSize = GameProgram.DungeonElement.Size.MED;
        }
        else if (size.ToUpper().Equals(strLarge))
        {
            mapSize = GameProgram.DungeonElement.Size.LARGE;
        }

        GameProgram.DungeonElement mapElement = new GameProgram.DungeonElement(mapSize);
        _elements.Add(mapElement);

        return this;
    }*/

    /*
    public GameCompiler CreateMap()
    {
        GameProgram.MapElement mapElement = new GameProgram.MapElement();
        _elements.Add(mapElement);

        return this;
    }
    */

    //public GameCompiler CreateEnemy(string type, string num, string skill)
    public GameCompiler CreateEnemy(string type)
    {
        GameProgram.EnemyElement.Type enemyType = GameProgram.EnemyElement.Type.MELEE; //Default to type A for ease - will only update if user has correctly specified B
        string strProjectile = Enum.GetName(typeof(GameProgram.EnemyElement.Type), GameProgram.EnemyElement.Type.PROJECTILE);
        string strVaried = Enum.GetName(typeof(GameProgram.EnemyElement.Type), GameProgram.EnemyElement.Type.VARIED);

        if (type.ToUpper().Equals(strProjectile))
        {
            enemyType = GameProgram.EnemyElement.Type.PROJECTILE;
        }
        else if (type.ToUpper().Equals(strVaried))
        {
            enemyType = GameProgram.EnemyElement.Type.VARIED;
        }

        //int enemyNum = int.Parse(num);

        /*GameProgram.EnemyElement.Skill enemySkill = GameProgram.EnemyElement.Skill.BASIC; //Default to basic for ease - will only update if user has correctly specified balanced or skilled
        string strBalanced = Enum.GetName(typeof(GameProgram.EnemyElement.Skill), GameProgram.EnemyElement.Skill.BALANCED);
        string strskilled = Enum.GetName(typeof(GameProgram.EnemyElement.Skill), GameProgram.EnemyElement.Skill.SKILLED);

        if (skill.ToUpper().Equals(strBalanced))
        {
            enemySkill = GameProgram.EnemyElement.Skill.BALANCED;
        }
        else if (skill.ToUpper().Equals(strskilled))
        {
            enemySkill = GameProgram.EnemyElement.Skill.SKILLED;
        }*/

        //GameProgram.EnemyElement enemyElement = new GameProgram.EnemyElement(enemyType, enemyNum, enemySkill);
        GameProgram.EnemyElement enemyElement = new GameProgram.EnemyElement(enemyType);
        _elements.Add(enemyElement);

        return this;
    }

    public GameCompiler FinishSetup()
    {
        GameProgram.FinishSetup finishSetup = new GameProgram.FinishSetup();
        _elements.Add(finishSetup);

        return this;
    }

    /*
    public GameCompiler CreatePathStart()
    {
        GameProgram.StartSegment startSegment = new GameProgram.StartSegment();
        _elements.Add(startSegment);

        return this;
    }

    public GameCompiler CreateFlatPath()
    {
        GameProgram.FlatSegment flatSegment = new GameProgram.FlatSegment();
        _elements.Add(flatSegment);

        return this;
    }

    public GameCompiler CreateLowPlatform()
    {
        GameProgram.LowPlatSegment lowPlatSegment = new GameProgram.LowPlatSegment();
        _elements.Add(lowPlatSegment);

        return this;
    }

    public GameCompiler CreateHighPlatform()
    {
        GameProgram.HighPlatSegment highPlatSegment = new GameProgram.HighPlatSegment();
        _elements.Add(highPlatSegment);

        return this;
    }

    public GameCompiler CreatePathGap()
    {
        GameProgram.GapSegment gapSegment = new GameProgram.GapSegment();
        _elements.Add(gapSegment);

        return this;
    }

    public GameCompiler CreateFinishLine()
    {
        GameProgram.FinalSegment finalSegment = new GameProgram.FinalSegment();
        _elements.Add(finalSegment);

        return this;
    }
    */
}
