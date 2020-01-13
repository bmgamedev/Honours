using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreationManager : MonoBehaviour {

    public static CreationManager instance;

    static Transform startPos;

    Camera[] cameras;
    static Camera cam1, cam2A, cam2B, cam4A, cam4B, cam4C, cam4D;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        startPos = GameObject.Find("StartPos").transform;
        Debug.Log("startPos = " + startPos.position);

        cameras = FindObjectsOfType<Camera>();
        foreach (Camera camera in cameras)
        {
            camera.enabled = false;
        }

        cam1 = GameObject.Find("SinglePlayer").GetComponent<Camera>();
        cam2A = GameObject.Find("TwoPlayerA").GetComponent<Camera>();
        cam2B = GameObject.Find("TwoPlayerB").GetComponent<Camera>();
        cam4A = GameObject.Find("FourPlayerA").GetComponent<Camera>();
        cam4B = GameObject.Find("FourPlayerB").GetComponent<Camera>();
        cam4C = GameObject.Find("FourPlayerC").GetComponent<Camera>();
        cam4D = GameObject.Find("FourPlayerD").GetComponent<Camera>();
    }

    public static void CreatePlayer(int i) {

        GameObject Player = Instantiate(Resources.Load("PlayerPrefab"), startPos) as GameObject;
        //Player.transform.SetParent(null);
        //Instantiate(Resources.Load("PlayerPrefab"), startPos);
        SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName("Game"));


        //Vector3 startPos = (0+(i*4), 0, 0);
        //Instantiate(Resources.Load("PlayerPrefab"), startPos, Quaternion.identity);
        //Object Player = Object.Instantiate(Resources.Load("PlayerPrefab"), startPos, Quaternion.identity) as Object;

    }

    public static void UpdateCamera(GameObject Player, string camName) {
        //Add the player to the cam target
        CamFollow MainCameraTarget = GameObject.Find(camName).GetComponent<CamFollow>();
        if (MainCameraTarget != null) {
            MainCameraTarget.target = Player.transform;
        }
    }

    public static void CameraSetup(int _num) {

        switch (_num)
        {
            //case 1:

            //break;
            case 2:
                cam2A.enabled = true;
                cam2B.enabled = true;
                break;
            case 3:
                cam4A.enabled = true;
                cam4B.enabled = true;
                cam4C.enabled = true;
                break;
            case 4:
                cam4A.enabled = true;
                cam4B.enabled = true;
                cam4C.enabled = true;
                cam4D.enabled = true;
                break;
            default:
                cam1.enabled = true;
                break;
        }
    }
}
