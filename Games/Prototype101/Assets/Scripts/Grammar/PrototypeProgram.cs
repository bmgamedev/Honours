using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class PrototypeProgram
{
    public enum GameType { Dungeon, Platformer };
    public enum SkillLevel { Easy, Regular, Hard };

    static private Transform _mapConnectionPos;
    static private Tilemap _wallMap, _groundMap, _deathMap;
    static private Tile _groundTile, _brickTile1, _brickTile2, _brickTile3, _spikeTile;
    static private GameType _gameType;
    static private SkillLevel _gameDifficulty;
    static private List<GameObject> _players = new List<GameObject>();
    static private List<Vector3> _playerPositions = new List<Vector3>(); //Can't decided if I'm going to need to store multiple or not yet
    static private List<Vector3> _pickupPositions = new List<Vector3>();
    static private List<Vector3> _enemyPositions = new List<Vector3>();
    static private float enemyPaceDist;

    static private Text loadingMessage = null;

    public interface IElement
	{
        //IEnumerator Execute(GameObject gameObject);
        IEnumerator Execute();
    }

    public class GameInitialisation : IElement
    {
        public GameInitialisation() { }

        public IEnumerator Execute()
        {
            //Find resources etc
            _groundMap = GameObject.Find("GroundMap").GetComponent<Tilemap>(); //no collisions
            _wallMap = GameObject.Find("WallMap").GetComponent<Tilemap>(); //collisions
            _deathMap = GameObject.Find("DeathMap").GetComponent<Tilemap>(); //collisions

            _mapConnectionPos = GameObject.Find("StartPos").GetComponent<Transform>();
            //TODO just deal with startPos internally. set it to the required position initially based on gametype

            _groundTile = Resources.Load("Ground") as Tile;
            _brickTile1 = Resources.Load("Wall") as Tile;
            _brickTile2 = Resources.Load("Wall2") as Tile;
            _brickTile3 = Resources.Load("Wall3") as Tile;
            _spikeTile = Resources.Load("Spikes") as Tile;

            loadingMessage = GameObject.Find("LoadingText").GetComponent<Text>();

            //send message to loading text to say "Adding enemies"
            if (loadingMessage != null)
            {
                loadingMessage.text = "Creating Game...";
            }

            return null;
        }
    }

    public class GameTypeSetup : IElement
    {
        public GameTypeSetup(GameType gametype, SkillLevel gameDifficulty)
        {
            _gameType = gametype;
            _gameDifficulty = gameDifficulty;
        }

        public IEnumerator Execute()
        {
            //TODO
            //define player prefab to be used
            //define camera set up to use - but how? there's an overlap with player element...
            //how to handle the map generation string?? Will need to be different for dungeon and platformer but that needs to be decided before this stage????

            //pick random number between x and y to represent number of pickups to be placed
            //let's just say 20 initially
            System.Random random = new System.Random();
            int rnd;

            GameObject pickup = null;

            int numPickups = Mathf.Min(7, _pickupPositions.Count);
            for (int i = 0; i < numPickups; i++)
            {
                rnd = random.Next(_pickupPositions.Count);
                Vector3 pickupPos = _pickupPositions[rnd];
                //Debug.Log(pickupPos.ToString());

                pickup = Object.Instantiate(Resources.Load("Pickup"), pickupPos, Quaternion.identity) as GameObject;

            }


            Debug.Log("game type: " + _gameType.ToString() + ", difficulty: " + _gameDifficulty.ToString());

            return null;
        }
    }

    public class PlayerElement : IElement
    {
        private readonly int _num; //change to just private if having problems later

        public PlayerElement(int num)
        {
            _num = num;
        }

        //public IEnumerator Execute(GameObject gameObject)
        public IEnumerator Execute() //What it should do when this command gets executed
        {
            //send message to loading text to say "Adding enemies"
            if (loadingMessage != null)
            {
                loadingMessage.text = "Adding players...";
            }

            //Vector3 origin = new Vector3(0,0,0); // GameObject.Find("StartPos").transform.position;
            _players.Clear();

            CreationManager.CameraSetup(_num);
            GameObject Player = null;

            //TODO: CODE TO CREATE PLAYER(S)
            for (int i = 0; i < _num; i++)
            {
                //create player - the details differ between game types
                if (_gameType == GameType.Dungeon)
                {
                    Vector3 startPos = new Vector3(0, 0, 0); ; // new Vector3(0 + (i * 4), 0, 0);
                    Player = GameObject.Instantiate(Resources.Load("DungeonPC"), startPos, Quaternion.identity) as GameObject;
                    Player.name = "Player" + (i + 1);
                    _players.Add(Player);
                }
                else if (_gameType == GameType.Platformer)
                {
                    Vector3 startPos = new Vector3(0, 0, 0); ; // new Vector3(0 + (i * 4), 0, 0);
                    Player = GameObject.Instantiate(Resources.Load("PlatformerPC"), startPos, Quaternion.identity) as GameObject;
                    Player.name = "Player" + (i + 1);
                    _players.Add(Player);
                }


            }

            //1 player pos:
            //(0.0f, 0.0f, 0.0f)

            //2 player pos:
            //a = (-5.0f, 0.0f, 0.0f) b = (5.0f, 0.0f, 0.0f)

            //3/4 player pos:
            //a = (-5.0f, 3.7f, 0.0f) b = (5.0f, 3.7f, 0.0f) c = (-5.0f, -3.7f, 0.0f) d = (5.0f, -3.7f, 0.0f)

            
            switch (_num) {
                case 2:
                    Player = GameObject.Find("Player" + 1);
                    Player.transform.Translate(new Vector3(-5.0f, 0.0f, 0.0f));
                    CreationManager.UpdateCamera(Player, "TwoPlayerA");

                    Player = GameObject.Find("Player" + 2);
                    Player.transform.Translate(new Vector3(5.0f, 0.0f, 0.0f));
                    CreationManager.UpdateCamera(Player, "TwoPlayerB");
                    break;
                case 3:
                    Player = GameObject.Find("Player" + 1);
                    Player.transform.Translate(new Vector3(-5.0f, 3.7f, 0.0f));
                    CreationManager.UpdateCamera(Player, "FourPlayerA");

                    Player = GameObject.Find("Player" + 2);
                    Player.transform.Translate(new Vector3(5.0f, 3.7f, 0.0f));
                    CreationManager.UpdateCamera(Player, "FourPlayerB");

                    Player = GameObject.Find("Player" + 3);
                    Player.transform.Translate(new Vector3(-5.0f, -3.7f, 0.0f));
                    CreationManager.UpdateCamera(Player, "FourPlayerC");
                    break;
                case 4:
                    Player = GameObject.Find("Player" + 1);
                    Player.transform.Translate(new Vector3(-5.0f, 3.7f, 0.0f));
                    CreationManager.UpdateCamera(Player, "FourPlayerA");

                    Player = GameObject.Find("Player" + 2);
                    Player.transform.Translate(new Vector3(5.0f, 3.7f, 0.0f));
                    CreationManager.UpdateCamera(Player, "FourPlayerB");

                    Player = GameObject.Find("Player" + 3);
                    Player.transform.Translate(new Vector3(-5.0f, -3.7f, 0.0f));
                    CreationManager.UpdateCamera(Player, "FourPlayerC");

                    Player = GameObject.Find("Player" + 4);
                    Player.transform.Translate(new Vector3(5.0f, -3.7f, 0.0f));
                    CreationManager.UpdateCamera(Player, "FourPlayerD");
                    break;
                default:
                    Player = GameObject.Find("Player" + 1);
                    Player.transform.position = _playerPositions[0];
                    Player.GetComponent<PlayerMgmt>().SetStartPos(_playerPositions[0]);
                    CreationManager.UpdateCamera(Player, "SinglePlayer");
                    break;
            }
            

            Debug.Log("Player x" + _num);
            Debug.Log("# players: " + _players.Count);

            return null;
        }
    }

    /*public class MapElement : IElement
    {
        public MapElement() { }

        public IEnumerator Execute()
        {
           
            if (_gameType == GameType.Dungeon)
            {
                //BUILD THE STRING USING THE STRING REWRITE FUNCTIONS

                //CALL THE COMPILER AND PASS THE STRING IN
                string map = GeneratePath(ITERATIONS BASED ON MAP SIZE);
                //StopAllCoroutines(); //feel like keeping this will cause problems cause this particular script iw a coroutine
                _program = PrototypeCompiler.Compile(generatorText2); 
                StartCoroutine(_program.Run());

                //ALL OF THIS INTO DUNGEON SPECIFIC COMPILER SCRIPT
                AntlrInputStream antlerStream = new AntlrInputStream(source);
                DungeonMapLexer lexer = new DungeonMapLexer(antlerStream);
                CommonTokenStream tokenStream = new CommonTokenStream(lexer);
                DungeonMapParser parser = new DungeonMapParser(tokenStream);

                parser.prog();
 
                PrototypeCompiler compiler = parser.Compiler;
                PrototypeProgram program = new PrototypeProgram(compiler.Elements);

                return program;
            }
            else if (_gameType == GameType.Platformer)
            {
                
            }

            return null;
        }
    }*/

    public class DungeonElement : IElement
    {
        public enum Size
        {
            SMALL, MED, LARGE
        }

        private Size _size;

        public DungeonElement(Size size)
        {
            _size = size;
        }

        //public IEnumerator Execute(GameObject gameObject)
        public IEnumerator Execute() //What it should do when this command gets executed
        {
            //Tilemap StartMap = GameObject.Find("StartMap").GetComponent<Tilemap>();
            /*Tilemap GroundMap = GameObject.Find("GroundMap").GetComponent<Tilemap>();
            Tilemap WallMap = GameObject.Find("WallMap").GetComponent<Tilemap>();
            Transform startPos = GameObject.Find("StartPos").GetComponent<Transform>(); //(-0.53, -5.47)
            Tile GroundTile = Resources.Load("Ground") as Tile;
            Tile WallTile1 = Resources.Load("Wall") as Tile;
            Tile WallTile2 = Resources.Load("Wall2") as Tile;
            Tile WallTile3 = Resources.Load("Wall3") as Tile;*/

            /*
            //TODO: CODE TO CREATE MAP - break these out into functions in creation manager later or this script will be horrific and unwieldy
            int maxRoomSize = 0;
            switch (_size) {
                case Size.SMALL:
                    //Create small map
                    maxRoomSize = 10;
                    break;
                case Size.MED:
                    //create med map
                    maxRoomSize = 13;
                    break;
                case Size.LARGE:
                    //Create large map
                    maxRoomSize = 16;

                    
                    break;
                default:
                    break;
            }

            //Make the actual room:
            Vector3Int currentCell = _groundMap.WorldToCell(_mapConnectionPos.position);

            Debug.Log(_mapConnectionPos);

            for (int i = 0; i < maxRoomSize; i++)
            {
                Vector3Int centreTile = new Vector3Int(currentCell.x, currentCell.y, currentCell.z);
                _groundMap.SetTile(centreTile, _groundTile);

                for (int j = 0; j < (Mathf.Round(maxRoomSize/2)); j++)
                {
                    Vector3Int rightTile = new Vector3Int(currentCell.x + (j + 1), currentCell.y, currentCell.z);
                    Vector3Int leftTile = new Vector3Int(currentCell.x - (j + 1), currentCell.y, currentCell.z);

                    _groundMap.SetTile(rightTile, _groundTile);
                    _groundMap.SetTile(leftTile, _groundTile);
                }

                currentCell.y += 1;

            }

            //Then add walls....
            Debug.Log(_groundMap.localBounds);
            float minXbound = _groundMap.localBounds.center.x - _groundMap.localBounds.extents.x;
            float maxXbound = _groundMap.localBounds.center.x + _groundMap.localBounds.extents.x;
            float minYbound = _groundMap.localBounds.center.y - _groundMap.localBounds.extents.y;
            float maxYbound = _groundMap.localBounds.center.y + _groundMap.localBounds.extents.y;

            Debug.Log("x bounds: " + minXbound + " to " + maxXbound);
            Debug.Log("y bounds: " + minYbound + " to " + maxYbound);

            for (int i = (int)minXbound; i < maxXbound; i++)
            {
                Vector3Int topWall = new Vector3Int(i, (int)maxYbound, -1);
                Vector3Int bottomWall = new Vector3Int(i, (int)minYbound, -1);

                Debug.Log("top tile: " + topWall);
                Debug.Log("bottom tile: " + bottomWall);

                if (i % 3 == 0)
                {
                    _wallMap.SetTile(topWall, _brickTile1);
                    _wallMap.SetTile(bottomWall, _brickTile1);
                }
                else if (i % 3 == 1)
                {
                    _wallMap.SetTile(topWall, _brickTile2);
                    _wallMap.SetTile(bottomWall, _brickTile2);
                }
                else
                {
                    _wallMap.SetTile(topWall, _brickTile3);
                    _wallMap.SetTile(bottomWall, _brickTile3);
                }

            }

            for (int i = (int)minYbound; i < maxYbound; i++)
            {
                Vector3Int leftWall = new Vector3Int((int)minXbound, i, -1);
                Vector3Int rightWall = new Vector3Int((int)maxXbound - 1, i, -1);

                //WallMap.SetTile(leftWall, _brickTile1);
                //WallMap.SetTile(rightWall, _brickTile1);

                Debug.Log("left tile: " + leftWall);
                Debug.Log("right tile: " + rightWall);

                if (i % 3 == 0)
                {
                    _wallMap.SetTile(leftWall, _brickTile1);
                    _wallMap.SetTile(rightWall, _brickTile1);
                }
                else if (i % 3 == 1)
                {
                    _wallMap.SetTile(leftWall, _brickTile2);
                    _wallMap.SetTile(rightWall, _brickTile2);
                }
                else
                {
                    _wallMap.SetTile(leftWall, _brickTile3);
                    _wallMap.SetTile(rightWall, _brickTile3);
                }
            }
            */

            Debug.Log("Map: " + _size.ToString());

            return null;
        }
    }

    public class EnemyElement : IElement
    {
        public enum Type
        {
            MELEE, PROJECTILE, VARIED
        }

        private readonly Type _type;

        public EnemyElement(Type type)
        {
            _type = type;
        }

        public IEnumerator Execute()
        {
            Debug.Log("Enemy: " + _type.ToString());

            //send message to loading text to say "Adding enemies"
            if (loadingMessage != null)
            {
                loadingMessage.text = "Adding enemies...";
            }

            //pick random number between x and y to represent number of pickups to be placed
            //let's just say 20 initially
            System.Random random = new System.Random();
            int rnd;

            GameObject enemy = null;

            //TODO determine number of enemies based on difficulty and map size, not just an arbitrary number. Also pick from a range for each combo.
            int numEnemies = Mathf.Min(7, _enemyPositions.Count);
            for (int i = 0; i < numEnemies; i++)
            {
                rnd = random.Next(_enemyPositions.Count);
                Vector3 enemyPos = _enemyPositions[rnd];
                //Debug.Log(pickupPos.ToString());

                if (_type.Equals(Type.MELEE))
                {
                    enemy = Object.Instantiate(Resources.Load("EnemyA"), enemyPos, Quaternion.identity) as GameObject;
                    enemy.GetComponent<EnemyPacing>().SetPaceDistance(enemyPaceDist);
                }
                else if (_type.Equals(Type.PROJECTILE))
                {
                    enemy = Object.Instantiate(Resources.Load("EnemyB"), enemyPos, Quaternion.identity) as GameObject;
                }
                else if (_type.Equals(Type.VARIED))
                {
                    rnd = random.Next(2);
                    if (rnd == 0)
                    {
                        enemy = Object.Instantiate(Resources.Load("EnemyA"), enemyPos, Quaternion.identity) as GameObject;
                        enemy.GetComponent<EnemyPacing>().SetPaceDistance(enemyPaceDist);
                    }
                    else if (rnd == 1)
                    {
                        enemy = Object.Instantiate(Resources.Load("EnemyB"), enemyPos, Quaternion.identity) as GameObject;
                    }
                    else
                    {
                        enemy = Object.Instantiate(Resources.Load("WarSkele"), enemyPos, Quaternion.identity) as GameObject;
                        enemy.GetComponent<EnemyPacing>().SetPaceDistance(enemyPaceDist);
                    }
                }
            }

            //TODO move this to a new thing like FinishGameSetup() that is triggered by a seperate token like "finish"/"end" or whatever
            GameObject.Find("LoadingCam").SetActive(false);

            return null;
        }
    }

    public class StartSegment : IElement
    {
        public StartSegment() { }

        public IEnumerator Execute()
        {
            //send message to loading text to say "Adding enemies"
            if (loadingMessage != null)
            {
                loadingMessage.text = "Creating the level...";
            }

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
            int maxFillerLayers = 2;
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

                _wallMap.SetTile(tile1, _brickTile1);
                _wallMap.SetTile(tile2, _brickTile2);
                _wallMap.SetTile(tile3, _brickTile3);
            }

            //wall
            for (int i = 1; i < 11; i++)
            {
                tile1 = new Vector3Int(currentCell.x, currentCell.y + (maxFillerLayers + i), currentCell.z);
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
            int maxFillerLayers = 2;
            for (int i = 0; i < maxFillerLayers; i++) {
                for (int j = 0; j < 3; j++) {
                    tile1 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile2 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);
                    tile3 = new Vector3Int(currentCell.x + j, currentCell.y + i, currentCell.z);

                    _groundMap.SetTile(tile1, _groundTile);
                    _groundMap.SetTile(tile2, _groundTile);
                    _groundMap.SetTile(tile3, _groundTile);
                }
            }

            //ground
            for (int i = 0; i < 3; i++) {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);

                _wallMap.SetTile(tile1, _brickTile1);
                _wallMap.SetTile(tile2, _brickTile2);
                _wallMap.SetTile(tile3, _brickTile3);
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
            int maxFillerLayers = 2;
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

                _wallMap.SetTile(tile1, _brickTile1);
                _wallMap.SetTile(tile2, _brickTile2);
                _wallMap.SetTile(tile3, _brickTile3);
            }

            //Platform
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 3, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 3, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 3, currentCell.z);

                _wallMap.SetTile(tile1, _brickTile1);
                _wallMap.SetTile(tile2, _brickTile2);
                _wallMap.SetTile(tile3, _brickTile3);
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
            int maxFillerLayers = 2;
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

                _wallMap.SetTile(tile1, _brickTile1);
                _wallMap.SetTile(tile2, _brickTile2);
                _wallMap.SetTile(tile3, _brickTile3);
            }

            //Platform
            for (int i = 0; i < 3; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 6, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 6, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers + 6, currentCell.z);

                _wallMap.SetTile(tile1, _brickTile1);
                _wallMap.SetTile(tile2, _brickTile2);
                _wallMap.SetTile(tile3, _brickTile3);
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

            Vector3Int currentCell = _groundMap.WorldToCell(_mapConnectionPos.position);
            Vector3Int newFirstCell = currentCell;
            newFirstCell.x += 3;
            _mapConnectionPos.position = _groundMap.CellToLocal(newFirstCell);

            Vector3Int tile1, tile2, tile3;

            //dirt
            int maxFillerLayers = 2;
            for (int i = 0; i < maxFillerLayers; i++)
            {
                for (int j = 0; j < 5; j++)
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
            for (int i = 0; i < 5; i++)
            {
                tile1 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile2 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);
                tile3 = new Vector3Int(currentCell.x + i, currentCell.y + maxFillerLayers, currentCell.z);

                _wallMap.SetTile(tile1, _brickTile1);
                _wallMap.SetTile(tile2, _brickTile2);
                _wallMap.SetTile(tile3, _brickTile3);
            }

            //wall
            //TODO: Make this a level end trigger, not just a wall...
            for (int i = 1; i < 11; i++)
            {
                tile1 = new Vector3Int(currentCell.x + 4, currentCell.y + (maxFillerLayers + i), currentCell.z);
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

            return null;
        }
    }

    public static float EXECUTION_DELAY = 0.5f;

	private List<IElement> _elements;
	private int _pc;

	public PrototypeProgram(List<IElement> elements)
	{
        _elements = elements;
		_pc = 0;
    }

    public IEnumerator Run()
	{
        //TODO load scene??
        SceneManager.LoadScene("Game");

		while(_pc < _elements.Count)
		{
			yield return new WaitForSeconds(EXECUTION_DELAY);

            IElement nextElement = _elements[_pc++];
            yield return nextElement.Execute();
		}
    }

    /*public IEnumerator Run()
    {
        yield return null;

        Scene curScene = SceneManager.GetActiveScene();

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        //asyncOperation.allowSceneActivation = false; //don't immediately activate scene (wait until objects have been created)
        //Heck, might as well just make the game scene active and watch it load until I can find a way to generate a scene without it being active...
        asyncOperation.allowSceneActivation = true;
        SceneManager.UnloadSceneAsync(curScene);

        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {

                while (_pc < _elements.Count)
                {
                    yield return new WaitForSeconds(EXECUTION_DELAY);

                    IElement nextElement = _elements[_pc++];

                    //Debug.Log("next element: " + nextElement.ToString());
                    nextElement.Execute();
                }

                //asyncOperation.allowSceneActivation = true;
                //SceneManager.UnloadScene(curScene);

            }

            yield return null;
        }
    }*/

    public void Reset()
	{
		_pc = 0;
	}
}
