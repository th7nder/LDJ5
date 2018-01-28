using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCow : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Wave")) return;
        Destroy(collision.gameObject);
        EndLevel();
    }

    void EndLevel()
    {

    }
}
