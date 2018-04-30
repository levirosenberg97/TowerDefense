using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Material[] material;

    Renderer rend;
    

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
	}

    public void DefaultMaterial()
    {
        rend.sharedMaterial = material[0];
    }

    public void TurnRed()
    {
        rend.sharedMaterial = material[1];
    }
}
