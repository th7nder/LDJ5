using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GuiController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void GoToSelectLevel()
    {
        _animator.ResetTrigger("SelectToMain");
        _animator.SetTrigger("SelectLevel");
    }

    public void GoToCredits()
    {
        _animator.ResetTrigger("CreditsToMain");
        _animator.SetTrigger("Credits");
    }

    public void GoBackFromCredits()
    {
        _animator.ResetTrigger("Credits");
        _animator.SetTrigger("CreditsToMain");
    }

    public void GoBackFromSelectLevel()
    {
        _animator.ResetTrigger("SelectLevel");
        _animator.SetTrigger("SelectToMain");
    }

    public void QuitGame()
    {
        Debug.LogWarning("Quitting app.");
        Application.Quit();
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
