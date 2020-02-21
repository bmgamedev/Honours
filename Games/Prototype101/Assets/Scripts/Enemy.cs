using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float HealthPoints = 0;
    public int DamagePoints = 0;
    //public bool IsEnemy = true; //for enemies that also shoot - none as of yet

    public void Damage(float damageCount)
    {
        HealthPoints -= damageCount;

        if (HealthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //TODO add some sort of jumping - seperate script? (also make it so that it can be turned off for enemies that shouldn't jump)

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == 11) //layer 11 is the projectile layer
        {
            LaserMovement laser = otherCollider.gameObject.GetComponent<LaserMovement>();

            if (laser != null)
            {
                //if (laser.IsEnemyFire != IsEnemy) //for later enemies
                //{
                Damage(laser.Damage);
                Destroy(laser.gameObject);
                //}
            }
        }

    }
}
