using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour {

    public float timeToMove;
    public float speed;
    private bool moveDown;
    private float timer;
    private Transform myTrans;

    void Start()
    {
        myTrans = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (moveDown)
        {
            myTrans.position = new Vector3(myTrans.position.x, myTrans.position.y - speed, myTrans.position.z);
        }else
        {
            myTrans.position = new Vector3(myTrans.position.x, myTrans.position.y + speed, myTrans.position.z);
        }

        if (timer>timeToMove)
        {
            moveDown = !moveDown;
            timer = 0;
        }
	}
}
