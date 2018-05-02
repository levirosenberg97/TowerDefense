using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHealth : MonoBehaviour
{
    public Slider healthSlider;

    public int startingHealth;
    int currentHealth;
    public int damage;

    public Canvas gameOverCanvas;
    public Canvas gameCanvas;

	// Use this for initialization
	void Start ()
    {
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Tank")
        {
            Damaged();
            other.GetComponent<PooledObject>().returnToPool();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
    }

    void Damaged()
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            GameOver();
        }
    }
}
