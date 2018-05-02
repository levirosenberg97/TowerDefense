using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    int waveNumber;

    public int enemiesSpawned;

    public int tankHealth;

    public float spawnTime;

    public float timer;
    float startingTime;

    

    public Text timerText;
    public Text waveText;
	// Use this for initialization
	void Start ()
    {
        waveNumber = 1;
        waveText.text = "Wave: " + waveNumber.ToString();
        startingTime = timer;
	}

    public void  WaveChange()
    {
        timer = startingTime + (5 * waveNumber);
        waveText.text = "Wave: " + waveNumber.ToString();
        tankHealth += 50;
        enemiesSpawned += 3;
        if (spawnTime > 2)
        {
            spawnTime -= .5f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
     
        timer -= Time.deltaTime;
        float seconds = Mathf.RoundToInt(timer);

        if(timer <= 0)
        {
            waveNumber++;
            WaveChange();
        }

        timerText.text = "Next Wave: " + seconds;

        if (Input.GetKey(KeyCode.Tab))
        {
            Time.timeScale += 1;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale -= 1;
        }

    }
}
