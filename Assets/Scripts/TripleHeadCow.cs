using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleHeadCow : MonoBehaviour
{

    public GameObject Wave;
    public string FirstWord, SecondWord, ThirdWord;
    Vector2 direction;
    public enum Direction { left, right, up, down };
    public Direction selectedDirection;
    private TextMesh text;

    private void Start()
    {
        text = GetComponentInChildren<TextMesh>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (selectedDirection)
        {
            case Direction.left:
                SendLeft();
                SendUp();
                SendDown();
                break;

            case Direction.right:
                SendRight();
                SendUp();
                SendDown();
                break;

            case Direction.up:
                SendLeft();
                SendRight();
                SendUp();
                break;

            case Direction.down:
                SendLeft();
                SendRight();
                SendDown();
                break;
        }
        text.text = FirstWord + " " + SecondWord + " " + ThirdWord;
        Destroy(collision.gameObject);
    }

    void SendLeft()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocity = Vector2.left * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendRight()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(1.0f, 0.0f, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocity = Vector2.right * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendUp()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(0.0f, 1.0f, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocity = Vector2.up * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendDown()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(0.0f, -1.0f, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocity = Vector2.down * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }
}


