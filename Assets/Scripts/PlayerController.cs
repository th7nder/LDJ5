using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Variables.Definitions;

public class PlayerController : MonoBehaviour
{
    enum PlayerState 
    {
        Started,
        Returning,
        Finished
    }


    // Publics
    public FloatVariable BoatSpeed;

    // Privates
    Rigidbody2D _body;
    PlayerState _state;
    void Start()
    {
        _state = PlayerState.Started;
        _body = GetComponent<Rigidbody2D>();
        _body.velocity = new Vector2(-BoatSpeed.Value, 0);

    }

    public void OnTouchedBorder()
    {
        _state += 1;
        if(_state != PlayerState.Finished)
        {
            _body.velocity = -_body.velocity;
        }
        else
        {
            _body.velocity = new Vector2();
        }

    }

    public void OnPlayerSpeedChanged()
    {
        if(_body.velocity.x < 0)
        {
            _body.velocity = new Vector2(-BoatSpeed.Value, 0);
        }
        else
        {
            _body.velocity = new Vector2(BoatSpeed.Value, 0);
        }
    }

}