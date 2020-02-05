using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLasers : MonoBehaviour {

    public float FireRate = 0;
    //public float Damage = 10;
    public LayerMask Destroyables;
    public Transform LaserTrailPrefab;
    public float effectSpawnRate = 10;

    private float timeToSpawnEffect = 0;
    private float nextShot = 0; //TODO rename
    private Transform firingPoint;
    private Transform endPoint;

    // Use this for initialization
    void Awake () {
        firingPoint = transform.Find("FiringPoint");
        if (firingPoint == null)
        {
            Debug.LogError("cannot find the FiringPoint component");
        }

        endPoint = transform.Find("EndPoint");
        if (endPoint == null)
        {
            Debug.LogError("cannot find the EndPoint component");
        }
    }

    void FixedUpdate()
    {
        //Shoot(); //just for debugging
        if (FireRate == 0) //single burst
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Shoot();
            }
        }
        else //not single burst (i.e. automatic)
        {
            if ((Input.GetKeyDown(KeyCode.E)) && Time.time > nextShot)
            {
                nextShot = Time.time + 1 / FireRate;
                Shoot();
            }
        }
	}

    void Shoot()
    {
        Vector2 endPosition = new Vector2(endPoint.position.x, endPoint.position.y);
        Vector2 firePointPosition = new Vector2(firingPoint.position.x, firingPoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, endPosition - firePointPosition, 100, Destroyables);
        if (Time.time >= timeToSpawnEffect) //TODO replace with object pooling at some point
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }

        //FOR DEBUGGING
        //Debug.DrawLine(firePointPosition, (endPosition - firePointPosition) * 10, Color.cyan);
        //if (hit.collider != null)
        //{
        //    Debug.DrawLine(firePointPosition, hit.point, Color.red);
        //    Debug.Log("Hit: " + hit.collider.name + ", Damage: " + Damage);
        //}
    }

    void Effect()
    {
        Instantiate(LaserTrailPrefab, firingPoint.position, firingPoint.rotation);
    }
}

    