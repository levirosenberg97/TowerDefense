using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public int health;
    public bool isDead = false;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Death()
    {
        isDead = true;
        gameObject.SetActive(false);
        
    }


    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }
}
