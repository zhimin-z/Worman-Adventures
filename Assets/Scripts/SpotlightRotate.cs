using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightRotate : MonoBehaviour {

    public float leftAngle;
    public float rightAngle;
    public float lerpTime;
    bool goingLeft;
    float lerpTimeRemain;

	void Start () {
        goingLeft = false;
        lerpTimeRemain = 0;
	}
	
	// Update is called once per frame
	void Update () {
        lerpTimeRemain -= Time.deltaTime;
        if (lerpTimeRemain <= 0)
        {
            lerpTimeRemain = lerpTime;
            goingLeft = !goingLeft;
        }
        if(goingLeft)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(-leftAngle, rightAngle, lerpTimeRemain / lerpTime));
        else
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(-leftAngle, rightAngle, (lerpTime-lerpTimeRemain) / lerpTime));

    }
}
