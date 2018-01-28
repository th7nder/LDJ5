using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D collision)
    {
       
            //Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        Debug.Log("no to mocno sie psujemy" + collision.gameObject.tag);

    }
}
