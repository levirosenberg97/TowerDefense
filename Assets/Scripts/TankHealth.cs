using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour , IDamageable<int>
{
    public int health;
    int startingHealth;

    public bool isDead = false;
    public int moneyValue;
    PooledObject pooledObject;
    public MoneyTracker moneyTracker;

    private void Start()
    {
        startingHealth = health;
        pooledObject = GetComponent<PooledObject>();
    }

    public void Damage(int damage)
    {
        health -= damage;
    }

    void Death()
    {
        isDead = true;
        moneyTracker.MoneyChange(moneyValue);
        health = startingHealth;
        pooledObject.returnToPool();

    }

    private void Update()
    {
        if (this.health <= 0)
        {
            Death();
        }
    }
}
