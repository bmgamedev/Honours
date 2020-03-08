using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLasers : MonoBehaviour {

    public float FireRate = 0;
    public LayerMask Destroyables;
    public float effectSpawnRate = 10;

    private float timeToSpawnEffect = 0;
    private float nextShot = 0;
    private Transform firingPoint;
    private Transform endPoint;
    private Animator animator;

    //private string inputFire;
    private KeyCode inputFire;

    void Awake ()
    {
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

        animator = GetComponentInParent<Animator>();// GetComponent<Animator>();
        if (animator == null) { Debug.Log("cannot find animator"); }
    }

    private void Start()
    {
        //define inputs for each player
        if (gameObject.name == "Player2")
        {
            inputFire = KeyCode.Keypad0;
            //inputFire = "Shoot2";
        }
        else
        {
            inputFire = KeyCode.E;
            //inputFire = "Shoot1";
        }
    }

    void FixedUpdate()
    {
        //Shoot(); //just for debugging
        if (FireRate == 0) //single burst
        {
            if (Input.GetKeyDown(inputFire))
            //if (Input.GetButton(inputFire))
            {
                Shoot();
            }
        }
        else //not single burst (i.e. automatic)
        {
            if ((Input.GetKeyDown(inputFire)) && Time.time > nextShot)
            //if (Input.GetButton(inputFire) && Time.time > nextShot)
            {
                animator.SetBool("isShooting", true);
                nextShot = Time.time + 1 / FireRate;
                Shoot();
                animator.SetBool("isShooting", false);
            }
        }
	}

    void Shoot()
    {
        Vector2 endPosition = new Vector2(endPoint.position.x, endPoint.position.y);
        Vector2 firePointPosition = new Vector2(firingPoint.position.x, firingPoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, endPosition - firePointPosition, 100, Destroyables);
        if (Time.time >= timeToSpawnEffect) 
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
    }

    void Effect()
    {
        GameObject laser = (GameObject)Instantiate(Resources.Load("Laser"), firingPoint.position, firingPoint.rotation) as GameObject;
        laser.GetComponent<LaserMovement>().SetPlayer(gameObject);
    }
}

    