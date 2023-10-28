using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GameObject;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LvlManagerScript : MonoBehaviour
{
    int LastCompletedLvl ;
    public Button[] Levels;
    // Start is called before the first frame update
    void Start()
    {
        VisibilityLevels();
    }

    public void  PlayLevel(int indexLvl)
    {
        SceneManager.LoadScene(indexLvl+1);
        //PlayerPrefs.SetInt("LevelsCompleted", indexLvl+1);
    }

    public void DeleteInfoLvl()
    {
        PlayerPrefs.SetInt("LevelsCompleted", 1);
        VisibilityLevels();
    }

    void VisibilityLevels()
    {
        LastCompletedLvl = PlayerPrefs.GetInt("LevelsCompleted");
        for (int i = 0; i < Levels.Length; i++)
        {
            if (i >= LastCompletedLvl)
            {
                Levels[i].interactable = false;
            }
        }
    }

    public void NextLevel()
    {
        int indexNextLvl = SceneManager.GetActiveScene().buildIndex + 1;
        if (indexNextLvl > 11)
        {
            indexNextLvl = 2;
        }
        else
        {
            SceneManager.LoadScene(indexNextLvl);
            //PlayerPrefs.SetInt("LevelsCompleted", indexNextLvl);
        }

    }
}
