using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPacing : PhysicsObject {

    public Vector2 moveDistance = new Vector2(10, 0);

    private Vector2 pointA;
    private Vector2 pointB;
    private int paceDirection = 1; // 1 = move right/up, -1 = move left/down

    [SerializeField]
    private int paceDistance = 1;

    private enum PaceAxis { Horizontal, Vertical };
    private PaceAxis paceAxis;

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
                targetVelocity = Vector2.left;
            }
            else if (rbPos < pointb && rbPos > pointa && paceDirection == -1)
            {
                targetVelocity = Vector2.left;
            }
            else if (rbPos < pointb && rbPos > pointa && paceDirection == 1)
            {
                targetVelocity = Vector2.right;
            }
            else if (rbPos <= pointa)
            {
                paceDirection = 1;
                targetVelocity = Vector2.right;
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
                targetVelocity = Vector2.down;
            }
            else if (rbPos < pointb && rbPos > pointa && paceDirection == -1)
            {
                targetVelocity = Vector2.down;
            }
            else if (rbPos < pointb && rbPos > pointa && paceDirection == 1)
            {
                targetVelocity = Vector2.up;
            }
            else if (rbPos <= pointa)
            {
                paceDirection = 1;
                targetVelocity = Vector2.up;
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
