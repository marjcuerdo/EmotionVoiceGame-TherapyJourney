using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmotion : MonoBehaviour
{
	//public GameObject spriteToChange;
	public Sprite replacementSprite;
	public TextTrigger textObj;

	void Start() {
		textObj = GameObject.Find("FamilyTrigger").GetComponent<TextTrigger>();
	}

	void Update() {
		if (textObj.triggeredFam) {
			GetComponent<SpriteRenderer>().sprite = replacementSprite;
		}
	}

}
