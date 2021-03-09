using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public GameObject text1;
    public GameObject npcObject;
    public int xValue = 5;
    public int yValue = 3;
    public bool triggeredFam = false;

    public void OnTriggerEnter2D(Collider2D col) {
    	if (col.gameObject.tag == "Player") {
    		//Debug.Log("Triggering text");
    		triggeredFam = true;
    		ShowFloatingText();
    	}
    }

    void ShowFloatingText() {
    	Vector3 offset = new Vector3(npcObject.transform.position.x-xValue, npcObject.transform.position.y+yValue, npcObject.transform.position.z);
    	Instantiate(text1, offset, Quaternion.identity, npcObject.transform);
    }
}

