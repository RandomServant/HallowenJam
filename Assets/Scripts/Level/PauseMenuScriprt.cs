using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScriprt : MonoBehaviour
{
    public GameObject UIPauseMenu;
    bool IsActivePause = false;

    public void ClosePauseMenu()
    {
        IsActivePause = false;
        UIPauseMenu.SetActive(false);
    }
    void OpenPauseMenu()
    {
        IsActivePause = true;
        UIPauseMenu.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsActivePause)
            {
                OpenPauseMenu();
            }
            else
            {
                ClosePauseMenu();
            }
        }
    }
}
