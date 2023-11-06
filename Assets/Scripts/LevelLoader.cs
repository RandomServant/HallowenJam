using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string lvlName = "";
    private bool interactive = false;

    private void Start()
    {
        if (lvlName == "")
            Debug.Log($"На {gameObject.name} не назначен lvlName");
    }

    private void Update()
    {
        if (interactive && Input.GetButton(GlobalStringVars.INTERACTIVE))
            SceneManager.LoadScene(lvlName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            interactive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            interactive = false;
    }
}
