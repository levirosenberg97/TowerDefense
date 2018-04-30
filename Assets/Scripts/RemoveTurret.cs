using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTurret : MonoBehaviour
{
    public float distance;
    public MoneyTracker money;
	
	void Start ()
    {
		
	}

    void GoToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = distance;

        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 11)
        {
            if(Input.GetMouseButtonDown(0))
            {
                PooledObject pooledObject = other.GetComponentInParent<PooledObject>();
                TurretManager turret = other.GetComponentInParent<TurretManager>();
                MineTurretScript mineTurret = other.GetComponentInParent<MineTurretScript>();

                if(pooledObject != null)
                {
                    pooledObject.returnToPool();
                    if (turret != null)
                    {
                        money.MoneyChange(turret.value / 2);
                    }
                    if(mineTurret != null)
                    {
                        money.MoneyChange(mineTurret.value / 2);
                    }
                }
            }
        }
    }

    void Update ()
    {
        GoToMouse();
    }
}
