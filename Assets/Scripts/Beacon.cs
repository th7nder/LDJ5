using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject wave = collision.gameObject;
        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        Vector2 waveDirection = rb.velocity;
        Vector2 reflect = Vector2.Reflect(waveDirection, transform.TransformDirection(Vector2.up));
        rb.velocity = reflect;
        //Debug.Log("Kurwa triggered");
    }
}
