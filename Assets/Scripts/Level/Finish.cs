using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private float _waitSecond = 1;
    [SerializeField] private string _showText = "Левел пройден";
    [SerializeField] private string _nextLevelName = "";

    public UnityEvent<string> EnterFinish;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Player>())
            StartCoroutine(NextLevel());
    }

    private IEnumerator NextLevel()
    {
        EnterFinish.Invoke(_showText);
        yield return new WaitForSeconds(_waitSecond);

        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("LevelsCompleted"))
        {
            PlayerPrefs.SetInt("LevelsCompleted", SceneManager.GetActiveScene().buildIndex);
           
        }

        if (_nextLevelName.Length > 0)
            SceneManager.LoadSceneAsync(_nextLevelName);
        else
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
