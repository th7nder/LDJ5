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



    bool _isTransmitting = false;
    int _transmitCounter;

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

    }

    IEnumerator SpawnWave()
    {
        _transmitCounter = 1;
        while(_transmitCounter > 0)
        {
            GameObject wave = (GameObject)Instantiate(Wave, transform.position + new Vector3(direction.x, direction.y, 0.0f), transform.rotation);
            Vector2 velocity = direction * ProjectileSpeed.Value;

            Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
            rb.velocity = velocity;

            _transmitCounter--;
            yield return new WaitForSeconds(0.5f);
        }


        yield return null;
    }


    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !_isTransmitting)
        {
            _isTransmitting = true;
            StartCoroutine("SpawnWave");
        }

    }


    public void OnWaveCrashedIntoWall()
    {
        _isTransmitting = false;
    }
}
