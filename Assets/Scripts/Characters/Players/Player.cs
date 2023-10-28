using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject UIPlayer;
    public GameObject WindowDeath;
    protected GameObject UI;
    protected GameObject UIDeath;

    protected virtual void Start()
    {
        /*Instantiate(UIPlayer, transform.position, Quaternion.identity);*/
    }

    public void Death()
    {
        Destroy(UI);
        /*UIDeath = Instantiate(WindowDeath, transform.position, Quaternion.identity);*/
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
