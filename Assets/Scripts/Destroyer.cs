using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyer : MonoBehaviour {

    public UnityEvent DeathEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wave"))
        {
            Destroy(collision.gameObject);
            DeathEvent.Invoke();

        }

    }
}
