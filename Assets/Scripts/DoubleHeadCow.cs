using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleHeadCow : MonoBehaviour {

    public GameObject Wave;
    public string FirstWord;
    public string SecondWord;
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
                SendLeftUp();
                SendLeftDown();
                break;

            case Direction.right:
                SendRightUp();
                SendRightDown();
                break;

            case Direction.up:
                SendRightUp();
                SendLeftUp();
                break;

            case Direction.down:
                SendRightDown();
                SendLeftDown();
                break;
        }
        Destroy(collision.gameObject);
        text.text = FirstWord + " " + SecondWord;
    }

    void SendLeftUp()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(-1.0f, 1.0f, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocity = new Vector2(-1.0f, 1.0f) * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendRightUp()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(1.0f, 1.0f, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocity = new Vector2(1.0f, 1.0f) * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendLeftDown()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(-1.0f, -1.0f, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocity = new Vector2(-1.0f, -1.0f) * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendRightDown()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(1.0f, -1.0f, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocity = new Vector2(1.0f, -1.0f) * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }
}
