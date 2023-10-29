using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject UIPlayer;
    public GameObject WindowDeath;

    protected virtual void Start()
    {
        Time.timeScale = 1f;
        UIPlayer.SetActive(true);
        WindowDeath.SetActive(false);
    }

    public void Death()
    {
        UIPlayer.SetActive(false);
        WindowDeath.SetActive(true);
        Time.timeScale = 0f;
    }
}
