using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    // Use this for initialization
    public float MaxX;
    public float MinX;
    public float speed;
    public float YOffset;

    private Transform myTran;
    private BoxCollider boxCollider;
    private bool rightDirection;
    private bool enableCollider;
    private bool[] PlayerEnterList;
	void Start () {
        myTran = GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider>();
        PlayerEnterList =new  bool[4];
        rightDirection = false;
        enableCollider = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(transform.position.x-GameControl.Instance.XPositionOfPlayer)>25)
        {
            return;
        }
        if (rightDirection)
        {
            myTran.position = new Vector3(myTran.position.x - speed, myTran.position.y, myTran.position.z);
        }
        else
        {
            myTran.position = new Vector3(myTran.position.x + speed, myTran.position.y, myTran.position.z );
        }

        if (myTran.position.x>MaxX||myTran.position.x<MinX)
        {
            rightDirection = !rightDirection;
        }

        //do with the collider
        enableCollider = true;
        bool BreakColliderCheck = false;
        int jointNumber = 4;
        if(GameContext.isHardMode)
        {
            jointNumber = 12;
        }
        for (int i = 0; i < jointNumber; i++)
        {
            for (int j = 0; j < jointNumber; j++)
            {
                if (PlayerEnterList[j])
                {
                    BreakColliderCheck = true;
                    break;
                }
            }
            if (BreakColliderCheck)
            {
                break;
            }
          
            if(GameContext.isHardMode)
            {
                if (myTran.position.y > GameControl.Instance.HardJoint[i].transform.position.y)
                {
                    enableCollider = false;
                    break;
                }
                if (Mathf.Abs(myTran.position.y - GameControl.Instance.HardJoint[i].transform.position.y) < 0.3f)
                {
                    enableCollider = false;
                    break;
                }
            }
            else
            {
                if (myTran.position.y > GameControl.Instance.PlayerJoint[i].transform.position.y)
                {
                    enableCollider = false;
                    break;
                }
                if (Mathf.Abs(myTran.position.y - GameControl.Instance.PlayerJoint[i].transform.position.y) < 0.3f)
                {
                    enableCollider = false;
                    break;
                }
            }

            
        }
        boxCollider.enabled = enableCollider;        
	}

    void OnCollisionEnter(Collision other)
    {
        PlayerEnterList[ParseNameToIndex(other.gameObject)] = true;
        for (int i = 0; i < 4; i++)
        {
            if (!PlayerEnterList[i])
            {
                return;
            }
        }
        GameControl.Instance.PlayerParent.transform.SetParent(gameObject.transform);
    }
    void OnCollisionExit(Collision other)
    {
        PlayerEnterList[ParseNameToIndex(other.gameObject)] = false;
        for (int i = 0; i < 4; i++)
        {
            if (PlayerEnterList[i])
            {
                return;
            }
        }
        GameControl.Instance.PlayerParent.transform.SetParent(null);
    }

    int ParseNameToIndex(GameObject go)
    {
        for (int i = 0; i < GameControl.Instance.PlayerJoint.Length; i++)
        {
            if (go.name == GameControl.Instance.PlayerJoint[i].name)
            {
                return i;
            }
        }
        return 0;
    }
}
