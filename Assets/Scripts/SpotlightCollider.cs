using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightCollider : MonoBehaviour {

    public Light SpotLight;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag != "Ground" && GameContext.isPlayerHid == false)
        {
            GameObject go= Instantiate(GameControl.Instance.police);
            go.transform.position = new Vector3(GameControl.Instance.XPositionOfPlayer-20, go.transform.position.y, go.transform.position.z+Random.value*6);
            SpotLight.color = Color.red;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag != "Ground" && GameContext.isPlayerHid == false)
        {
            //SpotLight.color = Color.white;
            //print("spotted");
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag != "Ground")
        {
            SpotLight.color = Color.white;
            //print("spotted");
        }
    }
}
