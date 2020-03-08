using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private PlayerMgmt playerMgmt, playerMgmt2;

    public float HealthPoints = 0;
    public int DamagePoints = 0;
    //public bool IsEnemy = true; //for enemies that also shoot - none as of yet

    private int interactingPlayer = 1; //2 == player2, 1 == player1

    private void Awake()
    {
        
        if (GameObject.Find("Player1").GetComponent<PlayerMgmt>() != null)
        {
            playerMgmt = GameObject.Find("Player1").GetComponent<PlayerMgmt>();
        }

        if (GameObject.Find("Player2").GetComponent<PlayerMgmt>() != null)
        {
            playerMgmt2 = GameObject.Find("Player2").GetComponent<PlayerMgmt>();
        }
    }

    public void Damage(float damageCount)
    {
        HealthPoints -= damageCount;

        if (HealthPoints <= 0)
        {
            if(interactingPlayer == 1 && playerMgmt != null) { playerMgmt.AddPoints(200); }
            else if (interactingPlayer == 2 && playerMgmt2 != null) { playerMgmt2.AddPoints(200); }
            
            Destroy(this.gameObject);
        }

        if (interactingPlayer == 1 && playerMgmt != null) { playerMgmt.AddPoints(50); }
        else if (interactingPlayer == 2 && playerMgmt2 != null) { playerMgmt2.AddPoints(50); }
    }

    //TODO add some sort of jumping - seperate script? (also make it so that it can be turned off for enemies that shouldn't jump)

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == 11) //layer 11 is the projectile layer
        {
            LaserMovement laser = otherCollider.gameObject.GetComponent<LaserMovement>();

            if(laser.player.name.Equals("Player2")) { interactingPlayer = 2; }
            else { interactingPlayer = 1; }

            if (laser != null)
            {
                Damage(laser.Damage);
                Destroy(laser.gameObject);
            }
        }

    }
}
