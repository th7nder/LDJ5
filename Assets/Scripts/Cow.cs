using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public GameObject Wave;
    public string Word;
    public int Direction = 1;
    private TextMesh text;

    private void Start()
    {
        text = GetComponentInChildren<TextMesh>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(Direction, 0.0f, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocity = Direction * Vector2.right * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
        Destroy(collision.gameObject);

        text.text = Word;
    }
}
