using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GuiController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void GoToSelectLevel()
    {

    }

    public void GoToCredits()
    {

    }

    public void QuitGame()
    {
        Debug.LogWarning("Quitting app.");
        Application.Quit();
    }
}
