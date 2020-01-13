using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{

    public float dampTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    static CamFollow instance = null;


    void Awake()
    {
        /*if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }*/
    }

    private void Start()
    {
        //GameObject Player = GameObject.Find("PlayerPrefab");
        //target = Player.transform;
    }

    void Update()
    {
        if (target != null) {
            //if (target.position.x != 0 || target.position.y != 0) {
                Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
                Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.4f, point.z));
                //Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.3f, 0.4f, point.z));
                Vector3 destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            //}
        }
        
    }

}