using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBlock : MonoBehaviour
{

	public EmotionAPI emoObj;
	public int objectIndex;

    // Start is called before the first frame update
    void Start()
    {
        emoObj = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<EmotionAPI>();
    }

    // Update is called once per frame
    void Update()
    {
    	if (objectIndex == emoObj.currentIndex) {
        	Destroy(gameObject.GetComponent<Collider2D>());
        	Destroy(gameObject.GetComponent<SpriteRenderer>());
    	}
    }
}
