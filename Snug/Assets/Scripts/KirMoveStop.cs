﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirMoveStop : MonoBehaviour {

    public float rotoSpeed;
    public KirMovement kirMovement;
    public SpriteRenderer cursorSprite;

	// Use this for initialization
	void Start () {
        cursorSprite.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * rotoSpeed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Kir1")
        {
            if(kirMovement.moving)
            {
                kirMovement.moving = false;
                cursorSprite.enabled = false;

            }
        }
     }
}
