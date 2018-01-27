﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public GameObject Wave;
    public string Word;
    Vector2 direction;
    public enum Direction { left, right, up, down};
    public Direction selectedDirection;
    private TextMesh text;

    private void Start()
    {
        text = GetComponentInChildren<TextMesh>();

        switch(selectedDirection)
        {
            case Direction.left:
                direction = Vector2.left;
                break;

            case Direction.right:
                direction = Vector2.right;
                break;

            case Direction.up:
                direction = Vector2.up;
                break;

            case Direction.down:
                direction = Vector2.down;
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(direction.x, direction.y, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocity = direction * length;

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity / 2;
        Destroy(collision.gameObject);

        text.text = Word;
    }
}
