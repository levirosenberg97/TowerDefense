using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseFollow : MonoBehaviour
{
    public float distance = 1.0f;
    ObjectPool pool;
    
    public bool canSpawn;

    public int value;
    public MoneyTracker money;

    private void Awake()
    {
        canSpawn = false;
    }

    void Start ()
    {
        pool = GetComponent<ObjectPool>();
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if(other.tag == "Spawnable")
        {

            if (value <= money.dollarAmount)
            {
                canSpawn = true;
            }
            else
            {
                canSpawn = false;
            }

          
        }

        if (other.gameObject.layer == 11)
        {
            canSpawn = false;
        }

        foreach (Transform child in transform)
        {
            MaterialManager childMaterial = child.GetComponent<MaterialManager>();

            if (childMaterial != null)
            {
                if (canSpawn == true)
                {
                    childMaterial.DefaultMaterial();
                }
                else
                {
                    childMaterial.TurnRed();
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.tag);

        if (other.gameObject.layer == 11)
        {
            foreach (Transform child in transform)
            {
                MaterialManager childMaterial = child.GetComponent<MaterialManager>();
                if (childMaterial != null)
                {
                    if (value <= money.dollarAmount)
                    {
                        childMaterial.DefaultMaterial();
                    }
                    else
                    {
                        childMaterial.TurnRed();
                    }
                }
                canSpawn = true;
            }
        }

        if (other.tag == "Spawnable")
        {
            foreach(Transform child in transform)
            {
                MaterialManager childMaterial = child.GetComponent<MaterialManager>();
                if (childMaterial != null)
                {
                    childMaterial.TurnRed();
                }
                
            }

            canSpawn = false;
        }

        
    }

    void GoToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = distance;

        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void SpawnObject()
    {
        GameObject spawnedObject = pool.GetObject();
        spawnedObject.transform.position = transform.position;

        TurretManager turret = spawnedObject.GetComponent<TurretManager>();
        MineTurretScript mineTurret = spawnedObject.GetComponent<MineTurretScript>();
        if (turret != null)
        {
            turret.value = value;
        }
        if (mineTurret != null)
        {
            mineTurret.value = value;
        }

        spawnedObject.SetActive(true);
    }

	void Update ()
    {
        GoToMouse();
        if(Input.GetMouseButtonDown(0))
        {
            if (canSpawn == true)
            {
                if(value <= money.dollarAmount)
                {
                    //Debug.Log("pressed");
                    money.MoneyChange(-value);
                    SpawnObject();
                }
            }
        }
        
	}
}
