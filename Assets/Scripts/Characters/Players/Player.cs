using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject UIPlayer;
    public GameObject WindowDeath;
    GameObject t;
    GameObject a;

    void Start()
    {
        t = (GameObject)Instantiate(UIPlayer, transform.position, transform.rotation);

    }

    public void Death()
    {
        Destroy(t);
        a = (GameObject)Instantiate(WindowDeath, transform.position, transform.rotation);

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
