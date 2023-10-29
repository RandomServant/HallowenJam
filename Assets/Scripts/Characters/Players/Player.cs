using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject UIPlayer;
    public GameObject WindowDeath;
    GameObject UI;
    GameObject UIDeath;

    void Start()
    {
        Time.timeScale = 1f;
        UI = (GameObject)Instantiate(UIPlayer, transform.position, transform.rotation);
    }

    public void Death()
    {
        Destroy(UI);
        UIDeath = (GameObject)Instantiate(WindowDeath, transform.position, transform.rotation);
        Time.timeScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MovePlatform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MovePlatform"))
        {
            this.transform.parent = null;
        }
    }
}
