using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private string[] _textTutorialStage;

    public UnityEvent<string> ShowTutorialStageEvent;

    private int _stage = 0; 
    void Start()
    {
        _player.enabled = false;
        ShowNextTutorialStage();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShowNextTutorialStage();
        }
    }

    private void ShowNextTutorialStage()
    {
        if (_stage >= _textTutorialStage.Length)
        {
            _player.enabled = true;
            Destroy(gameObject);
        }
        else
        {
            ShowTutorialStageEvent.Invoke(_textTutorialStage[_stage]);
            _stage++;
        }
    }
}
