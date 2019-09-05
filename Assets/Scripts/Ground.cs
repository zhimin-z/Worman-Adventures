using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public int collisionCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnCollisionEnter(Collision col)
    {
        collisionCount++;
    }

    void OnCollisionExit(Collision col)
    {
        collisionCount--;
    }
}
