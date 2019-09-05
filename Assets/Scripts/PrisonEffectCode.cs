using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonEffectCode : MonoBehaviour {
    public GameObject[] prisonSide;
    private Vector3[] positionList;
    public bool isPlayEffect;
    // Use this for initialization
    private void Start()
    {
        positionList = new Vector3[5];
        for (int i = 0; i < 5; i++)
        {
            positionList[i] = prisonSide[i].transform.position;
        }
        isPlayEffect = false;
    }
    // Update is called once per frame
    void Update () {
        if (isPlayEffect)
        {
            for (int i = 0; i < prisonSide.Length; i++)
            {
               // print(prisonSide[i].transform.position.y);
                if (prisonSide[i].transform.position.y > 220)
                {
                    prisonSide[i].transform.position = new Vector3(prisonSide[i].transform.position.x, prisonSide[i].transform.position.y - 20f, prisonSide[i].transform.position.z);
                }
            }
        }
       
	}
   public void resetEffect()
    {
        for (int i = 0; i < 5; i++)
        {
             //prisonSide[i].transform.position= positionList[i];
        }
    }
}
