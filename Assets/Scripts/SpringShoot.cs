using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringShoot : MonoBehaviour {

    public float force;

    public float cooldown;
    public float animateTime;

    Vector3 originalPosition;
    Vector3 originalScale;
    float cooldownRemain = 0;
    float animateTimeRemain = 0;

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if(cooldownRemain > 0)
        {
            cooldownRemain -= Time.deltaTime;
        }
        if(animateTimeRemain > 0)
        {
            AnimateSpring();
        }

	}

    void AnimateSpring()
    {
        animateTimeRemain -= Time.deltaTime;
        if(animateTimeRemain > animateTime / 2.0f)
        {
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Lerp(0.7f, 2.0f, (animateTime - animateTimeRemain) / (animateTime / 2.0f));
            transform.localScale = scale;
            transform.position = originalPosition - (originalScale/2.0f) + (transform.localScale/2.0f);
        } else
        {
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Lerp(2.0f, 0.7f, (animateTime / 2.0f - animateTimeRemain) / (animateTime / 2.0f));
            transform.localScale = scale;
            transform.position = originalPosition - (originalScale / 2.0f) + (transform.localScale / 2.0f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.tag != "Tail" && col.tag != "Head" && col.tag != "Player") ||  cooldownRemain > 0) return;
        cooldownRemain = cooldown;
        GameObject obj = col.gameObject.transform.parent.gameObject;
        Rigidbody[] rigidBodies = obj.GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidBodies)
        {
            //print("shoot");
            rigidbody.AddForce(transform.localToWorldMatrix * Vector3.up * force, ForceMode.Impulse);
        }
        animateTimeRemain = animateTime;
    }
}
