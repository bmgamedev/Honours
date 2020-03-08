using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour {

    public float LifeSpan = 2;
    public float maxSpeed = 5.0f;
    public float Damage = 10;

    public GameObject player;
    private GameObject endPoint;
    private Vector3 pos;
    private Vector3 velocity;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //endPoint = GameObject.Find("EndPoint");
        player = null;

        velocity = new Vector3(maxSpeed * Time.deltaTime, 0, 0);
        pos = transform.position;
    }

    IEnumerator Start()
    {
        while (player == null) { yield return new WaitForEndOfFrame(); } //delay firing until there's a player? Dunno if this will work 

        if (endPoint.transform.position.x > player.transform.position.x)
        {
            velocity = new Vector3(maxSpeed * 1 * Time.deltaTime, 0, 0);
        }
        else
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            velocity = new Vector3(maxSpeed * -1 * Time.deltaTime, 0, 0);
        }

        yield return null;
    }

    public void SetPlayer(GameObject p)
    {
        player = p;
        endPoint = p.transform.GetChild(0).gameObject;
    }

    void Update ()
    {
        pos += velocity;
        transform.position = pos;
        Destroy(this.gameObject, LifeSpan);
    }
}
