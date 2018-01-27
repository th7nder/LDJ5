using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip: MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f) * Time.deltaTime;
	}
}
