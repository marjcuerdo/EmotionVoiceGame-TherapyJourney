using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject smokeObject;

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            //Debug.Log("CUE SMOKE");
            Vector3 offset = new Vector3(transform.position.x-1, transform.position.y-1, transform.position.z);
            Instantiate(smokeObject, offset, Quaternion.identity, transform);
        }
    }
}

