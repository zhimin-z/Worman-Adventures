using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public Transform bornTransform;
    private ParticleSystem particle;

    private bool visited = false;

	// Use this for initialization
	void Start () {
        particle = GetComponentInChildren<ParticleSystem>();

    }
    public void ResetCheckPoint()
    {
        particle.startColor = Color.white;
    }
    void OnTriggerEnter(Collider col)
    {
        if (visited) return;
        for (int i = 0; i < 5; i++)
        {
            GameControl.Instance.PlusScore();
        }
        GameContext.BornPos = bornTransform.position;
        //print(GameContext.BornPos);
        particle.startColor = Color.green; //new Color(123,253,161,255); //
                                           // GetComponent<MeshRenderer>().material.color = Color.green;
        visited = true;
    }
}
