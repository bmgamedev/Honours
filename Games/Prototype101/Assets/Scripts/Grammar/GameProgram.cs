using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GameProgram
{
    public enum GameType { Dungeon, Platformer };
    public enum SkillLevel { Easy, Regular, Hard };
    public enum MapSize { Small, Medium, Large };

    static private GameType _gameType;
    static private SkillLevel _gameDifficulty;
    static private MapSize _mapSize;

    static private List<GameObject> _players = new List<GameObject>();
    static private List<Vector3> _playerPositions = new List<Vector3>(); //Can't decided if I'm going to need to store multiple or not yet
    static private List<Vector3> _pickupPositions = new List<Vector3>();
    static private List<Vector3> _enemyPositions = new List<Vector3>();
    //static private List<string> _enemyAxes = new List<string>();
    static private List<string> _enemyPaceAxis = new List<string>() { "Horizontal", "vertical" };
    //static private float enemyPaceDist;

    static private Text loadingMessage = null;

    static private MapGeneration mapGenerator;

    public interface IElement { IEnumerator Execute(); }

    public class GameInitialisation : IElement
    {
        public GameInitialisation() { }

        public IEnumerator Execute()
        {
            //Find resources etc
            mapGenerator = GameObject.Find("MapGeneration").GetComponent<MapGeneration>();

            loadingMessage = GameObject.Find("LoadingText").GetComponent<Text>();
            if (loadingMessage != null) { loadingMessage.text = "Creating Game..."; }

            return null;
        }
    }

    public class GameTypeSetup : IElement
    {
        public GameTypeSetup(GameType gametype, SkillLevel gameDifficulty, MapSize size)
        {
            _gameType = gametype;
            _gameDifficulty = gameDifficulty;
            _mapSize = size;
        }

        public IEnumerator Execute()
        {
            //send message to loading text to say "Creating level"
            if (loadingMessage != null)
            {
                loadingMessage.text = "Creating the level...";
            }

            //Create the map using seperate grammars
            if (_gameType == GameType.Dungeon)
            {
                //Debug.Log("dungeon");
                yield return mapGenerator.GenerateDungeonMap(_mapSize);
            }
            else if (_gameType == GameType.Platformer)
            {
                yield return mapGenerator.GeneratePlatformerMap(_mapSize);
            }

            //get position arrays
            _pickupPositions = mapGenerator.GetPickupPositions();
            _playerPositions = mapGenerator.GetPlayerPositions();
            _enemyPositions = mapGenerator.GetEnemyPositions();
            //_enemyAxes = mapGenerator.GetEnemyPaceAxes();
            //enemyPaceDist = mapGenerator.GetEnemyPaceDist();

            //pick random number between x and y to represent number of pickups to be placed
            //let's just say 20 initially

            System.Random random = new System.Random();
            int rnd;

            if (_pickupPositions != null)
            {
                int numPickups = Mathf.Min(7, _pickupPositions.Count);
                for (int i = 0; i < numPickups; i++)
                {
                    rnd = random.Next(_pickupPositions.Count);
                    Vector3 pickupPos = _pickupPositions[rnd];
                    //#pragma warning disable 1234
                    GameObject pickup = Object.Instantiate(Resources.Load("Pickup"), pickupPos, Quaternion.identity) as GameObject;
                    //#pragma warning restore 1234
                }
            }
            

            //Debug.Log("game type: " + _gameType.ToString() + ", difficulty: " + _gameDifficulty.ToString());

            yield return null;
            //return null;
        }
    }

    public class PlayerElement : IElement
    {
        private readonly int _num; //change to just private if having problems later

        public PlayerElement(int num)
        {
            _num = num;
        }

        public IEnumerator Execute() 
        {
            if (loadingMessage != null) { loadingMessage.text = "Adding players..."; }

            _players.Clear();

            //CreationManager.CameraSetup(_num);
            switch (_num)
            {
                //case 1:

                //break;
                case 2:
                    GameObject.Find("TwoPlayerA").GetComponent<Camera>().enabled = true;
                    GameObject.Find("TwoPlayerB").GetComponent<Camera>().enabled = true;
                    break;
                default:
                    GameObject.Find("SinglePlayer").GetComponent<Camera>().enabled = true;
                    break;
            }
            GameObject Player = null;

            //create players
            for (int i = 0; i < _num; i++)
            {
                //create player - the details differ between game types
                if (_gameType == GameType.Dungeon)
                {
                    Vector3 startPos = new Vector3(0, 0, 0); ; // new Vector3(0 + (i * 4), 0, 0);
                    //Player = GameObject.Instantiate(Resources.Load("DungeonPC"), startPos, Quaternion.identity) as GameObject;
                    Player = GameObject.Instantiate(Resources.Load("TopDown"), startPos, Quaternion.identity) as GameObject;
                    Player.name = "Player" + (i + 1);
                    _players.Add(Player);
                }
                else if (_gameType == GameType.Platformer)
                {
                    Vector3 startPos = new Vector3(0, 0, 0); ; // new Vector3(0 + (i * 4), 0, 0);
                    Player = GameObject.Instantiate(Resources.Load("PlatformerPC 1"), startPos, Quaternion.identity) as GameObject;
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

            CamFollow MainCameraTarget;
            switch (_num) {
                case 2:
                    Player = GameObject.Find("Player" + 1);
                    //Player.transform.Translate(new Vector3(-5.0f, 0.0f, 0.0f));
                    Player.transform.position = _playerPositions[0];
                    Player.GetComponent<PlayerMgmt>().SetStartPos(_playerPositions[0]);
                    //CreationManager.UpdateCamera(Player, "TwoPlayerA");
                    MainCameraTarget = GameObject.Find("TwoPlayerA").GetComponent<CamFollow>();
                    if (MainCameraTarget != null)
                    {
                        MainCameraTarget.target = Player.transform;
                    }

                    Player = GameObject.Find("Player" + 2);
                    //Player.transform.Translate(new Vector3(5.0f, 0.0f, 0.0f));
                    Player.transform.position = _playerPositions[1];
                    Player.GetComponent<PlayerMgmt>().SetStartPos(_playerPositions[1]);
                    //CreationManager.UpdateCamera(Player, "TwoPlayerB");
                    MainCameraTarget = GameObject.Find("TwoPlayerB").GetComponent<CamFollow>();
                    if (MainCameraTarget != null)
                    {
                        MainCameraTarget.target = Player.transform;
                    }
                    break;
                /*case 3:
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
                    break;*/
                default:
                    Player = GameObject.Find("Player" + 1);
                    Player.transform.position = _playerPositions[0];
                    Player.GetComponent<PlayerMgmt>().SetStartPos(_playerPositions[0]);
                    //CreationManager.UpdateCamera(Player, "SinglePlayer");
                    MainCameraTarget = GameObject.Find("SinglePlayer").GetComponent<CamFollow>();
                    if (MainCameraTarget != null)
                    {
                        MainCameraTarget.target = Player.transform;
                    }
                    break;
            }
            

            //Debug.Log("Player x" + _num);
            //Debug.Log("# players: " + _players.Count);

            return null;
        }
    }

    public class EnemyElement : IElement
    {
        public enum Type
        {
            MOVING, STATIC, VARIED
        }

        private readonly Type _type;

        public EnemyElement(Type type)
        {
            _type = type;
        }

        public IEnumerator Execute()
        {
            if (_enemyPositions != null)
            {
                //Debug.Log("Enemy: " + _type.ToString());

                if (loadingMessage != null) { loadingMessage.text = "Adding enemies..."; }

                System.Random random = new System.Random();
                int rnd;
                GameObject enemy = null;

                int numEnemies = 0;
                if (_gameType == GameType.Platformer)
                {
                    if (_mapSize == MapSize.Small) { numEnemies = Mathf.Min(10, _enemyPositions.Count); }
                    else if (_mapSize == MapSize.Small) { numEnemies = Mathf.Min(20, _enemyPositions.Count); }
                    else { numEnemies = Mathf.Min(30, _enemyPositions.Count); }
                }
                else
                {
                    if (_mapSize == MapSize.Small) { numEnemies = Mathf.Min(15, _enemyPositions.Count); }
                    else if (_mapSize == MapSize.Small) { numEnemies = Mathf.Min(25, _enemyPositions.Count); }
                    else { numEnemies = Mathf.Min(40, _enemyPositions.Count); }
                }

                if (_gameDifficulty == SkillLevel.Regular) { numEnemies += (int)Mathf.Floor(numEnemies * 0.25f); }
                else if (_gameDifficulty == SkillLevel.Hard) { numEnemies += (int)Mathf.Floor(numEnemies * 0.5f); }

                for (int i = 0; i < numEnemies; i++)
                {
                    rnd = random.Next(_enemyPositions.Count);
                    Vector3 enemyPos = _enemyPositions[rnd];

                    rnd = random.Next(2);
                    string enemyPaceAxis = _enemyPaceAxis[rnd];

                    string enemyPacing, enemyStatic;

                    if (_gameType == GameType.Platformer)
                    {
                        enemyPacing = "EnemyA";
                        enemyStatic = "EnemyB";
                    }
                    else
                    {
                        enemyPacing = "EnemyD";
                        enemyStatic = "EnemyC";
                    }

                    if (_type.Equals(Type.MOVING))
                    {
                        enemy = Object.Instantiate(Resources.Load(enemyPacing), enemyPos, Quaternion.identity) as GameObject;
                        if (_gameType.Equals(GameType.Dungeon)) { enemy.GetComponent<EnemyPacing2>().SetPaceAxis(enemyPaceAxis); }
                        else { enemy.GetComponent<EnemyPacing>().SetPaceAxis("Horizontal"); } 
                    }
                    else if (_type.Equals(Type.STATIC))
                    {
                        enemy = Object.Instantiate(Resources.Load(enemyStatic), enemyPos, Quaternion.identity) as GameObject;
                    }
                    else if (_type.Equals(Type.VARIED))
                    {
                        rnd = random.Next(2);
                        if (rnd == 0)
                        {
                            enemy = Object.Instantiate(Resources.Load(enemyPacing), enemyPos, Quaternion.identity) as GameObject;
                            if (_gameType.Equals(GameType.Dungeon)) { enemy.GetComponent<EnemyPacing2>().SetPaceAxis(enemyPaceAxis); }
                            else { enemy.GetComponent<EnemyPacing>().SetPaceAxis("Horizontal"); }

                        }
                        else if (rnd == 1)
                        {
                            enemy = Object.Instantiate(Resources.Load(enemyStatic), enemyPos, Quaternion.identity) as GameObject;
                        }
                    }
                }
            }

            return null;
        }
    }

    

    public class FinishSetup : IElement
    {
        public FinishSetup() { }

        public IEnumerator Execute()
        {
            GameObject.Find("LoadingCam").GetComponent<Camera>().enabled = false;

            return null;
        }
    }

    public static float EXECUTION_DELAY = 0.5f;

	private List<IElement> _elements;
	private int _pc;

	public GameProgram(List<IElement> elements)
	{
        _elements = elements;
		_pc = 0;
    }

    public IEnumerator Run()
	{
        if (SceneManager.GetActiveScene().name == "Game")
        {
            SceneManager.LoadScene("GameNext");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }

		while(_pc < _elements.Count)
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
