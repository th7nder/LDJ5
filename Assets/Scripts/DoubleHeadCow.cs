using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleHeadCow : MonoBehaviour {

    public GameObject Wave;
    public string FirstWord;
    public string SecondWord;
    Vector2 direction;
    public enum Direction { left, right };
    public Direction selectedDirection;

    private TextMesh text;

    private void Start()
    {
        text = GetComponentInChildren<TextMesh>();
        switch (selectedDirection)
        {
            case Direction.left:
                direction = Vector2.left;
                break;

            case Direction.right:
                direction = Vector2.right;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject waveUp = (GameObject)Instantiate(Wave, transform.position + new Vector3(direction.x, 0.5f, 0.0f), transform.rotation);
        GameObject waveDown = (GameObject)Instantiate(Wave, transform.position + new Vector3(direction.x, -0.5f, 0.0f), transform.rotation);
        float length = 10.0f;
        Vector2 velocityUp = new Vector2(direction.x, 1.0f) * length;
        Vector2 velocityDown = new Vector2(direction.x, -1.0f) * length;
      
        Rigidbody2D rbUp = waveUp.GetComponent<Rigidbody2D>();
        Rigidbody2D rbDown = waveDown.GetComponent<Rigidbody2D>();
        rbUp.velocity = velocityUp / 2;
        rbDown.velocity = velocityDown / 2;
        Destroy(collision.gameObject);
        text.text = FirstWord + " " + SecondWord;
    }
}
