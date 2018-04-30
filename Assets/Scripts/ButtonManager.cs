using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject baseCursor;
    public GameObject mineCursor;
    public GameObject sniperCursor;
    public GameObject deleteCursor;


    public void BaseTurretSelect()
    {
        baseCursor.SetActive(true);
        mineCursor.SetActive(false);
        sniperCursor.SetActive(false);
        deleteCursor.SetActive(false);
    }

    public void MineSelect()
    {
        baseCursor.SetActive(false);
        mineCursor.SetActive(true);
        sniperCursor.SetActive(false);
        deleteCursor.SetActive(false);
    }

    public void SniperSelect()
    {
        baseCursor.SetActive(false);
        mineCursor.SetActive(false);
        sniperCursor.SetActive(true);
        deleteCursor.SetActive(false);
    }

    public void DeleteSelect()
    {
        baseCursor.SetActive(false);
        mineCursor.SetActive(false);
        sniperCursor.SetActive(false);
        deleteCursor.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

