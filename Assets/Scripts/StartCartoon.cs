using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCartoon : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Finish()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
