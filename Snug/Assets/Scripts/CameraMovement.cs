using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform kir1;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //super simple follower that prevents camera from turning when the unit turns.
        transform.position = Vector3.Lerp(transform.position, kir1.position, speed * Time.deltaTime);
		
	}
}
