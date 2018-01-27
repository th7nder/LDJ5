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
    Rigidbody2D Body;
    PlayerState state;
    void Start()
    {
        state = PlayerState.Started;
        Body = GetComponent<Rigidbody2D>();
        Body.velocity = new Vector2(-BoatSpeed.Value, 0);

    }

    public void OnTouchedBorder()
    {
        state += 1;
        if(state != PlayerState.Finished)
        {
            Body.velocity = -Body.velocity;
        }
        else
        {
            Body.velocity = new Vector2();
        }

    }

}