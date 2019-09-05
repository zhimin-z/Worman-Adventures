using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCar : MonoBehaviour {
    public float timerToGenerateCar;
    public GameObject car;
    public GameObject coneArray;
    private float timer;
    private bool carDisable;

	// Use this for initialization
	void Start () {
      
        carDisable = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(GameControl.Instance.XPositionOfPlayer-transform.position.x)>50)
        {
            return;
        }
          timer += Time.deltaTime;
            if (timer>timerToGenerateCar)
            {        
              timer = 0;
             carDisable = false;
             GameObject go= Instantiate(car);
            GameObject cone = Instantiate(coneArray);
            go.transform.SetParent(transform);
            cone.transform.SetParent(transform);
            go.transform.localPosition = new Vector3(0.77f,5.6f,-1.13f);
            cone.transform.localPosition = new Vector3(0f, 0f, 18f+5*Random.value);
        }
        
	}
}
