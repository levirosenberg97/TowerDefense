using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTurret : MonoBehaviour
{
    public float distance;
    public MoneyTracker money;
    public Material removalMaterial;
	
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
            if (Input.GetMouseButtonDown(0))
            {
                PooledObject pooledObject = other.GetComponentInParent<PooledObject>();
                TurretManager turret = other.GetComponentInParent<TurretManager>();
                MineTurretScript mineTurret = other.GetComponentInParent<MineTurretScript>();

                if(pooledObject != null)
                {
                    foreach (Transform child in other.transform.parent.transform)
                    {
                        MaterialManager childMaterial = child.GetComponent<MaterialManager>();
                        if (childMaterial != null)
                        {
                            childMaterial.DefaultMaterial();
                        }
                    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            foreach (Transform child in other.transform.parent.transform)
            {
                MaterialManager childMaterial = child.GetComponent<MaterialManager>();
                if (childMaterial != null)
                {
                    childMaterial.TurnRed();
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 11)
        {
            foreach(Transform child in other.transform.parent.transform)
            {
                MaterialManager childMaterial = child.GetComponent<MaterialManager>();
                if (childMaterial != null)
                {
                    childMaterial.DefaultMaterial();
                }
            }
        }
    }

    void Update ()
    {
        GoToMouse();
    }
}
