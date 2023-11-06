using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class Transitioner : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Controller controller;
    public void TransitionAnimation()
    {
        anim.SetTrigger("OpenCloseDoor");
    }

    public void ControllerEvent()
    {
        controller.TriggerTransitionerEvent();
    }
}
