using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTracker : MonoBehaviour
{
    public Text dollarTracker;
    public int dollarAmount;

	// Use this for initialization
	void Start ()
    {
        dollarTracker.text = "$ " + dollarAmount.ToString();		
	}

    public void MoneyChange(int change)
    {
        dollarAmount += change;
        dollarTracker.text = "$ " + dollarAmount.ToString();
    }

}
