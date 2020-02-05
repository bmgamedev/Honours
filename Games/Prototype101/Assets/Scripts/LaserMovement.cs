using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour {

    public float LifeSpan = 2;
    public float maxSpeed = 5.0f;
    public float Damage = 10;

    private GameObject player;
    private GameObject endPoint;
    private Vector3 pos;
    private Vector3 velocity;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        endPoint = GameObject.Find("EndPoint");

        velocity = new Vector3(maxSpeed * Time.deltaTime, 0, 0);
        pos = transform.position;
    }

    void Start()
    {
        if (endPoint.transform.position.x > player.transform.position.x)
        {
            velocity = new Vector3(maxSpeed * 1 * Time.deltaTime, 0, 0);
        }
        else
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            velocity = new Vector3(maxSpeed * -1 * Time.deltaTime, 0, 0);
        }
    }

    void Update ()
    {
        pos += velocity;
        transform.position = pos;
        Destroy(this.gameObject, LifeSpan);
    }
}
