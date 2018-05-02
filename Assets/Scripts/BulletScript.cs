using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
 
    public float bulletLife;
    PooledObject pooledObject;
    float maxLife;
    public int damage;

	void Start ()
    {
        maxLife = bulletLife;
        pooledObject = GetComponent<PooledObject>();
      
	}


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Tank")
        {
            other.collider.GetComponent<IDamageable<int>>().Damage(damage);
            //Debug.Log("Hit");
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        bulletLife = maxLife;
        pooledObject.returnToPool();
    }

    void Update ()
    {
        bulletLife -= Time.deltaTime;

        if(bulletLife <= 0)
        {
            DestroyBullet();
        }
	}
}
