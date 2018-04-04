using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public string tagName;


    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;

        gos = GameObject.FindGameObjectsWithTag(tagName);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            

            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    // Use this for initialization

   

    public GameObject[] gos;

    public int maxRange;
    public int minRange;
    private Vector3 targetTran;


	void Start ()
    {
   
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject target = FindClosestEnemy();

		if ((Vector3.Distance(transform.position,target.transform.position) < maxRange)&& Vector3.Distance(transform.position, target.transform.position) > minRange)
        {
            transform.LookAt(targetTran);

            transform.Translate(Vector3.forward * Time.deltaTime);
        }
	}
}
