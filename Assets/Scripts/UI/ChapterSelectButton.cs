using UnityEngine;

public class ChapterSelectButton : MonoBehaviour
{
    [SerializeField] private string chapterName = "";
    [SerializeField] private string chapterSceneName = "";

    public string GetChapterName() => chapterName;
    public string GetChapterSceneName() => chapterSceneName;
}
