using UnityEngine;
using TMPro;

public class Cutscene : MonoBehaviour
{
    [TextArea(3,10)]
    [SerializeField] private string[] sentences;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string sceneAfterCutscene;

    public string[] GetSentences() => sentences;
    public TextMeshProUGUI GetTextElement() => text;
    public string GetSceneAfterCutscene() => sceneAfterCutscene;
}
