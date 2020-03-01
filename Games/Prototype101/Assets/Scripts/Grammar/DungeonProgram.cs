using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class DungeonProgram
{
    static private MapGeneration mapGenerator;

    static private Vector3Int _innerConnection, _outerConnection; //TODO change to transform if cell positions aren't working
    static private Transform _startPos;

    static private int corridorWidth = 6;

    static private Tilemap _wallMap, _groundMap, _deathMap;
    static private Tile _groundTile, _brickTile1, _brickTile2, _brickTile3, _spikeTile;
    //static private List<GameObject> _players = new List<GameObject>();
    static public List<Vector3> _playerPositions = new List<Vector3>(); //Can't decided if I'm going to need to store multiple or not yet
    static public List<Vector3> _pickupPositions = new List<Vector3>();
    static public List<Vector3> _enemyPositions = new List<Vector3>();
    static public float enemyPaceDist;

    public enum Direction { North, South, East, West };
    static private Direction dominantDir;
    //static private Direction _corrDirection;
    //static private Direction _entryDirection;
    //static private Direction _exitDirection;

    public List<Vector3> GetPlayerPositions() { return _playerPositions; }
    public List<Vector3> GetPickupPositions() { return _pickupPositions; }
    public List<Vector3> GetEnemyPositions() { return _enemyPositions; }
    public float GetEnemyPaceDist() { return enemyPaceDist; }

    public interface IElement { IEnumerator Execute(); }

    //initial room 
    public class InitialRoom : IElement
    {
        private Direction exitDirection;

        public InitialRoom(Direction exitDir)
        {
            exitDirection = exitDir;
        }

        public IEnumerator Execute()
        {
            

            //get the tiles - TODO move to a type of "initialisation" function
            _groundMap = GameObject.Find("GroundMap").GetComponent<Tilemap>(); //no collisions
            _wallMap = GameObject.Find("WallMap").GetComponent<Tilemap>(); //collisions
            _deathMap = GameObject.Find("DeathMap").GetComponent<Tilemap>(); //collisions

            _startPos = GameObject.Find("StartPos").GetComponent<Transform>();
            _startPos.position = new Vector3(-0.53f, -5.47f, .0f);
            //TODO just deal with positions internally. set it to the required position initially based on gametype

            _groundTile = Resources.Load("Ground") as Tile;
            _brickTile1 = Resources.Load("Wall") as Tile;
            _brickTile2 = Resources.Load("Wall2") as Tile;
            _brickTile3 = Resources.Load("Wall3") as Tile;
            _spikeTile = Resources.Load("Spikes") as Tile;

            mapGenerator = GameObject.Find("MapGeneration").GetComponent<MapGeneration>();

            int maxRoomSize = 12; //TODO some sort of logic here?

            //string direction = mapGenerator.GetDominantDirection();
            if (exitDirection.Equals(Direction.North)) { dominantDir = Direction.North; }
            else if (exitDirection.Equals(Direction.South)) { dominantDir = Direction.South; }
            else if(exitDirection.Equals(Direction.East)) { dominantDir = Direction.East; }
            else if (exitDirection.Equals(Direction.West)) { dominantDir = Direction.West; }

            Debug.Log(exitDirection);
            Debug.Log(dominantDir);

            //Make the actual room:
            Vector3Int currentCell = _groundMap.WorldToCell(_startPos.position);
            Debug.Log(_startPos);
            for (int i = 0; i < maxRoomSize; i++)
            {
                Vector3Int centreTile = new Vector3Int(currentCell.x, currentCell.y, currentCell.z);
                _groundMap.SetTile(centreTile, _groundTile);
                for (int j = 0; j < (Mathf.Round(maxRoomSize / 2)); j++)
                {
                    Vector3Int rightTile = new Vector3Int(currentCell.x + (j + 1), currentCell.y, currentCell.z);
                    Vector3Int leftTile = new Vector3Int(currentCell.x - (j + 1), currentCell.y, currentCell.z);
                    _groundMap.SetTile(rightTile, _groundTile);
                    _groundMap.SetTile(leftTile, _groundTile);
                }
                currentCell.y += 1;
            }

            //Then add walls and player positions
            float minXbound = _groundMap.localBounds.center.x - _groundMap.localBounds.extents.x;
            float maxXbound = _groundMap.localBounds.center.x + _groundMap.localBounds.extents.x;
            float minYbound = _groundMap.localBounds.center.y - _groundMap.localBounds.extents.y;
            float maxYbound = _groundMap.localBounds.center.y + _groundMap.localBounds.extents.y;

            Vector3Int topWall, bottomWall, leftWall, rightWall;

            for (int i = (int)minXbound; i < maxXbound; i++)
            {
                topWall = new Vector3Int(i, (int)maxYbound, -1);
                bottomWall = new Vector3Int(i, (int)minYbound, -1);

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
                leftWall = new Vector3Int((int)minXbound, i, -1);
                rightWall = new Vector3Int((int)maxXbound - 1, i, -1);

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

            //player positions:
            _playerPositions.Clear();
            _playerPositions.Add(_groundMap.CellToLocal(
                new Vector3Int(
                    (int)Mathf.Ceil(_groundMap.localBounds.extents.x / 3),
                    (int)Mathf.Ceil(_groundMap.localBounds.extents.y / 3),
                    currentCell.z)
                )
            );

            _playerPositions.Add(_groundMap.CellToLocal(
                new Vector3Int(
                    (int)Mathf.Floor((_groundMap.localBounds.extents.x / 3) * 2),
                    (int)Mathf.Ceil(_groundMap.localBounds.extents.y / 3),
                    currentCell.z)
                )
            );

            _playerPositions.Add(_groundMap.CellToLocal(
                new Vector3Int(
                    (int)Mathf.Ceil(_groundMap.localBounds.extents.x / 3),
                    (int)Mathf.Floor((_groundMap.localBounds.extents.y / 3) * 2),
                    currentCell.z)
                )
            );

            _playerPositions.Add(_groundMap.CellToLocal(
                new Vector3Int(
                    (int)Mathf.Floor((_groundMap.localBounds.extents.x / 3) * 2),
                    (int)Mathf.Floor((_groundMap.localBounds.extents.y / 3) * 2),
                    currentCell.z)
                )
            );

            //remove certain wall tiles based on direction of exit
            int midpoint;
            //corridorWidth = 4;

            if (exitDirection == Direction.North)
            {
                midpoint = (int)_wallMap.localBounds.center.x - 2;
                topWall = new Vector3Int(midpoint, (int)maxYbound, -1);

                for (int i = 0; i < corridorWidth; i++)
                {
                    Vector3Int tilePos = topWall;
                    tilePos.x += i;
                    _wallMap.SetTile(tilePos, null);

                    //set the outerconnection pos
                    if (i == 0) { _outerConnection = tilePos; }
                }
                
            }
            else if (exitDirection == Direction.South)
            {
                midpoint = (int)_wallMap.localBounds.center.x - 2;
                bottomWall = new Vector3Int(midpoint, (int)minYbound, -1);

                for (int i = 0; i < corridorWidth; i++)
                {
                    Vector3Int tilePos = bottomWall;
                    tilePos.x += i;
                    _wallMap.SetTile(tilePos, null);

                    //set the outerconnection pos
                    if (i == 3) { _outerConnection = tilePos; _outerConnection.x += 2; }
                }

            }
            else if (exitDirection == Direction.East)
            {
                midpoint = (int)_wallMap.localBounds.center.y - 2;
                leftWall = new Vector3Int((int)maxXbound - 1, midpoint, -1);

                for (int i = 0; i < corridorWidth; i++)
                {
                    Vector3Int tilePos = leftWall;
                    tilePos.y += i;
                    _wallMap.SetTile(tilePos, null);

                    //set the outerconnection pos
                    if (i == 3) { _outerConnection = tilePos; _outerConnection.y += 2; }
                }
            }
            else if (exitDirection == Direction.West)
            {
                midpoint = (int)_wallMap.localBounds.center.y - 2;
                rightWall = new Vector3Int((int)minXbound, midpoint, -1);

                for (int i = 0; i < corridorWidth; i++)
                {
                    Vector3Int tilePos = rightWall;
                    tilePos.y += i;
                    _wallMap.SetTile(tilePos, null);

                    //set the outerconnection pos
                    if (i == 0) { _outerConnection = tilePos; }
                }
            }

            mapGenerator.SetPlayerPositions(_playerPositions);

            return null;
        }
    }

    //RoomSegment
    public class RoomSegment : IElement
    {
        private Direction exitDirection, entryDirection;

        public RoomSegment(Direction entryDir, Direction exitDir)
        {
            entryDirection = entryDir;
            exitDirection = exitDir;
        }

        public IEnumerator Execute()
        {
            //TODO
            int roomWidth = 15;
            int roomHeight = 15;

            System.Random random = new System.Random();
            int offset = random.Next(10);

            Vector3Int mapfillStart = _outerConnection;

            if (entryDirection == Direction.South)
            {
                mapfillStart.x -= roomWidth; mapfillStart.y -= roomHeight;
            }
            else if (entryDirection == Direction.East) { mapfillStart.y -= roomHeight; }
            else if (entryDirection == Direction.West) { mapfillStart.x -= roomWidth; }

            //build a walled room
            Vector3Int tile = mapfillStart;
            for (int i = 0; i < roomHeight; i++) {

                tile.x = mapfillStart.x - 1;

                for (int j = 0; j < roomWidth; j++) {
                    
                    tile.x ++;
                    _groundMap.SetTile(tile, _groundTile);

                }
                tile.y++;
            }

            //Left/Right
            tile = mapfillStart;
            for (int i = 0; i <= roomHeight; i++)
            {
                tile.x = mapfillStart.x;
                _wallMap.SetTile(tile, _brickTile1);
                tile.x = mapfillStart.x + roomWidth;
                _wallMap.SetTile(tile, _brickTile1);
                tile.y++;
            }

            //Top/Bottom
            tile = mapfillStart;
            for (int i = 0; i <= roomWidth; i++)
            {
                tile.y = mapfillStart.y;// - 1;
                _wallMap.SetTile(tile, _brickTile1);
                tile.y = mapfillStart.y + roomHeight;
                _wallMap.SetTile(tile, _brickTile1);
                tile.x++;
            }

            //remove entry
            if (entryDirection == Direction.North)
            {
                tile = _outerConnection;
                //tile.y--;
                tile.x++;
                for (int i = 0; i < (corridorWidth - 1); i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.x++;
                }
                
            }
            else if (entryDirection == Direction.South)
            {
                tile = _outerConnection;
                //tile.y--;
                tile.x -= corridorWidth;
                for (int i = 0; i < corridorWidth; i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.x++;
                }

            }
            else if ( entryDirection == Direction.East)
            {
                tile = _outerConnection;
                tile.y -= 1;
                //tile.x -= 1;
                //tile.x--; //needed?
                for (int i = 0; i < (corridorWidth - 1); i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.y--;
                }
            }
            else if (entryDirection == Direction.West)
            {
                tile = _outerConnection;
                tile.y += corridorWidth - 1;
                //tile.x--; //needed?
                for (int i = 0; i < (corridorWidth - 1); i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.y--;
                }
            }

            //set new outerconnection point
            /*if ((exitDirection == Direction.North && entryDirection == Direction.North) ||
                (exitDirection == Direction.East && entryDirection == Direction.West)) {
                _outerConnection.y += roomHeight; }
            else if ((exitDirection == Direction.North && entryDirection == Direction.South) ||
                (exitDirection == Direction.West && entryDirection == Direction.West)) {
                _outerConnection.x -= roomWidth; }
            else if ((exitDirection == Direction.East && entryDirection == Direction.South) ||
                (exitDirection == Direction.West && entryDirection == Direction.North) ||
                (exitDirection == Direction.North && entryDirection == Direction.East) ||
                (exitDirection == Direction.South && entryDirection == Direction.West)) { 
                //outerconnection stays as is
            }
            else if ((exitDirection == Direction.South && entryDirection == Direction.South) ||
                (exitDirection == Direction.West && entryDirection == Direction.East)) {
                _outerConnection.y -= roomHeight; }
            else if ((exitDirection == Direction.South && entryDirection == Direction.North) ||
                (exitDirection == Direction.East && entryDirection == Direction.East)) {
                _outerConnection.x += roomWidth; }
            else if (exitDirection == Direction.East && entryDirection == Direction.North) {
                _outerConnection.y += roomHeight; _outerConnection.x += roomWidth; }
            else if (exitDirection == Direction.West && entryDirection == Direction.South) {
                _outerConnection.y -= roomHeight; _outerConnection.x -= roomWidth; }
            else if (exitDirection == Direction.South && entryDirection == Direction.East) {
                _outerConnection.y -= roomHeight; _outerConnection.x += roomWidth; }
            else if (exitDirection == Direction.North && entryDirection == Direction.West) {
                _outerConnection.y += roomHeight; _outerConnection.x -= roomWidth; }*/

            _outerConnection = mapfillStart;
            if (exitDirection == Direction.North)
            {
                Debug.Log(dominantDir);

                _outerConnection.y += roomHeight;

                if (dominantDir == Direction.East)
                {
                    //keep outconnection to the top right
                    _outerConnection.x += (roomWidth - corridorWidth);
                    Debug.Log("should be top right");
                }
                // else keep connection to top left i.e. do nothing more
            }
            else if(exitDirection == Direction.South)
            {
                if (dominantDir == Direction.East)
                {
                    //keep outconnection to the bottom right
                    _outerConnection.x += roomWidth;
                }
                else
                {
                    _outerConnection.x += corridorWidth;
                }
                //else keep connection to bottom left i.e. do nothing
            }
            else if (exitDirection == Direction.East)
            {
                _outerConnection.x += roomWidth;

                if (dominantDir == Direction.North)
                {
                    //keep connection to bottom of the right wall
                    _outerConnection.y += roomHeight;
                }
                else
                {
                    //keep outconnection to the top of the right wall
                    _outerConnection.y += corridorWidth;
                }
            }
            else if (exitDirection == Direction.West)
            {
                if (dominantDir == Direction.North)
                {
                    //keep outconnection to the top of the left wall
                    _outerConnection.y += (roomHeight - corridorWidth);
                }
                //else keep connection to bottom of the left wall i.e. do nothing
            }


            /*if (exitDirection == Direction.East && entryDirection == Direction.North)
            {
                _outerConnection.y += roomHeight; _outerConnection.x += roomWidth;
            }
            else if (exitDirection == Direction.West && entryDirection == Direction.South)
            {
                _outerConnection.y -= roomHeight; _outerConnection.x -= roomWidth;
            }
            else if (exitDirection == Direction.South && entryDirection == Direction.East)
            {
                _outerConnection.y -= roomHeight; _outerConnection.x += roomWidth;
            }
            else if (exitDirection == Direction.North && entryDirection == Direction.West)
            {
                _outerConnection.y += roomHeight; _outerConnection.x -= roomWidth;
            }*/
            /*if ((exitDirection == Direction.East && entryDirection == Direction.South) ||
                (exitDirection == Direction.West && entryDirection == Direction.North) ||
                (exitDirection == Direction.North && entryDirection == Direction.East) ||
                (exitDirection == Direction.South && entryDirection == Direction.West))
            {
                //outerconnection stays as is
            }*/

            //remove exit
            if (exitDirection == Direction.North)
            {
                tile = _outerConnection;
                //tile.y--; //needed?
                for (int i = 0; i < corridorWidth; i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.x++;
                }

            }
            else if (exitDirection == Direction.South)
            {
                tile = _outerConnection;
                //tile.y--; //needed?
                for (int i = 0; i < corridorWidth; i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.x--;
                }

            }
            else if (exitDirection == Direction.East)
            {
                tile = _outerConnection;
                tile.y -= corridorWidth;
                //tile.x--; //needed?
                for (int i = 0; i < corridorWidth; i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.y++;
                }
            }
            else if (exitDirection == Direction.West)
            {
                tile = _outerConnection;
                //tile.x--; //needed?
                for (int i = 0; i < corridorWidth; i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.y++;
                }
            }


            return null;
        }
    }

    //final room
    public class FinalRoomSegment : IElement
    {
        private Direction entryDirection;

        public FinalRoomSegment(Direction entryDir)
        {
            entryDirection = entryDir;
        }

        public IEnumerator Execute()
        {
            int roomWidth = 18;
            int roomHeight = 18;

            System.Random random = new System.Random();
            int offset = random.Next(10);

            Vector3Int mapfillStart = _outerConnection;

            if (entryDirection == Direction.South)
            {
                mapfillStart.x -= roomWidth; mapfillStart.y -= roomHeight;
            }
            else if (entryDirection == Direction.East) { mapfillStart.y -= roomHeight; }
            else if (entryDirection == Direction.West) { mapfillStart.x -= roomWidth; }

            //build a walled room
            Vector3Int tile = mapfillStart;
            for (int i = 0; i < roomHeight; i++)
            {

                tile.x = mapfillStart.x - 1;

                for (int j = 0; j < roomWidth; j++)
                {

                    tile.x++;
                    _groundMap.SetTile(tile, _groundTile);

                }
                tile.y++;
            }

            //Left/Right
            tile = mapfillStart;
            for (int i = 0; i <= roomHeight; i++)
            {
                tile.x = mapfillStart.x;
                _wallMap.SetTile(tile, _brickTile1);
                tile.x = mapfillStart.x + roomWidth;
                _wallMap.SetTile(tile, _brickTile1);
                tile.y++;
            }

            //Top/Bottom
            tile = mapfillStart;
            for (int i = 0; i <= roomWidth; i++)
            {
                tile.y = mapfillStart.y;// - 1;
                _wallMap.SetTile(tile, _brickTile1);
                tile.y = mapfillStart.y + roomHeight;
                _wallMap.SetTile(tile, _brickTile1);
                tile.x++;
            }

            //remove entry
            if (entryDirection == Direction.North)
            {
                tile = _outerConnection;
                //tile.y--;
                tile.x++;
                for (int i = 0; i < (corridorWidth - 1); i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.x++;
                }

            }
            else if (entryDirection == Direction.South)
            {
                tile = _outerConnection;
                //tile.y--;
                tile.x -= corridorWidth;
                for (int i = 0; i < corridorWidth; i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.x++;
                }

            }
            else if (entryDirection == Direction.East)
            {
                tile = _outerConnection;
                tile.y -= 1;
                //tile.x -= 1;
                //tile.x--; //needed?
                for (int i = 0; i < (corridorWidth - 1); i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.y--;
                }
            }
            else if (entryDirection == Direction.West)
            {
                tile = _outerConnection;
                tile.y += corridorWidth - 1;
                //tile.x--; //needed?
                for (int i = 0; i < (corridorWidth - 1); i++)
                {
                    _wallMap.SetTile(tile, null);
                    _groundMap.SetTile(tile, _groundTile);
                    tile.y--;
                }
            }

            


            return null;
        }
    }


    //FirstCorrSegment
    public class FirstCorrSegment : IElement
    {
        private Direction entryDirection, corrDirection;

        public FirstCorrSegment(Direction entryDir, Direction corrDir)
        {
            corrDirection = corrDir;
            entryDirection = entryDir;
        }

        public IEnumerator Execute()
        {
            //Debug.Log("C1 E: " + entryDirection + ", D: " + corrDirection);

            //Draw the ground tiles
            Vector3Int curCell = _outerConnection;
            for (int i = 0; i < corridorWidth; i++)
            {
                for (int j = 0; j < corridorWidth; j++)
                {
                    curCell = _outerConnection;

                    if (entryDirection == Direction.North)
                    {
                        curCell.x += j;
                        curCell.y += i;
                    }
                    else if (entryDirection == Direction.South)
                    {
                        curCell.x -= j;
                        curCell.y -= i;
                    }
                    else if (entryDirection == Direction.East)
                    {
                        curCell.x += j;
                        curCell.y -= i;
                    }
                    else if (entryDirection == Direction.West)
                    {
                        curCell.x -= j;
                        curCell.y += i;
                    }

                    _groundMap.SetTile(curCell, _groundTile);
                }
            }

            //add walls
            Vector3Int wallCell1, wallCell2;
            curCell = _outerConnection;

            int wallWidth = corridorWidth + 1;
            //int wallWidth = corridorWidth;
            if (entryDirection == Direction.East) { curCell.y -= corridorWidth; }
            else if (entryDirection == Direction.West) { curCell.x -= corridorWidth; }
            else if (entryDirection == Direction.South) { curCell.y -= corridorWidth; curCell.x -= corridorWidth; }

            if ((corrDirection == Direction.North && entryDirection == Direction.North) ||
                (corrDirection == Direction.South && entryDirection == Direction.South))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                wallCell2.x += corridorWidth;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.y++;
                    wallCell2.y++;
                }
            }
            else if ((corrDirection == Direction.East && entryDirection == Direction.East) ||
                (corrDirection == Direction.West && entryDirection == Direction.West))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                wallCell2.y += corridorWidth;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.x++;
                    wallCell2.x++;
                }
            }
            else if ((corrDirection == Direction.East && entryDirection == Direction.North) ||
                (corrDirection == Direction.South && entryDirection == Direction.West))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                wallCell2.y += corridorWidth;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.y++;
                    wallCell2.x++;
                }
            }
            else if ((corrDirection == Direction.West && entryDirection == Direction.North) ||
                (corrDirection == Direction.South && entryDirection == Direction.East))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                wallCell1.y += corridorWidth;
                wallCell2.x += corridorWidth;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.x++;
                    wallCell2.y++;
                }
            }
            else if ((corrDirection == Direction.East && entryDirection == Direction.South) ||
                (corrDirection == Direction.North && entryDirection == Direction.West))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.y++;
                    wallCell2.x++;
                }
            }
            else if ((corrDirection == Direction.West && entryDirection == Direction.South) ||
                (corrDirection == Direction.North && entryDirection == Direction.East))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                wallCell2.x += corridorWidth;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.x++;
                    wallCell2.y++;
                }
            }

            //update inner connection point for section 2.
            _innerConnection = _outerConnection;
            if (entryDirection == Direction.North && corrDirection == Direction.North)
            {
                _innerConnection.y += corridorWidth;
            }
            else if (entryDirection == Direction.North && corrDirection == Direction.East)
            {
                _innerConnection.y += corridorWidth;
                _innerConnection.x += corridorWidth;
                _innerConnection.y -= 1;
            }
            else if (entryDirection == Direction.South && corrDirection == Direction.South)
            {
                _innerConnection.y -= corridorWidth;
            }
            else if (entryDirection == Direction.South && corrDirection == Direction.West)
            {
                _innerConnection.y -= corridorWidth;
                _innerConnection.x -= corridorWidth;
                _innerConnection.y += 1; //TODO might break later pieces
            }
            else if (entryDirection == Direction.East && corrDirection == Direction.South)
            {
                _innerConnection.y -= corridorWidth;
                _innerConnection.x += corridorWidth;
                _innerConnection.x -= 1; //TODO might break later pieces
            }
            else if (entryDirection == Direction.East && corrDirection == Direction.East)
            {
                _innerConnection.x += corridorWidth;
            }
            else if (entryDirection == Direction.West && corrDirection == Direction.North)
            {
                _innerConnection.y += corridorWidth;
                _innerConnection.x -= corridorWidth;
                _innerConnection.x += 1; //TODO might break later pieces
            }
            else if (entryDirection == Direction.West && corrDirection == Direction.West)
            {
                _innerConnection.x -= corridorWidth;
            }
            else if (entryDirection == Direction.North && corrDirection == Direction.West)
            {
                _innerConnection.x -= 1;
            }
            else if (entryDirection == Direction.South && corrDirection == Direction.East)
            {
                _innerConnection.x += 1;
            }
            else if (entryDirection == Direction.East && corrDirection == Direction.North)
            {
                _innerConnection.y += 1;
            }
            else if (entryDirection == Direction.West && corrDirection == Direction.South)
            {
                _innerConnection.y -= 1;
            }

            return null;
        }
    }

    //SecondCorrSegment
    public class SecondCorrSegment : IElement
    {
        private Direction exitDirection, corrDirection;

        public SecondCorrSegment(Direction corrDir, Direction exitDir)
        {
            corrDirection = corrDir;
            exitDirection = exitDir;
        }

        public IEnumerator Execute()
        {
            //Debug.Log("C2 D: " + corrDirection + ", E: " + exitDirection);

            //Draw the ground tiles
            Vector3Int curCell = _innerConnection;
            for (int i = 0; i < corridorWidth; i++)
            {
                for (int j = 0; j < corridorWidth; j++)
                {
                    curCell = _innerConnection;

                    if (corrDirection == Direction.North)
                    {
                        curCell.x += j;
                        curCell.y += i;
                    }
                    else if (corrDirection == Direction.South)
                    {
                        curCell.x -= j;
                        curCell.y -= i;
                    }
                    else if (corrDirection == Direction.East)
                    {
                        curCell.x += j;
                        curCell.y -= i;
                    }
                    else if (corrDirection == Direction.West)
                    {
                        curCell.x -= j;
                        curCell.y += i;
                    }

                    //_groundMap.SetTile(curCell, _brickTile1);
                    _groundMap.SetTile(curCell, _groundTile);
                }
            }

            //add walls
            Vector3Int wallCell1, wallCell2;
            curCell = _innerConnection;

            int wallWidth = corridorWidth + 1;
            if (corrDirection == Direction.East) { curCell.y -= corridorWidth; }
            else if (corrDirection == Direction.West) { curCell.x -= corridorWidth; }
            else if (corrDirection == Direction.South) { curCell.y -= corridorWidth; curCell.x -= corridorWidth; }

            if ((corrDirection == Direction.North && exitDirection == Direction.North) ||
                (corrDirection == Direction.South && exitDirection == Direction.South))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                wallCell2.x += corridorWidth;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.y++;
                    wallCell2.y++;
                }
            }
            else if ((corrDirection == Direction.East && exitDirection == Direction.East) ||
                (corrDirection == Direction.West && exitDirection == Direction.West))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                wallCell2.y += corridorWidth;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.x++;
                    wallCell2.x++;
                }
            }
            else if ((corrDirection == Direction.North && exitDirection == Direction.East) ||
                (corrDirection == Direction.West && exitDirection == Direction.South))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                wallCell2.y += corridorWidth;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.y++;
                    wallCell2.x++;
                }
            }
            else if ((corrDirection == Direction.North && exitDirection == Direction.West) ||
                (corrDirection == Direction.East && exitDirection == Direction.South))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                wallCell1.y += corridorWidth;
                wallCell2.x += corridorWidth;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.x++;
                    wallCell2.y++;
                }
            }
            else if ((corrDirection == Direction.South && exitDirection == Direction.East) ||
                (corrDirection == Direction.West && exitDirection == Direction.North))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.y++;
                    wallCell2.x++;
                }
            }
            else if ((corrDirection == Direction.South && exitDirection == Direction.West) ||
                (corrDirection == Direction.East && exitDirection == Direction.North))
            {
                wallCell1 = curCell;
                wallCell2 = curCell;
                wallCell2.x += corridorWidth;
                for (int i = 0; i < wallWidth; i++)
                {
                    _wallMap.SetTile(wallCell1, _brickTile1);
                    _wallMap.SetTile(wallCell2, _brickTile1);
                    wallCell1.x++;
                    wallCell2.y++;
                }
            }

            //update outer connection point for section 1.
            _outerConnection = _innerConnection;
            if (exitDirection == Direction.North && corrDirection == Direction.North)
            {
                _outerConnection.y += corridorWidth;
            }
            else if (exitDirection == Direction.North && corrDirection == Direction.West)
            {
                _outerConnection.y += corridorWidth;
                _outerConnection.x -= corridorWidth;
                _outerConnection.x += 1; //TODO might break later parts
            }
            else if (exitDirection == Direction.South && corrDirection == Direction.South)
            {
                _outerConnection.y -= corridorWidth;
            }
            else if (exitDirection == Direction.South && corrDirection == Direction.East)
            {
                _outerConnection.y -= corridorWidth;
                _outerConnection.x += corridorWidth;
                _outerConnection.x -= 1;
            }
            else if (exitDirection == Direction.East && corrDirection == Direction.North)
            {
                _outerConnection.y += corridorWidth;
                _outerConnection.y -= 1; //TODO might break later parts
                _outerConnection.x += corridorWidth;
            }
            else if (exitDirection == Direction.East && corrDirection == Direction.East)
            {
                _outerConnection.x += corridorWidth;
            }
            else if (exitDirection == Direction.West && corrDirection == Direction.South)
            {
                _outerConnection.y -= corridorWidth;
                _outerConnection.x -= corridorWidth;
                _outerConnection.y += 1; //TODO might break later parts
            }
            else if (exitDirection == Direction.West && corrDirection == Direction.West)
            {
                _outerConnection.x -= corridorWidth;
            }
            else if (exitDirection == Direction.North && corrDirection == Direction.East)
            {
                _outerConnection.y += 1;
            }
            else if (exitDirection == Direction.South && corrDirection == Direction.West)
            {
                _outerConnection.y -= 1;
            }
            else if (exitDirection == Direction.East && corrDirection == Direction.South)
            {
                _outerConnection.x += 1;
            }
            else if (exitDirection == Direction.West && corrDirection == Direction.North)
            {
                _outerConnection.x -= 1;
            }

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
