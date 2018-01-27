using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject Wave;

	void Start () {
        StartCoroutine("SpawnWave");
	}


    IEnumerator SpawnWave()
    {
        while(true)
        {
            GameObject wave = (GameObject)Instantiate(Wave, transform.position, Quaternion.identity);
            Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-10, -10);
            yield return new WaitForSeconds(0.1f);
        }

    }
}
