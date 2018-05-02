using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class TurretManager : MonoBehaviour
{
    public List<Transform> targets;
    public string objectTag;
    private Transform selectedObject;
    private Transform MyTransform;

    public int damage;
    public float timeBetweenShots;

    public float rotationSpeed;

    float timer;
    float range = 100f;
    int shootableMask;

    public int value;

    ShootingScript shoot;
   


    private void Start()
    {
        shoot = GetComponent<ShootingScript>();

        shootableMask = LayerMask.GetMask("Shootable");

        targets = new List<Transform>();
        MyTransform = transform;
   
      
        timer = 0f;
    }


    public void AddTarget(Transform thing)
    {
        targets.Add(thing);
    }

    private void SortTargetsByDistance()
    {
        targets.Sort(delegate (Transform t1, Transform t2)
        {
            return Vector3.Distance(t1.position, MyTransform.position).CompareTo
            (Vector3.Distance(t2.position, MyTransform.position));
        });
    }

    void FireOnTarget()
    {
        if (targets[0] != null)
        {
            SortTargetsByDistance();
            selectedObject = targets[0];

            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].gameObject.activeInHierarchy == false)
                {
                    targets.Remove(targets[i]);
                }
            }

            if (selectedObject != null && timer >= timeBetweenShots)
            {
                shoot.Fire();
                timer = 0;
            }


            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(selectedObject.transform.position - transform.position), Time.deltaTime * rotationSpeed);

        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (targets.Count > 0)
        {
            FireOnTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == objectTag)
        {
            targets.Add(other.gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == objectTag)
        {
            targets.Remove(other.gameObject.transform);
        }
    }

}
