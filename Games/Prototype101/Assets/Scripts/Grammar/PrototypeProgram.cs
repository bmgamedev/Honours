using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class PrototypeProgram
{

    public interface IElement
	{
        //IEnumerator Execute(GameObject gameObject);
        IEnumerator Execute();
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
            //Vector3 origin = new Vector3(0,0,0); // GameObject.Find("StartPos").transform.position;

            CreationManager.CameraSetup(_num);
            GameObject Player = null;

            //TODO: CODE TO CREATE PLAYER(S)
            for (int i = 0; i < _num; i++)
            {
                //create player
                //Instantiate(Resources.Load("PlayerPrefab"), new Vector2(startPos.x + (i * 4), startPos.y));
                Vector3 startPos = new Vector3(0, 0, 0); ; // new Vector3(0 + (i * 4), 0, 0);
                //GameObject Player = new GameObject();
                //Player.GetComponent<SpriteRenderer>().enabled = false;
                Player = GameObject.Instantiate(Resources.Load("PlayerPrefab"), startPos, Quaternion.identity) as GameObject;
                Player.name = "Player"+(i+1);
                //SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName("Game"));
                //Player.GetComponent<SpriteRenderer>().enabled = true;

                //CreationManager.CreatePlayer(i);
                /*if (i == 0) {
                    CreationManager.UpdateCamera(Player, "SinglePlayer");
                }*/
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
                    CreationManager.UpdateCamera(Player, "SinglePlayer");
                    break;
            }


            Debug.Log("Player x" + _num);

            return null;
        }
    }

    public class MapElement : IElement
    {
        public enum Size
        {
            SMALL, MED, LARGE
        }

        private Size _size;

        public MapElement(Size size)
        {
            _size = size;
        }

        //public IEnumerator Execute(GameObject gameObject)
        public IEnumerator Execute() //What it should do when this command gets executed
        {
            //Tilemap StartMap = GameObject.Find("StartMap").GetComponent<Tilemap>();
            Tilemap GroundMap = GameObject.Find("GroundMap").GetComponent<Tilemap>();
            Tilemap WallMap = GameObject.Find("WallMap").GetComponent<Tilemap>();
            Transform startPos = GameObject.Find("StartPos").GetComponent<Transform>();
            Tile GroundTile = Resources.Load("Ground") as Tile;
            Tile WallTile1 = Resources.Load("Wall") as Tile;
            Tile WallTile2 = Resources.Load("Wall2") as Tile;
            Tile WallTile3 = Resources.Load("Wall3") as Tile;


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

                    /*Vector3Int currentCell = GroundMap.WorldToCell(startPos.position);

                    Debug.Log(startPos);

                    for (int i = 0; i < 10; i++)
                    {
                        Vector3Int centreTile = new Vector3Int(currentCell.x, currentCell.y, currentCell.z);
                        GroundMap.SetTile(centreTile, GroundTile);

                        for (int j = 0; j < 5; j++)
                        {
                            Vector3Int rightTile = new Vector3Int(currentCell.x + (j + 1), currentCell.y, currentCell.z);
                            Vector3Int leftTile = new Vector3Int(currentCell.x - (j + 1), currentCell.y, currentCell.z);

                            GroundMap.SetTile(rightTile, GroundTile);
                            GroundMap.SetTile(leftTile, GroundTile);
                        }  

                        currentCell.y += 1;

                    }
                    //Then add walls....
                    Debug.Log(GroundMap.localBounds);
                    float minXbound = GroundMap.localBounds.center.x - GroundMap.localBounds.extents.x;
                    float maxXbound = GroundMap.localBounds.center.x + GroundMap.localBounds.extents.x;
                    float minYbound = GroundMap.localBounds.center.y - GroundMap.localBounds.extents.y;
                    float maxYbound = GroundMap.localBounds.center.y + GroundMap.localBounds.extents.y;

                    Debug.Log("x bounds: " + minXbound + " to " + maxXbound);
                    Debug.Log("y bounds: " + minYbound + " to " + maxYbound);

                    for (int i = (int)minXbound; i < maxXbound; i++) {
                        Vector3Int topWall = new Vector3Int(i, (int)maxYbound, -1);
                        Vector3Int bottomWall = new Vector3Int(i, (int)minYbound, -1);

                        Debug.Log("top tile: " + topWall);
                        Debug.Log("bottom tile: " + bottomWall);

                        if (i % 3 == 0) {
                            WallMap.SetTile(topWall, WallTile1);
                            WallMap.SetTile(bottomWall, WallTile1);
                        }
                        else if (i % 3 == 1) {
                            WallMap.SetTile(topWall, WallTile2);
                            WallMap.SetTile(bottomWall, WallTile2);
                        }
                        else {
                            WallMap.SetTile(topWall, WallTile3);
                            WallMap.SetTile(bottomWall, WallTile3);
                        }
                        
                    }

                    for (int i = (int)minYbound; i < maxYbound; i++)
                    {
                        Vector3Int leftWall = new Vector3Int((int)minXbound, i, -1);
                        Vector3Int rightWall = new Vector3Int((int)maxXbound - 1, i, -1);

                        //WallMap.SetTile(leftWall, WallTile1);
                        //WallMap.SetTile(rightWall, WallTile1);

                        Debug.Log("left tile: " + leftWall);
                        Debug.Log("right tile: " + rightWall);

                        if (i % 3 == 0)
                        {
                            WallMap.SetTile(leftWall, WallTile1);
                            WallMap.SetTile(rightWall, WallTile1);
                        }
                        else if (i % 3 == 1)
                        {
                            WallMap.SetTile(leftWall, WallTile2);
                            WallMap.SetTile(rightWall, WallTile2);
                        }
                        else
                        {
                            WallMap.SetTile(leftWall, WallTile3);
                            WallMap.SetTile(rightWall, WallTile3);
                        }
                    }*/

                    break;
                default:
                    break;
            }

            //Make the actual room:
            Vector3Int currentCell = GroundMap.WorldToCell(startPos.position);

            Debug.Log(startPos);

            for (int i = 0; i < maxRoomSize; i++)
            {
                Vector3Int centreTile = new Vector3Int(currentCell.x, currentCell.y, currentCell.z);
                GroundMap.SetTile(centreTile, GroundTile);

                for (int j = 0; j < (Mathf.Round(maxRoomSize/2)); j++)
                {
                    Vector3Int rightTile = new Vector3Int(currentCell.x + (j + 1), currentCell.y, currentCell.z);
                    Vector3Int leftTile = new Vector3Int(currentCell.x - (j + 1), currentCell.y, currentCell.z);

                    GroundMap.SetTile(rightTile, GroundTile);
                    GroundMap.SetTile(leftTile, GroundTile);
                }

                currentCell.y += 1;

            }
            //Then add walls....
            Debug.Log(GroundMap.localBounds);
            float minXbound = GroundMap.localBounds.center.x - GroundMap.localBounds.extents.x;
            float maxXbound = GroundMap.localBounds.center.x + GroundMap.localBounds.extents.x;
            float minYbound = GroundMap.localBounds.center.y - GroundMap.localBounds.extents.y;
            float maxYbound = GroundMap.localBounds.center.y + GroundMap.localBounds.extents.y;

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
                    WallMap.SetTile(topWall, WallTile1);
                    WallMap.SetTile(bottomWall, WallTile1);
                }
                else if (i % 3 == 1)
                {
                    WallMap.SetTile(topWall, WallTile2);
                    WallMap.SetTile(bottomWall, WallTile2);
                }
                else
                {
                    WallMap.SetTile(topWall, WallTile3);
                    WallMap.SetTile(bottomWall, WallTile3);
                }

            }

            for (int i = (int)minYbound; i < maxYbound; i++)
            {
                Vector3Int leftWall = new Vector3Int((int)minXbound, i, -1);
                Vector3Int rightWall = new Vector3Int((int)maxXbound - 1, i, -1);

                //WallMap.SetTile(leftWall, WallTile1);
                //WallMap.SetTile(rightWall, WallTile1);

                Debug.Log("left tile: " + leftWall);
                Debug.Log("right tile: " + rightWall);

                if (i % 3 == 0)
                {
                    WallMap.SetTile(leftWall, WallTile1);
                    WallMap.SetTile(rightWall, WallTile1);
                }
                else if (i % 3 == 1)
                {
                    WallMap.SetTile(leftWall, WallTile2);
                    WallMap.SetTile(rightWall, WallTile2);
                }
                else
                {
                    WallMap.SetTile(leftWall, WallTile3);
                    WallMap.SetTile(rightWall, WallTile3);
                }
            }

            Debug.Log("Map: " + _size.ToString());

            return null;
        }
    }

    public class EnemyElement : IElement
    {
        public enum Skill
        {
            BASIC, BALANCED, SKILLED
        }

        public enum Type
        {
            TYPEA, TYPEB
        }

        private readonly Skill _skill;
        private readonly int _num;
        private readonly Type _type;

        public EnemyElement(Type type, int num, Skill skill)
        {
            _skill = skill;
            _num = num;
            _type = type;
        }

        //public IEnumerator Execute(GameObject gameObject)
        public IEnumerator Execute() //What it should do when this command gets executed - will just be creation because the grammar isn't doing anything with gameplay... for now... 
        {
            //TODO: CODE TO CREATE AND PLACE ENEMIES

            Debug.Log("Enemy: " + _type.ToString() + ", " + _skill.ToString() + " x" + _num);

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

    //public IEnumerator Run(GameObject gameObject)
    public IEnumerator Run()
	{
        SceneManager.LoadScene("Game");

		while(_pc < _elements.Count)
		{
			yield return new WaitForSeconds(EXECUTION_DELAY);

            IElement nextElement = _elements[_pc++];
            //yield return nextElement.Execute(gameObject);
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
