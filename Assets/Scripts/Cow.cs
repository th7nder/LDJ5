using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public GameObject Wave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(1.0f, 0.0f, 0.0f), transform.rotation);
        float length = 30.0f;
        Vector2 velocity = Vector2.right * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }
}
