using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform objectToFollow;

	// Use this for initialization
	void Start ()
    {
        GameControl.Instance.camera = this;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y+5, transform.position.z);
	}
}
