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
    private Animator cutsceneAnimator;

    private int frameNumber;
    private int cutsceneFrameCount;

    private void Start()
    {
        sentences = new Queue<string>();
        cutsceneText = cutscene.GetTextElement();
        cutsceneAnimator = cutscene.GetAnimator();
        cutsceneFrameCount = cutscene.GetFrameCount();
        StartCutscene();
        frameNumber = 1;
    }

    private void StartCutscene()
    {
        sentences.Clear();
        cutsceneAnimator.SetInteger("Frame Num", frameNumber);
        string[] cutsceneSentences = cutscene.GetSentences();

        foreach (string sentence in cutsceneSentences)
            sentences.Enqueue(sentence);

        DisplayNextFrame();
    }

    public void DisplayNextFrame()
    {
        if (sentences.Count == 0)
        {
            EndCutscene();
            return;
        }

        string sentence = sentences.Dequeue();
        cutsceneText.text = sentence;

        if (frameNumber + 1 < cutsceneFrameCount)
        {
            frameNumber += 1;
            cutsceneAnimator.SetInteger("Frame Num", frameNumber);
        }
        else
            Debug.Log("ѕредложений больше, чем анимированных кадров");
    }

    private void EndCutscene() 
    {
        SceneManager.LoadScene(cutscene.GetSceneAfterCutscene());
    }
}
