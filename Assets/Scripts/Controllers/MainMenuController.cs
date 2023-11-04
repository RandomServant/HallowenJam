using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playBtn;
    private Text playBtnText;
    void Start()
    {
        playBtnText = playBtn.gameObject.GetComponentInChildren<Text>();

        if (PlayerPrefs.GetInt("LevelsCompleted") == 0)
            playBtnText.text = "PLAY";
        else
            playBtnText.text = "NEW GAME";
    }
    public void Play()
    {
        SceneManager.LoadScene("LvlManager");

        if (PlayerPrefs.GetInt("LevelsCompleted") == 0)
            PlayerPrefs.SetInt("LevelsCompleted", 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
