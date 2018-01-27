using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class BorderController : MonoBehaviour {

    public UnityEvent gameEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameEvent.Invoke();
        }
    }
}
