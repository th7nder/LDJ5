using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Variables.Definitions;

public class StartingCow : MonoBehaviour
{
    public GameObject Wave;
    public FloatVariable ProjectileSpeed;
    Vector2 direction;
    public enum Direction { left, right, up, down };
    public Direction selectedDirection;
    // Update is called once per frame


    void Start()
    {
        switch (selectedDirection)
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
        StartCoroutine("SpawnWave");
    }

    IEnumerator SpawnWave()
    {
        while(true)
        {
            GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(direction.x, direction.y, 0.0f), transform.rotation);
            Vector2 velocity = direction * ProjectileSpeed.Value;

            Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
            rb.velocity = velocity;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
