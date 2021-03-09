using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;

	float horizontalMove = 0f;
	public float runSpeed = 10; // speed that player moves

	// children that will follow later
	public GameObject child1;
    public GameObject child2;
    public GameObject partner;

    // happy emotions
    public Sprite happyPlayer; // player
    public Sprite happyWife;
    public Sprite happyChild;
    	// family

    // camera object
    public Camera cam;

    bool childrenCreated = false;
    bool partnerCreated = false;

    // instantiated objects
	GameObject child1Ins;
    GameObject child2Ins;
    GameObject partnerIns;


	void Update() {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
	}

	void FixedUpdate() {
		controller.Move(horizontalMove * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "TriggerChildren" && !childrenCreated) {
	    	Vector3 offset1 = new Vector3(transform.position.x-1, transform.position.y-1, transform.position.z);
	    	Vector3 offset2 = new Vector3(transform.position.x-2, transform.position.y-1, transform.position.z);
	    	child1Ins= Instantiate(child1, offset1, Quaternion.identity, transform);
	    	child2Ins = Instantiate(child2, offset2, Quaternion.identity, transform);
	    	//newChild1.transform.localScale += new Vector3(-1f,-1f,0);
	    	//newChild2.transform.localScale += new Vector3(-1f,-1f,0);
	    	child1Ins.transform.parent = gameObject.transform;
	    	child2Ins.transform.parent = gameObject.transform;
	    	child1Ins.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
	    	child2Ins.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
	    	child1Ins.GetComponent<SpriteRenderer>().sortingOrder = 1;
	    	child2Ins.GetComponent<SpriteRenderer>().sortingOrder = 1;
	    	childrenCreated = true;
		}

		if (col.gameObject.tag == "TriggerWife" && !partnerCreated) {
	    	Vector3 offset1 = new Vector3(transform.position.x-3, transform.position.y, transform.position.z);
	    	partnerIns = Instantiate(partner, offset1, Quaternion.identity, transform);
	    	//newPartner.transform.localScale += new Vector3(-1f,-1f,0);
	    	partnerIns.transform.parent = gameObject.transform;
	    	partnerIns.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
	    	partnerIns.GetComponent<SpriteRenderer>().sortingOrder = 1;
	    	partnerCreated = true;
		}

		if (col.gameObject.tag == "TriggerTherapy") {
			// change emotions of player
			GetComponent<SpriteRenderer>().sprite = happyPlayer;
			partnerIns.GetComponent<SpriteRenderer>().sprite = happyWife;
			child1Ins.GetComponent<SpriteRenderer>().sprite = happyChild;
			child2Ins.GetComponent<SpriteRenderer>().sprite = happyChild;
			//cam.backgroundColor = Color.blue;
			cam.backgroundColor = new Color32(88, 129, 216, 122);
		}

	}
	
}
