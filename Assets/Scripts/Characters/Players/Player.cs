using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject UIPlayer;
    public GameObject WindowDeath;

    protected virtual void Start()
    
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MovePlatform"))
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MovePlatform"))
        {
            transform.parent = null;
        }
    }
}
