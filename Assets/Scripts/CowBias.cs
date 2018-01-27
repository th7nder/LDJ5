using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Variables.Definitions;

public class CowBias : MonoBehaviour {

    public GameObject Wave;
    public FloatVariable ProjectileSpeed;
    public string FirstWord;
    Vector2 direction;
    public enum Direction { leftUp, rightDown, rightUp, leftDown };
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
            case Direction.leftUp:
                SendLeftUp();
                break;

            case Direction.rightDown:
                SendRightDown();
                break;

            case Direction.rightUp:
                SendRightUp();
                break;

            case Direction.leftDown:
                SendLeftDown();
                break;
        }
        Destroy(collision.gameObject);
        text.text = FirstWord;
    }

    void SendLeftUp()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(-1.0f, 1.0f, 0.0f), transform.rotation);
        Vector2 velocity = new Vector2(-1.0f, 1.0f) * ProjectileSpeed.Value;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendRightUp()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(1.0f, 1.0f, 0.0f), transform.rotation);
        Vector2 velocity = new Vector2(1.0f, 1.0f) * ProjectileSpeed.Value;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendLeftDown()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(-1.0f, -1.0f, 0.0f), transform.rotation);
        Vector2 velocity = new Vector2(-1.0f, -1.0f) * ProjectileSpeed.Value;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }

    void SendRightDown()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(1.0f, -1.0f, 0.0f), transform.rotation);
        Vector2 velocity = new Vector2(1.0f, -1.0f) * ProjectileSpeed.Value;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
    }
}
