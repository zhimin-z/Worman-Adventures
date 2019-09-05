using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceControl : MonoBehaviour {

    // Use this for initialization
    public float lifetime;
    public float speed;
    public GameObject particle;
    public AudioClip policeComing;

    private Transform myTrans;
    private Rigidbody rigi;
    private float timer;
    private float lifeTimer;
    private GameObject player;
    private string TextOfPolice;

    private float spotTimer;
    private Transform transOfSpotLight;
    private bool RightRotate;
    private bool isGoAway;
    private AudioSource audioSource;
    private bool isPlaySound;
    void Start () {
        rigi = GetComponent<Rigidbody>();
        myTrans = GetComponent<Transform>();
        timer = 0;
        lifeTimer = 0;
        spotTimer = 0;
        RightRotate = true;
     
        TextOfPolice = "";
        transOfSpotLight = myTrans.FindChild("Spotlight");

        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        audioSource.clip = policeComing;
        isPlaySound = false;


    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        lifeTimer += Time.deltaTime;
        if (!isPlaySound)
        {
            audioSource.PlayOneShot(policeComing, 15F);
            isPlaySound = true;
        }
       
        if (!isGoAway)
        {
           // print(GameControl.Instance.XPositionOfPlayer- myTrans.position.x);
            if (myTrans.position.x < GameControl.Instance.XPositionOfPlayer)
            {   
                myTrans.position = new Vector3(myTrans.position.x - speed, myTrans.position.y, myTrans.position.z);
            }
            else
            {
                if (!GameContext.isPlayerHid)
                {
                    TextOfPolice = "What the hell you are doing";
                    GameControl.Instance.islose = true;
                }else
                {
                    myTrans.position = new Vector3(myTrans.position.x - speed, myTrans.position.y, myTrans.position.z);
                }
               
            }
        }else
        {
            myTrans.position = new Vector3(myTrans.position.x + speed, myTrans.position.y, myTrans.position.z);
            if (GameControl.Instance.XPositionOfPlayer- myTrans.position.x > 30)
            {
                GameControl.Instance.ReGeneratePolice();
                Destroy(gameObject);   
            }
        }
       

        if (timer>=5)
        {
            rigi.AddForce(new Vector3(0, 400, 0));
            timer = 0;
        }

        if ((lifeTimer> lifetime&&!GameControl.Instance.islose)|| GameControl.Instance.isWin)
        {
            TextOfPolice = "I am tired of being a police";
            transOfSpotLight.gameObject.SetActive(false);
            particle.SetActive(false);
            isGoAway = true;
            //
           // Destroy(this.gameObject);
        }

        if (transOfSpotLight!=null)
        {
            spotTimer += Time.deltaTime;
            if (spotTimer>0.5)
            {
                RightRotate = !RightRotate;
                spotTimer = 0;
            }
            if (RightRotate)
            {
                transOfSpotLight.Rotate(new Vector3(0, 1, 0), 2);
            }else
            {
                transOfSpotLight.Rotate(new Vector3(0, 1, 0), -2);
            }
            
        }
    }

    void OnGUI()
    {
        Vector3 worldPosition = new Vector3(transform.position.x+2f, transform.position.y + 1f, transform.position.z);
        Vector2 position =Camera.main.WorldToScreenPoint(worldPosition);
        position = new Vector2(position.x, Screen.height - position.y);
        GUIStyle fontStyle = new GUIStyle();
        fontStyle.normal.background = null;    
        fontStyle.normal.textColor = new Color(1, 0, 0);  
        fontStyle.fontSize = 25;
        Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(TextOfPolice));
        GUI.color = Color.black;
        GUI.Label(new Rect(position.x - (nameSize.x / 2), position.y - nameSize.y, nameSize.x, nameSize.y), TextOfPolice,fontStyle);
    }
}
