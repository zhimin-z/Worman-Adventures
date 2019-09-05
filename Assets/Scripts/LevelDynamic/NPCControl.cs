using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCControl : MonoBehaviour {

    public bool willFollow;
    public GameObject joint;
    public float timeToRatetLeft;
    public float timeToRatetDown;
    public Transform standingGO;
    public Transform followingGO;
    public AudioClip howToDance;


    private Transform myTrans;
    private float timerToJump;
    private Rigidbody rigi;
    private string NPCword;
    private char[] NPCInputList;
    private int InputCount;
    private bool isGenerateList;
    private bool beginToFollow;
    private bool finishRotate;
    private float randomJumpTime;
    private AudioSource audioSource;

    private Text text;

	// Use this for initialization
	void Start () {
        myTrans = GetComponent<Transform>();
        rigi = standingGO.GetComponent<Rigidbody>();
        text = gameObject.GetComponentInChildren<Text>();

        NPCInputList = new char[4];
        if (willFollow)
        {
            NPCword = "Help!";
        }else
        {
            NPCword = "";
        }
        
        isGenerateList = false;
        beginToFollow = false;
        finishRotate = false;
        randomJumpTime = 3 * (Random.value+1);

        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        audioSource.clip = howToDance;
    }
	
	// Update is called once per frame
	void Update () {

        if (text != null)
        {
            text.text = NPCword;
        }

        //idle stuff
        timerToJump += Time.deltaTime;
        if (timerToJump> randomJumpTime && !beginToFollow)
        {
            rigi.AddForce(new Vector3(0, 300, 0));
            timerToJump = 0;
        }

        //Follow Character
        if (beginToFollow)
        {
            if (!finishRotate)
            {
                if (timeToRatetLeft>0)
                {
                    timeToRatetLeft -= Time.deltaTime;
                    followingGO.Rotate(new Vector3(0, 1, 0), -2);
                }else
                {
                    if (timeToRatetDown>0)
                    {
                        timeToRatetDown -= Time.deltaTime;
                        followingGO.Rotate(new Vector3(1, 0, 0), -2);
                    }else
                    {
                        finishRotate = true;
                    }
                }
            }
            else
            {

            }
        }

        //follow Character
        if (willFollow&&!beginToFollow)
        {
            //print(standingGO.position.x);
            //print(Mathf.Abs(GameControl.Instance.XPositionOfPlayer - standingGO.position.x));
            if (Mathf.Abs(GameControl.Instance.XPositionOfPlayer - standingGO.position.x)<7f)
            {
                //NPCword = "I see you";
                if (!isGenerateList)
                {
                    audioSource.PlayOneShot(howToDance, 5F);
                    GenerateInputList();
                    NPCword = "Teach me\nhow to dance:\n";
                    for (int i = 0; i < 4; i++)
                    {
                        NPCword += NPCInputList[i] + ",";
                    }
                    isGenerateList = true;
                }else
                {
                    checkInput();
                    if (InputCount==4)
                    {
                        //print("begin");
                        followingGO.gameObject.SetActive(true);
                        standingGO.gameObject.SetActive(false);
                        // joint.SetActive(true);
                        NPCword = "";
                        beginToFollow = true;
                        GameControl.Instance.PlusScore();
                    }
                }
            }else
            {
                NPCword = "Help!";
                isGenerateList = false;
            }
        }
    }
    void checkInput()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (NPCInputList[InputCount]=='R')
            {
                InputCount++;
            }else
            {
                InputCount = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (NPCInputList[InputCount] == 'E')
            {
                InputCount++;
            }
            else
            {
                InputCount = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (NPCInputList[InputCount] == 'W')
            {
                InputCount++;
            }
            else
            {
                InputCount = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (NPCInputList[InputCount] == 'Q')
            {
                InputCount++;
            }
            else
            {
                InputCount = 0;
            }
        }
    }
    void GenerateInputList()
    {
        for (int i = 0; i < 4; i++)
        {
            float randomValue = Random.value;
            if (randomValue < 0.25)
            {
                NPCInputList[i] = 'Q';
            }
            else if (randomValue >= 0.25&& randomValue < 0.5)
            {
                NPCInputList[i] = 'W';
            }
            else if (randomValue >= 0.5 && randomValue < 0.75)
            {
                NPCInputList[i] = 'E';
            }
            else
            {
                NPCInputList[i] = 'R';
            }
        }
    }
}
