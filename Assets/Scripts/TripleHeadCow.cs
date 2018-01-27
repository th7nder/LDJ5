using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Variables.Definitions;

public class TripleHeadCow : MonoBehaviour
{
    public GameObject Wave;
    public FloatVariable ProjectileSpeed;
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
        Vector2 velocity = Vector2.left * ProjectileSpeed.Value;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendRight()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(1.0f, 0.0f, 0.0f), transform.rotation);
        Vector2 velocity = Vector2.right * ProjectileSpeed.Value;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendUp()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(0.0f, 1.0f, 0.0f), transform.rotation);
        Vector2 velocity = Vector2.up * ProjectileSpeed.Value;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendDown()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(0.0f, -1.0f, 0.0f), transform.rotation);
        Vector2 velocity = Vector2.down * ProjectileSpeed.Value;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }
}


