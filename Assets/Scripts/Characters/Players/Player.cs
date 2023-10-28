using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject UIplayer;
    public GameObject WindowDeath;

    void Start()
    {
        Instantiate(UIplayer, transform.position, transform.rotation);
    }

    void Death()
    {
        UIplayer.SetActive(false);
        Instantiate(WindowDeath, transform.position, transform.rotation);

    }

}
