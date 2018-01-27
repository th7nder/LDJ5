using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Variables.Definitions;

public class CowBias : MonoBehaviour {

    public GameObject Wave;
    public FloatVariable ProjectileSpeed;
    public string FirstWord;
    public enum Direction { leftUp, rightDown, rightUp, leftDown };
    public Direction selectedDirection;


    Vector3 _spawnPosition;
    Vector2 _dirVelocity;

    private TextMesh text;

    private void Start()
    {
        text = GetComponentInChildren<TextMesh>();


        GameObject pp = transform.Find("ProjectilePosition").gameObject;

        switch (selectedDirection)
        {

            case Direction.rightUp:
                _dirVelocity = new Vector2(1.0f, 1.0f);
                break;

            case Direction.rightDown:
                _dirVelocity = new Vector2(1.0f, -1.0f);
                pp.transform.localPosition = new Vector3(pp.transform.localPosition.x, -pp.transform.localPosition.y, pp.transform.localPosition.z);
                break;

            case Direction.leftUp:
                _dirVelocity = new Vector2(-1.0f, 1.0f);
                pp.transform.localPosition = new Vector3(-pp.transform.localPosition.x, pp.transform.localPosition.y, pp.transform.localPosition.z);
                break;


            case Direction.leftDown:
                _dirVelocity = new Vector2(-1.0f, -1.0f);
                pp.transform.localPosition = new Vector3(-pp.transform.localPosition.x, -pp.transform.localPosition.y, pp.transform.localPosition.z);
                break;
            
        }

        _dirVelocity *= ProjectileSpeed.Value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Send();
        Destroy(collision.gameObject);
        text.text = FirstWord;
    }

    void Send()
    {
        GameObject pp = transform.Find("ProjectilePosition").gameObject;
        GameObject wave = Instantiate(Wave, pp.transform.position, transform.rotation);
        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = _dirVelocity;

    }

}
