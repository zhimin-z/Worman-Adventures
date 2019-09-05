using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWall : MonoBehaviour {

    // Use this for initialization
    //private string hideHere;
	void Start () {
        //hideHere = "Hey, hide here";
	}
     void Update()
    {
        if (Mathf.Abs(GameControl.Instance.XPositionOfPlayer-transform.position.x)<10)
        {
            GameContext.isPlayerHid = true;
        }else
        {
            GameContext.isPlayerHid = false;
        }
    }
    void OnTriggerEnter(Collider col)
    {


    }


    void OnTriggerExit(Collider col)
    {

    }

    //void OnGUI()
    //{
    //    Vector3 worldPosition = new Vector3(transform.position.x + 3f, transform.position.y + 1f, transform.position.z);
    //    Vector2 position = Camera.main.WorldToScreenPoint(worldPosition);
    //    position = new Vector2(position.x, Screen.height - position.y);

    //    Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(hideHere));
    //    GUI.color = Color.black;
    //    GUI.Label(new Rect(position.x - (nameSize.x / 2), position.y - nameSize.y, nameSize.x, nameSize.y), hideHere);
    //}
}
