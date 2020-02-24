using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class DungeonProgram
{
    static private Transform _mapConnectionPos;
    static private Tilemap _wallMap, _groundMap, _deathMap;
    static private Tile _groundTile, _brickTile1, _brickTile2, _brickTile3, _spikeTile;
    //static private List<GameObject> _players = new List<GameObject>();
    static public List<Vector3> _playerPositions = new List<Vector3>(); //Can't decided if I'm going to need to store multiple or not yet
    static public List<Vector3> _pickupPositions = new List<Vector3>();
    static public List<Vector3> _enemyPositions = new List<Vector3>();
    static public float enemyPaceDist;

    public enum Direction { North, South, East, West };
    static private Direction _corrDirection;
    static private Direction _entryDirection;
    static private Direction _exitDirection;

    public List<Vector3> GetPlayerPositions() { return _playerPositions; }
    public List<Vector3> GetPickupPositions() { return _pickupPositions; }
    public List<Vector3> GetEnemyPositions() { return _enemyPositions; }
    public float GetEnemyPaceDist() { return enemyPaceDist; }

    public interface IElement
    {
        IEnumerator Execute();
    }

    public class InitialRoom : IElement
    {
        public InitialRoom(Direction exitDir)
        {
            _exitDirection = exitDir;
        }

        public IEnumerator Execute() //What it should do when this command gets executed
        {
            return null;
        }
    }

    //RoomSegment
    public class RoomSegment : IElement
    {
        public RoomSegment(Direction entryDir, Direction exitDir)
        {
            _entryDirection = entryDir;
            _exitDirection = exitDir;
        }

        public IEnumerator Execute() //What it should do when this command gets executed
        {
            return null;
        }
    }

    //FirstCorrSegment
    public class FirstCorrSegment : IElement
    {
        public FirstCorrSegment(Direction entryDir, Direction corrDir)
        {
            _corrDirection = corrDir;
            _entryDirection = entryDir;
        }

        public IEnumerator Execute() //What it should do when this command gets executed
        {
            return null;
        }
    }

    //SecondCorrSegment
    public class SecondCorrSegment : IElement
    {
        public SecondCorrSegment(Direction corrDir, Direction exitDir)
        {
            _corrDirection = corrDir;
            _exitDirection = exitDir;
        }

        public IEnumerator Execute() //What it should do when this command gets executed
        {
            return null;
        }
    }

    public static float EXECUTION_DELAY = 0.5f;

    private List<IElement> _elements;
    private int _pc;

    public DungeonProgram(List<IElement> elements)
    {
        _elements = elements;
        _pc = 0;
    }

    public IEnumerator Run()
    {
        while (_pc < _elements.Count)
        {
            yield return new WaitForSeconds(EXECUTION_DELAY);

            IElement nextElement = _elements[_pc++];
            yield return nextElement.Execute();
        }
    }

    public void Reset()
    {
        _pc = 0;
    }
}
