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
            GameObject wave = (GameObject)Instantiate(Wave, transform.position, transform.rotation);
            Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();

            float angle = (Mathf.PI / 6);
            float length = 30.0f;

            float x = Mathf.Cos(angle) * length;
            float y = Mathf.Sin(angle) * length;
            rb.velocity = new Vector2(-x, -y);

            yield return new WaitForSeconds(0.2f);
        }

    }
}
