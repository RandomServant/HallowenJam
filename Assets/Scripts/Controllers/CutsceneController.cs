using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : Controller
{
    [TextArea(3, 10)]
    [SerializeField] private Queue<string> sentences;
    [SerializeField] private Cutscene cutscene;
    private TextMeshProUGUI cutsceneText;

    private void Start()
    {
        sentences = new Queue<string>();
        cutsceneText = cutscene.GetTextElement();
        StartCutscene();
    }

    private void StartCutscene()
    {
        sentences.Clear();
        string[] cutsceneSentences = cutscene.GetSentences();

        foreach (string sentence in cutsceneSentences)
            sentences.Enqueue(sentence);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndCutscene();
            return;
        }

        string sentence = sentences.Dequeue();
        cutsceneText.text = sentence;
    }

    private void EndCutscene() 
    {
        SceneManager.LoadScene(cutscene.GetSceneAfterCutscene());
    }
}
