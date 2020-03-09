using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPacing2 : MonoBehaviour {

    private Vector2 pointA;
    private Vector2 pointB;
    private int paceDirection = 1; // 1 = move right/up, -1 = move left/down
    private Rigidbody2D rb2d;
    private Vector2 targetVelocity;
    [SerializeField] private float movementSpeed = 2;
    [SerializeField] private int paceDistance = 1;

    private enum PaceAxis { Horizontal, Vertical };
    [SerializeField] private PaceAxis paceAxis;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        pointA.x = GameObject.Find("PointAx").GetComponent<Transform>().position.x;
        pointB.x = GameObject.Find("PointBx").GetComponent<Transform>().position.x;
        pointA.y = GameObject.Find("PointBy").GetComponent<Transform>().position.y; //got these the wrong way round in the scene
        pointB.y = GameObject.Find("PointAy").GetComponent<Transform>().position.y; //got these the wrong way round in the scene
    }

    void Update ()
    {
        float rbPos, pointb, pointa;

        if (paceAxis == PaceAxis.Horizontal)
        {
            rbPos = rb2d.position.x;
            pointb = pointB.x;
            pointa = pointA.x;

            if (rbPos >= pointb)
            {
                paceDirection = -1;
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime, 0);
            }
            else if (rbPos < pointb && rbPos > pointa && paceDirection == -1)
            {
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime, 0);
            }
            else if (rbPos < pointb && rbPos > pointa && paceDirection == 1)
            {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, 0);
            }
            else if (rbPos <= pointa)
            {
                paceDirection = 1;
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, 0);
            }
        }
        else
        {
            rbPos = rb2d.position.y;
            pointb = pointB.y;
            pointa = pointA.y;

            if (rbPos >= pointb)
            {
                paceDirection = -1;
                transform.Translate(Vector2.down * movementSpeed * Time.deltaTime, 0);
            }
            else if (rbPos < pointb && rbPos > pointa && paceDirection == -1)
            {
                transform.Translate(Vector2.down * movementSpeed * Time.deltaTime, 0);
            }
            else if (rbPos < pointb && rbPos > pointa && paceDirection == 1)
            {
                transform.Translate(Vector2.up * movementSpeed * Time.deltaTime, 0);
            }
            else if (rbPos <= pointa)
            {
                paceDirection = 1;
                transform.Translate(Vector2.up * movementSpeed * Time.deltaTime, 0);
            }

        }
    }

    public void SetPaceAxis(string axis)
    {
        if (axis.Equals("Horizontal"))
        {
            paceAxis = PaceAxis.Horizontal;
            pointA = rb2d.position - new Vector2(paceDistance, 0);
            pointB = rb2d.position + new Vector2(paceDistance, 0);
        }
        else
        {
            paceAxis = PaceAxis.Vertical;
            pointA = rb2d.position - new Vector2(0, paceDistance);
            pointB = rb2d.position + new Vector2(0, paceDistance);
        }
    }

    /*public void SetPaceDistance(float dist)
    {
        if (paceAxis == PaceAxis.Horizontal)
        {
            pointA = rb2d.position - new Vector2(dist, 0);
            pointB = rb2d.position + new Vector2(dist, 0);
        }
        else
        {
            pointA = rb2d.position - new Vector2(0, dist);
            pointB = rb2d.position + new Vector2(0, dist);
        }
    }*/
}
