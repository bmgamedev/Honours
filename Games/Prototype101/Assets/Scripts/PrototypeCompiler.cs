using UnityEngine;
using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.Collections.Generic;

#region Aliases
//using MoveCommand = PrototypeProgram.MoveCommand;
//using MoveDirection = PrototypeProgram.MoveCommand.Direction;
//using RotateCommand = PrototypeProgram.RotateCommand;
#endregion

/**
 * Just an implementation of the plain old builder design pattern. 
 */
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

        parser.prog(); // <-- compile actually happens here (see Assets/Grammars/Tortoise/Tortoise.g4

        PrototypeCompiler compiler = parser.Compiler;
        PrototypeProgram program = new PrototypeProgram(compiler.Elements);

        return program;
    }


    /* public PrototypeCompiler AddMoveCommand(string direction, string distance)
     {
         MoveDirection dir = MoveDirection.BWD;
         string fwdString = Enum.GetName(typeof(MoveDirection), MoveDirection.FWD);

         if (direction.ToUpper().Equals(fwdString))
         {
             dir = MoveDirection.FWD;
         }

         float dist = float.Parse(distance);

         MoveCommand moveCommand = new MoveCommand(dir, dist);
         _elements.Add(moveCommand);

         return this;
     }


     public PrototypeCompiler AddRotateCommand(string angle)
     {
         float a = float.Parse(angle);
         RotateCommand rotateCommand = new RotateCommand(a);

         _elements.Add(rotateCommand);

         return this;
     }*/

    public PrototypeCompiler CreatePlayer(string num)
    {
        int numPlayers = int.Parse(num);

        PrototypeProgram.PlayerElement playerElement = new PrototypeProgram.PlayerElement(numPlayers);
        _elements.Add(playerElement);

        return this;
    }

    public PrototypeCompiler CreateMap(string size)
    {
        PrototypeProgram.MapElement.Size mapSize = PrototypeProgram.MapElement.Size.SMALL; //Default to small for ease - will only update if user has correctly specified M or L
        string strMed = Enum.GetName(typeof(PrototypeProgram.MapElement.Size), PrototypeProgram.MapElement.Size.MED);
        string strLarge = Enum.GetName(typeof(PrototypeProgram.MapElement.Size), PrototypeProgram.MapElement.Size.LARGE);


        if (size.ToUpper().Equals(strMed))
        {
            mapSize = PrototypeProgram.MapElement.Size.MED;
        }
        else if (size.ToUpper().Equals(strLarge))
        {
            mapSize = PrototypeProgram.MapElement.Size.LARGE;
        }

        PrototypeProgram.MapElement mapElement = new PrototypeProgram.MapElement(mapSize);
        _elements.Add(mapElement);

        return this;
    }

    public PrototypeCompiler CreateEnemy(string type, string num, string skill)
    {
        PrototypeProgram.EnemyElement.Type enemyType = PrototypeProgram.EnemyElement.Type.TYPEA; //Default to type A for ease - will only update if user has correctly specified B
        string strTypeB = Enum.GetName(typeof(PrototypeProgram.EnemyElement.Type), PrototypeProgram.EnemyElement.Type.TYPEB);

        if (type.ToUpper().Equals(strTypeB))
        {
            enemyType = PrototypeProgram.EnemyElement.Type.TYPEB;
        }

        int enemyNum = int.Parse(num);

        PrototypeProgram.EnemyElement.Skill enemySkill = PrototypeProgram.EnemyElement.Skill.BASIC; //Default to basic for ease - will only update if user has correctly specified balanced or skilled
        string strBalanced = Enum.GetName(typeof(PrototypeProgram.EnemyElement.Skill), PrototypeProgram.EnemyElement.Skill.BALANCED);
        string strskilled = Enum.GetName(typeof(PrototypeProgram.EnemyElement.Skill), PrototypeProgram.EnemyElement.Skill.SKILLED);

        if (skill.ToUpper().Equals(strBalanced))
        {
            enemySkill = PrototypeProgram.EnemyElement.Skill.BALANCED;
        }
        else if (skill.ToUpper().Equals(strskilled))
        {
            enemySkill = PrototypeProgram.EnemyElement.Skill.SKILLED;
        }

        PrototypeProgram.EnemyElement enemyElement = new PrototypeProgram.EnemyElement(enemyType, enemyNum, enemySkill);
        _elements.Add(enemyElement);

        return this;
    }

}
