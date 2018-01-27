using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Variables.Definitions;

public class DoubleHeadCow : MonoBehaviour {

    public GameObject Wave;
    public FloatVariable ProjectileSpeed;
    public string FirstWord;
    public string SecondWord;
    public enum Direction { leftTop, rightTop, leftDown, rightDown };
    public Direction selectedDirection;

    private TextMesh text;

    Vector2 _dirTopVelocity;
    Vector2 _dirSideVelocity;
    Vector3 _spawnPointTop;
    Vector3 _spawnPointSide;

    private void Start()
    {
        text = GetComponentInChildren<TextMesh>();


        GameObject top = transform.Find("TopPosition").gameObject;
        GameObject right = transform.Find("RightPosition").gameObject;


        switch (selectedDirection)
        {

            case Direction.rightTop:
                _dirSideVelocity = new Vector2(1.0f, 0.0f);
                _dirTopVelocity = new Vector2(0.0f, 1.0f);

                _spawnPointTop = top.transform.position;
                _spawnPointSide = right.transform.position;
                break;

            case Direction.rightDown:
                _dirSideVelocity = new Vector2(1.0f, 0.0f);
                _dirTopVelocity = new Vector2(0.0f, -1.0f);

                top.transform.localPosition = new Vector3(top.transform.localPosition.x, -top.transform.localPosition.y, top.transform.localPosition.y);
                _spawnPointTop = top.transform.position;
                _spawnPointSide = right.transform.position;

                break;

            case Direction.leftTop:
                _dirSideVelocity = new Vector2(-1.0f, 0.0f);
                _dirTopVelocity = new Vector2(0.0f, 1.0f);

                right.transform.localPosition = new Vector3(-right.transform.localPosition.x, right.transform.localPosition.y, right.transform.localPosition.y);
                _spawnPointTop = top.transform.position;
                _spawnPointSide = right.transform.position;

                break;

            case Direction.leftDown:
                _dirSideVelocity = new Vector2(-1.0f, 0.0f);
                _dirTopVelocity = new Vector2(0.0f, -1.0f);
                top.transform.localPosition = new Vector3(top.transform.localPosition.x, -top.transform.localPosition.y, top.transform.localPosition.y);
                _spawnPointTop = top.transform.position;

                right.transform.localPosition = new Vector3(-right.transform.localPosition.x, right.transform.localPosition.y, right.transform.localPosition.y);
                _spawnPointSide = right.transform.position;


                break;

        }

        _dirSideVelocity *= ProjectileSpeed.Value;
        _dirTopVelocity *= ProjectileSpeed.Value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        text.text = FirstWord + " " + SecondWord;
        Destroy(collision.gameObject);

        Send();
    }

    void Send()
    {
        
        GameObject wave = Instantiate(Wave, _spawnPointTop, transform.rotation);
        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = _dirTopVelocity;

        GameObject waveSide = Instantiate(Wave, _spawnPointSide, transform.rotation);

        Rigidbody2D rbSide = waveSide.GetComponent<Rigidbody2D>();
        rbSide.velocity = _dirSideVelocity;



    }
}
