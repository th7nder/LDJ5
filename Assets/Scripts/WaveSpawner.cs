﻿using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject Wave;

    void LaunchWaveAtPos(Vector3 pos)
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position, transform.rotation);

        float angle = AngleBetweenTwoPoints(Camera.main.WorldToViewportPoint(transform.position), pos);
        wave.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        float radAngle = angle * Mathf.Deg2Rad;
        float length = 30.0f;
        Vector2 velocity = new Vector2(-Mathf.Cos(radAngle) * length, -Mathf.Sin(radAngle) * length);

        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;

    }


    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            LaunchWaveAtPos(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        }
    }
}
