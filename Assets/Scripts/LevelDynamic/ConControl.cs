using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConControl : MonoBehaviour {

    private float timer;
	void Start () {
        timer = 0;

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer>10)
        {
            Destroy(gameObject);
        }

    }
}
