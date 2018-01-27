using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCow : MonoBehaviour
{
    public GameObject Wave;
    // Update is called once per frame
    void Update ()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(1.0f, 0.0f, 0.0f), transform.rotation);
        float length = 30.0f;
        Vector2 velocity = Vector2.right * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;

    }
}
