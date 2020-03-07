using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class PlatformerProgram {

    static private MapGeneration mapGenerator;

    static private GameObject _exitDoor;
    static private Transform _mapConnectionPos;
    static private Tilemap _wallMap, _groundMap, _deathMap, _floorMap;
    static private Tile _groundTile, _brickTile1, _brickTile2, _brickTile3, _spikeTile;
    //static private List<GameObject> _players = new List<GameObject>();
    static public List<Vector3> _playerPositions = new List<Vector3>(); //Can't decided if I'm going to need to store multiple or not yet
    static public List<Vector3> _pickupPositions = new List<Vector3>();
    static public List<Vector3> _enemyPositions = new List<Vector3>();
    static public float enemyPaceDist;

    static private int maxFillerLayers = 2;
    static private int wallHeight = 11;

    public interface IElement { IEnumerator Execute(); }

    public class StartSegment : IElement
    {
        public StartSegment() { }

        public IEnumerator Execute()
        {
            //Find resources etc
            _groundMap = GameObject.Find("GroundMap").GetComponent<Tilemap>(); //no collisions
            _wallMap = GameObject.Find("WallMap").GetComponent<Tilemap>(); //collisions
            _floorMap = GameObject.Find("FloorMap").GetComponent<Tilemap>(); //collisions
            _deathMap = GameObject.Find("DeathMap").GetComponent<Tilemap>(); //collisions
            _exitDoor = GameObject.Find("EndPosPlatformer");


            _mapConnectionPos = GameObject.Find("StartPos").GetComponent<Transform>();
            //TODO just deal with startPos internally. set it to the required position initially based on gametype

            _groundTile = Resources.Load("Ground") as Tile;
            _brickTile1 = Resources.Load("Wall") as Tile;
            _brickTile2 = Resources.Load("Wall2") as Tile;
            _brickTile3 = Resources.Load("Wall3") as Tile;
            _spikeTile = Resources.Load("Spikes") as Tile;

            mapGenerator = GameObject.Find("MapGeneration").GetComponent<MapGeneration>();

            //G
            //G
            //G
            //G
            //G
            //G
            //GGG (ground)
            //DDD (dirt)
            //DDD (dirt)

            Vector3Int currentCell = _groundMap.WorldToCell(_mapConnectionPos.position);
            Vector3Int newFirstCell = currentCell;
            newFirstCell.x += 3;
            _mapConnectionPos.position = _groundMap.CellToLocal(newFirstCell);

            Vector3Int tile1, tile2, tile3;

            //get start pos for player(s)
            Vector3Int playerPosCell = currentCell;
            playerPosCell.x += 2;
            playerPosCell.y += 4;
            _playerPositions.Add(_groundMap.CellToLocal(playerPosCell));

            //calculate enemy pace distance before any are actually created
            Vector3Int pointA = currentCell;
            Vector3Int pointB = currentCell;
            pointB.x += 1;
            enemyPaceDist = Mathf.Abs(_groundMap.CellToLocal(pointA).x - _groundMap.CellToLocal(pointB).x);
            //just care about x axis because it's only the horizontal move dist

            //dirt
            //int maxFillerLayers = 2;
            for (int i = 0; i < maxFillerLayers; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tile1 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile2 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile3 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);

                    _groundMap.SetTile(tile1, _groundTile);
                    _groundMap.SetTile(tile2, _groundTile);
                    _groundMap.SetTile(tile3, _groundTile);
                }
            }

            //ground
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);

                _floorMap.SetTile(tile1, _brickTile1);
                _floorMap.SetTile(tile2, _brickTile2);
                _floorMap.SetTile(tile3, _brickTile3);
            }

            //wall
            for (int i = 1; i < wallHeight; i++)
            {
                tile1 = new Vector3Int(currentCell.x, currentCell.y + (maxFillerLayers + i), currentCell.z);
                _wallMap.SetTile(tile1, _brickTile1);
            }

            //ceiling
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + wallHeight, currentCell.z);
                _wallMap.SetTile(tile1, _brickTile1);
            }

            //TODO create player pos from this segment and add to _playerPositions
            Vector3Int startPos = new Vector3Int(currentCell.x + 2, currentCell.y + 4, currentCell.z);
            _playerPositions.Add(_groundMap.CellToLocal(startPos));


            return null;
        }
    }

    public class FlatSegment : IElement
    {

        public FlatSegment() { }

        public IEnumerator Execute()
        {
            //GGG (ground)
            //DDD (dirt)
            //DDD (dirt)

            //get pos to start tiled segment
            Vector3Int currentCell = _groundMap.WorldToCell(_mapConnectionPos.position);

            //calculate potential pick up positions
            Vector3Int tempCellPos = new Vector3Int();
            tempCellPos = currentCell;

            tempCellPos.y += 4;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));

            //calculate potential enemy positions
            tempCellPos = currentCell;

            tempCellPos.y += 3;
            tempCellPos.x += 1;
            _enemyPositions.Add(_groundMap.CellToLocal(tempCellPos));

            //move the connection pos along by 3 units
            Vector3Int newFirstCell = currentCell;
            newFirstCell.x += 3;
            _mapConnectionPos.position = _groundMap.CellToLocal(newFirstCell);

            Vector3Int tile1, tile2, tile3;

            //dirt
            //int maxFillerLayers = 2;
            for (int i = 0; i < maxFillerLayers; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tile1 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile2 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile3 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);

                    _groundMap.SetTile(tile1, _groundTile);
                    _groundMap.SetTile(tile2, _groundTile);
                    _groundMap.SetTile(tile3, _groundTile);
                }
            }

            //ground
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);

                _floorMap.SetTile(tile1, _brickTile1);
                _floorMap.SetTile(tile2, _brickTile2);
                _floorMap.SetTile(tile3, _brickTile3);
            }

            //ceiling
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + wallHeight, currentCell.z);
                _wallMap.SetTile(tile1, _brickTile1);
            }

            return null;
        }
    }

    public class LowPlatSegment : IElement
    {
        public LowPlatSegment() { }

        public IEnumerator Execute() //What it should do when this command gets executed
        {
            //GGG
            //
            //
            //GGG (ground)
            //DDD (dirt)
            //DDD (dirt)

            Vector3Int currentCell = _groundMap.WorldToCell(_mapConnectionPos.position);

            //calculate potential pick up positions
            Vector3Int tempCellPos = new Vector3Int();

            tempCellPos = currentCell;
            tempCellPos.y += 4;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));

            tempCellPos = currentCell;
            tempCellPos.y += 7;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));

            //calculate potential enemy positions
            tempCellPos = currentCell;

            tempCellPos.y += 3;
            tempCellPos.x += 1;
            _enemyPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.y += 3;
            _enemyPositions.Add(_groundMap.CellToLocal(tempCellPos));

            //move connection pos
            Vector3Int newFirstCell = currentCell;
            newFirstCell.x += 3;
            _mapConnectionPos.position = _groundMap.CellToLocal(newFirstCell);

            Vector3Int tile1, tile2, tile3;

            //Dirt:
            //int maxFillerLayers = 2;
            for (int i = 0; i < maxFillerLayers; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tile1 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile2 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile3 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);

                    _groundMap.SetTile(tile1, _groundTile);
                    _groundMap.SetTile(tile2, _groundTile);
                    _groundMap.SetTile(tile3, _groundTile);
                }
            }

            //Ground
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);

                _floorMap.SetTile(tile1, _brickTile1);
                _floorMap.SetTile(tile2, _brickTile2);
                _floorMap.SetTile(tile3, _brickTile3);
            }

            //Platform
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 3, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 3, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 3, currentCell.z);

                _floorMap.SetTile(tile1, _brickTile1);
                _floorMap.SetTile(tile2, _brickTile2);
                _floorMap.SetTile(tile3, _brickTile3);
            }

            //ceiling
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + wallHeight, currentCell.z);
                _wallMap.SetTile(tile1, _brickTile1);
            }

            return null;
        }
    }

    public class HighPlatSegment : IElement
    {
        public HighPlatSegment() { }

        public IEnumerator Execute() //What it should do when this command gets executed
        {
            //GGG
            //
            //
            //
            //
            //
            //GGG (ground)
            //DDD (dirt)
            //DDD (dirt)

            Vector3Int currentCell = _groundMap.WorldToCell(_mapConnectionPos.position);

            //calculate potential pick up positions
            Vector3Int tempCellPos = new Vector3Int();

            tempCellPos = currentCell;
            tempCellPos.y += 4;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));

            tempCellPos = currentCell;
            tempCellPos.y += 10;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));

            //calculate potential enemy positions
            tempCellPos = currentCell;

            tempCellPos.y += 3;
            tempCellPos.x += 1;
            _enemyPositions.Add(_groundMap.CellToLocal(tempCellPos));
            tempCellPos.y += 6;
            _enemyPositions.Add(_groundMap.CellToLocal(tempCellPos));

            //move connection pos
            Vector3Int newFirstCell = currentCell;
            newFirstCell.x += 3;
            _mapConnectionPos.position = _groundMap.CellToLocal(newFirstCell);

            Vector3Int tile1, tile2, tile3;

            //Dirt:
            //int maxFillerLayers = 2;
            for (int i = 0; i < maxFillerLayers; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tile1 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile2 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile3 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);

                    _groundMap.SetTile(tile1, _groundTile);
                    _groundMap.SetTile(tile2, _groundTile);
                    _groundMap.SetTile(tile3, _groundTile);
                }
            }

            //Ground
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);

                _floorMap.SetTile(tile1, _brickTile1);
                _floorMap.SetTile(tile2, _brickTile2);
                _floorMap.SetTile(tile3, _brickTile3);
            }

            //Platform
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 6, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 6, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 6, currentCell.z);

                _floorMap.SetTile(tile1, _brickTile1);
                _floorMap.SetTile(tile2, _brickTile2);
                _floorMap.SetTile(tile3, _brickTile3);
            }

            //ceiling
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + wallHeight, currentCell.z);
                _wallMap.SetTile(tile1, _brickTile1);
            }

            return null;
        }
    }

    public class GapSegment : IElement //TODO add spikes
    {
        public GapSegment() { }

        public IEnumerator Execute() //What it should do when this command gets executed
        {
            //xxx (nothing)
            //SSS (spikes)
            //DDD (dirt)

            Vector3Int currentCell = _groundMap.WorldToCell(_mapConnectionPos.position);

            //calculate potential pick up positions
            Vector3Int tempCellPos = new Vector3Int();

            tempCellPos = currentCell;
            tempCellPos.y += 5;
            tempCellPos.x += 1;
            _pickupPositions.Add(_groundMap.CellToLocal(tempCellPos));

            //move connection pos
            Vector3Int newFirstCell = currentCell;
            newFirstCell.x += 3;
            _mapConnectionPos.position = _groundMap.CellToLocal(newFirstCell);

            Vector3Int tile1, tile2, tile3;

            //dirt
            for (int j = 0; j < 3; j++)
            {
                tile1 = new Vector3Int(currentCell.x + j, currentCell.y, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + j, currentCell.y, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + j, currentCell.y, currentCell.z);

                _groundMap.SetTile(tile1, _groundTile);
                _groundMap.SetTile(tile2, _groundTile);
                _groundMap.SetTile(tile3, _groundTile);
            }

            //spikes
            for (int j = 0; j < 3; j++)
            {
                tile1 = new Vector3Int(currentCell.x + j, currentCell.y + 1, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + j, currentCell.y + 1, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + j, currentCell.y + 1, currentCell.z);

                _deathMap.SetTile(tile1, _spikeTile);
                _deathMap.SetTile(tile2, _spikeTile);
                _deathMap.SetTile(tile3, _spikeTile);
            }

            //ceiling
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + wallHeight + 2, currentCell.z);
                _wallMap.SetTile(tile1, _brickTile1);
            }

            return null;
        }
    }

    public class FinalSegment : IElement //TODO update to "rest" segment when updated to infinite
    {
        public FinalSegment() { }

        public IEnumerator Execute() //What it should do when this command gets executed
        {
            //  G
            //  G
            //  G
            //  G
            //  G
            //  G
            //GGG (ground)
            //DDD (dirt)
            //DDD (dirt)

            int segmentLength = 7;

            Vector3Int currentCell = _groundMap.WorldToCell(_mapConnectionPos.position);
            Vector3Int newFirstCell = currentCell;
            newFirstCell.x += 3;
            _mapConnectionPos.position = _groundMap.CellToLocal(newFirstCell);

            Vector3Int tile1, tile2, tile3;

            //dirt
            
            for (int i = 0; i < maxFillerLayers; i++)
            {
                for (int j = 0; j < segmentLength; j++)
                {
                    tile1 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile2 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile3 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);

                    _groundMap.SetTile(tile1, _groundTile);
                    _groundMap.SetTile(tile2, _groundTile);
                    _groundMap.SetTile(tile3, _groundTile);
                }
            }

            //ground
            for (int i = 0; i < segmentLength; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);

                _floorMap.SetTile(tile1, _brickTile1);
                _floorMap.SetTile(tile2, _brickTile2);
                _floorMap.SetTile(tile3, _brickTile3);
            }

            //wall
            //TODO: Make this a level end trigger, not just a wall...
            for (int i = 1; i < wallHeight; i++)
            {
                tile1 = new Vector3Int(currentCell.x + (segmentLength -1), currentCell.y + (maxFillerLayers + i), currentCell.z);
                _wallMap.SetTile(tile1, _brickTile1);
            }

            //ceiling
            for (int i = 0; i < segmentLength; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + wallHeight, currentCell.z);
                _wallMap.SetTile(tile1, _brickTile1);
            }

            //Not needed while map is being generated first
            /*//make player active now that the full level has been generated
            foreach(GameObject p in _players)
            {
                //set start position to the start piece
                int index = _players.IndexOf(p);
                p.GetComponent<Transform>().position = _playerPositions[index];
                //make visible
                p.GetComponent<SpriteRenderer>().enabled = true;
                //change type from kinematic to dynamic
                p.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }*/

            newFirstCell.y += (maxFillerLayers + 1);
            _exitDoor.transform.position = _groundMap.CellToLocal(newFirstCell);
            _exitDoor.GetComponent<SpriteRenderer>().enabled = true;

            Debug.Log("P program # player pos: " + _playerPositions.Count);

            mapGenerator.SetPickupPositions(_pickupPositions);
            mapGenerator.SetPlayerPositions(_playerPositions);
            mapGenerator.SetEnemyPositions(_enemyPositions);
            mapGenerator.SetEnemyPaceDist(enemyPaceDist);

            return null;
        }
    }

    public static float EXECUTION_DELAY = 0.5f;

    private List<IElement> _elements;
    private int _pc;

    public PlatformerProgram(List<IElement> elements)
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
