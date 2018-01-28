using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCow : MonoBehaviour {

    public string EndPhrase;
    public string NextSceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Wave")) return;
        Destroy(collision.gameObject);
        EndLevel();
    }

    void EndLevel()
    {
        GameObject canvas = GameObject.Find("EndLevel");
        canvas.GetComponent<Animator>().SetBool("EndLevel", true);
        //show endfield
    }

    public void CompareStrings(InputField input)
    {
        if (input.text.ToLower() == EndPhrase.ToLower()) Success();
    }

    void Success()
    {
        Debug.Log("Succes");
        //SceneManager.LoadScene(NextSceneName);
    }
}
