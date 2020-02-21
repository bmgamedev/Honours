using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPacing : PhysicsObject {

    public Vector2 moveDistance = new Vector2(10, 0);

    private Vector2 pointA;
    private Vector2 pointB;
    private int paceDirection = 1; // 1 = move right, -1 = move left

    private void Start()
    {
        //pointA = rb2d.position; //rb2d is from the PhysicsObject class that this class is inherited from
        //pointB = pointA + moveDistance;
    }

    void Update () {

        if (rb2d.position.x >= pointB.x)
        {
            paceDirection = -1;
            targetVelocity = Vector2.left;
        }
        else if (rb2d.position.x < pointB.x && rb2d.position.x > pointA.x && paceDirection == -1)
        {
            targetVelocity = Vector2.left;
        }
        else if (rb2d.position.x < pointB.x && rb2d.position.x > pointA.x && paceDirection == 1)
        {
            targetVelocity = Vector2.right;
        }
        else if (rb2d.position.x <= pointA.x)
        {
            paceDirection = 1;
            targetVelocity = Vector2.right;
        }
    }

    public void SetPaceDistance(float dist)
    {
        pointA = rb2d.position - new Vector2(dist, 0);
        pointB = rb2d.position + new Vector2(dist, 0);
    }
}
