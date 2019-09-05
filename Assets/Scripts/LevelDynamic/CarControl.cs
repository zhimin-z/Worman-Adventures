using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour {
    public float speed;
    public GameObject spotLight1;
    public GameObject spotLight2;
    public AudioClip honk;

    private Rigidbody carRigi;
    private float timer;
    private float shinningTime;
    private bool islight;
    private AudioSource audioSource;
    private bool isPlaySound;
    // Use this for initialization
    void Start () {
        carRigi = GetComponentInChildren<Rigidbody>();
        timer = 0;
        speed = 2+1*Random.value;
        islight = true;

        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        audioSource.clip = honk;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        shinningTime += Time.deltaTime;
        if (timer<3)
        {
            if (!isPlaySound)
            {
                audioSource.PlayOneShot(honk, 5F);
                isPlaySound = true;
            }
            if (timer>1.5f&&shinningTime > 0.2)
            {
                if (spotLight1!=null&& spotLight2!=null)
                {
                    spotLight1.SetActive(islight);
                    spotLight2.SetActive(islight);
                }
                islight = !islight;
                shinningTime = 0;
            }
            return;
        }
        if (carRigi.transform.position.z > -42)
        {
            carRigi.transform.position = new Vector3(carRigi.transform.position.x, carRigi.transform.position.y, carRigi.transform.position.z - speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GameContext.Head)
        {
           // GameControl.Instance.islose=true;
        }
    }
}
