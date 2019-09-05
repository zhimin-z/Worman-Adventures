using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        //print(col.name);
        if (col.name==GameContext.Shoulders|| col.name == GameContext.Head|| col.name == GameContext.Knees|| col.name == GameContext.Pelvis)
        {
            GameControl.Instance.islose = true;
        }
    }
}
