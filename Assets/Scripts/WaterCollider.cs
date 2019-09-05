using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider col)
    {
        
        Jump jump = col.gameObject.GetComponent<Jump>();
        if (jump == null) return;
        print("123");
        jump.movementState = Jump.MovementState.Water;
    }

    void OnTriggerExit(Collider col)
    {

        print("456");
        Jump jump = col.gameObject.GetComponent<Jump>();
        if (jump == null) return;
        jump.movementState = Jump.MovementState.Ground;
    }
}
