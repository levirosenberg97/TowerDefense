using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject pooledObjects;
    public Stack<GameObject> pool;

    public int pooledAmount;

    //spawns our prefab, adds it to stack , and assigns parent to ourselves
	void Start ()
    {
        pool = new Stack<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject spawnedObj = Instantiate(pooledObjects);
            spawnedObj.transform.SetParent(transform);
            spawnedObj.GetComponent<PooledObject>().myPool = this;
            spawnedObj.SetActive(false);
            pool.Push(spawnedObj);
        }
	}

    public GameObject GetObject()
    {
        if(pool.Count > 0)
        {
            GameObject poppedObj = pool.Pop();
            poppedObj.transform.SetParent(null);
            //poppedObj.SetActive(true);
            return poppedObj;
        }
        else
        {
            pooledAmount *= 2;
            
            for(int i = 0; i < pooledAmount; i++)
            {
                GameObject spawnedObj = Instantiate(pooledObjects);
                spawnedObj.transform.SetParent(transform);
                spawnedObj.GetComponent<PooledObject>().myPool = this;
                spawnedObj.SetActive(false);
                pool.Push(spawnedObj);
            }
            Debug.Log("pool was empty");

            GameObject poppedObj = pool.Pop();
            poppedObj.transform.SetParent(null);
            //poppedObj.SetActive(true);
            return poppedObj;
        }
    }
}