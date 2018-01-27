using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCow : MonoBehaviour
{
    public GameObject Wave;
    public int Direction = 1;
    // Update is called once per frame
    void Update ()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(Direction, 0.0f, 0.0f), transform.rotation);
        float length = 30.0f;
        Vector2 velocity = Direction * Vector2.right * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;

    }
}
