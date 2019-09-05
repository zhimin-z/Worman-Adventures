using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    public Rigidbody joint1;
    public Rigidbody joint2;
    public Rigidbody joint3;
    public Rigidbody joint4;

    public Ground ground;

    public float force;
    public float forwardForce;
    public float extraGravity;
    // Use this for initialization
    void Start () {
		
	}

    void FixedUpdate()
    {
        joint1.AddForce(0, extraGravity, 0);
        joint2.AddForce(0, extraGravity, 0);
        joint3.AddForce(0, extraGravity, 0);
        joint4.AddForce(0, extraGravity, 0);
        if (ground.collisionCount == 0) return;
        if(Input.GetKey(KeyCode.R))
        {
            joint1.AddForce(forwardForce, force, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            joint2.AddForce(forwardForce, force, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            joint3.AddForce(forwardForce, force, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            joint4.AddForce(forwardForce, force, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            //print(1);
            //joint1.AddForce(0, 10.0f, 0);
        }
    }
}
