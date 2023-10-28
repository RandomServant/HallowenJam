using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GameObject;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public Button PlayBut;
    public Button NewGameBut;
    void Start()
    {

        if (PlayerPrefs.GetInt("LevelsCompleted") == 0)
        {
            //GetComponent<Button>();
            PlayBut.gameObject.SetActive(false);
            NewGameBut.gameObject.SetActive(true);
        }
        else
        {
            PlayBut.gameObject.SetActive(true);
            NewGameBut.gameObject.SetActive(false);
        }
    }

   public void Play()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("LevelsCompleted", 1);

    }


   public void Exit()
    {
        Application.Quit();
    }
}

