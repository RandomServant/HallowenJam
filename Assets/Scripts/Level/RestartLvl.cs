using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLvl : MonoBehaviour
{
    [SerializeField] private GameObject WindowDeath;
    public void Restart()
    {
        int indexCurrentLvl = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexCurrentLvl);
        Destroy(WindowDeath);
    }
}
