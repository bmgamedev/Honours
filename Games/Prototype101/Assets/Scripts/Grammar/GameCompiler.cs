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

    public GameCompiler CreateEnemy(string type)
    {
        GameProgram.EnemyElement.Type enemyType = GameProgram.EnemyElement.Type.MOVING; //Default to type A for ease - will only update if user has correctly specified B
        string strStatic = Enum.GetName(typeof(GameProgram.EnemyElement.Type), GameProgram.EnemyElement.Type.STATIC);
        string strVaried = Enum.GetName(typeof(GameProgram.EnemyElement.Type), GameProgram.EnemyElement.Type.VARIED);

        if (type.ToUpper().Equals(strStatic))
        {
            enemyType = GameProgram.EnemyElement.Type.STATIC;
        }
        else if (type.ToUpper().Equals(strVaried))
        {
            enemyType = GameProgram.EnemyElement.Type.VARIED;
        }

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
}
