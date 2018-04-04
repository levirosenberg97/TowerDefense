using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public List<Transform> targets;
    public string objectTag;
    private Transform selectedObject;
    private Transform MyTransform;

    public int damage;
    public float timeBetweenShots;
    Ray shootRay;
    RaycastHit shootHit;
    float timer;
    float range = 100f;
    int shootableMask;

    //ParticleSystem gunParticles;
    LineRenderer gunLine;
    Light gunLight;
    public float effectsTime;


    private void Start()
    {
        shootableMask = LayerMask.GetMask("Shootable");

        targets = new List<Transform>();
        MyTransform = transform;
        //gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();

        timer = 0f;
    }

    void Shoot()
    {
        timer = 0f;

        gunLight.enabled = true;
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        //gunParticles.Play();
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast(shootRay,out shootHit,range, shootableMask))
        {
            TankHealth tankHealth = shootHit.collider.GetComponent<TankHealth>();

            if (tankHealth != null)
            {
                tankHealth.TakeDamage(damage);
            }

            

            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

    void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
        //gunParticles.Stop();
    }

    //public void AddAllObjects()
    //{
    //    GameObject[] gos = GameObject.FindGameObjectsWithTag(objectTag);

    //    foreach(GameObject thing in gos)
    //    {
    //        if (!targets.Contains(thing.transform))
    //        {
    //            AddTarget(thing.transform);
    //        }
    //    }
    //}

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

    private void Update()
    {
        timer += Time.deltaTime;
        if (targets.Count > 0)
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
                    Shoot();
                }

                if (timer >= timeBetweenShots * effectsTime)
                {
                    DisableEffects();
                }

                transform.LookAt(selectedObject);
            }

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
