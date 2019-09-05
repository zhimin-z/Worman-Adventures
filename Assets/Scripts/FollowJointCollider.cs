using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowJointCollider : MonoBehaviour {

    public Transform lookat;
    public Transform follow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (follow != null)
        {
            transform.position = follow.position;
        }
        if (lookat != null)
        {
            if (gameObject.tag != "Tail")
            {
                transform.forward = -(lookat.transform.position - transform.position).normalized;
            }
            else
            {
                transform.forward = (lookat.transform.position - transform.position).normalized;
            }
        }

    }
}
