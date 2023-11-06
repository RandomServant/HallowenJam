using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class ChapterSelectController : Controller
{
    [SerializeField] TextMeshProUGUI chapterText;
    private string selectedChapterName = "";
    private string selectedChapterScene = "";

    override public void TriggerTransitionerEvent()
    {
        SelectChapter();
    }

    private void SelectChapter()
    {
        selectedChapterScene = EventSystem.current.currentSelectedGameObject.GetComponent<ChapterSelectButton>().GetChapterSceneName();
        selectedChapterName = EventSystem.current.currentSelectedGameObject.GetComponent<ChapterSelectButton>().GetChapterName();
        chapterText.text = selectedChapterName;
    }

    public void LoadChapter()
    {
        SceneManager.LoadScene(selectedChapterScene);
    }
}
