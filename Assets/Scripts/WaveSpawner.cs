using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject Wave;

	void Start () {
        InvokeRepeating("SpawnWave", 0.0f, 0.3f);
	}


    public void SpawnWave()
    {
        GameObject wave = (GameObject)Instantiate(Wave, transform.position, Quaternion.identity);
        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-10, -10);
    }
}
