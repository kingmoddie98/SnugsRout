using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour {

    MouseManager mm;



	// Use this for initialization
	void Start () {
        mm = GameObject.FindObjectOfType<MouseManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (mm.hoveredObject!= null)
        {
            Bounds bigBounds = mm.hoveredObject.GetComponentInChildren<Renderer>().bounds;

            //TODO Issue with sizing
            //Bounds bigBounds = new Bounds();
            //foreach (Renderer r in rs)
            //{
            //    bigBounds.Encapsulate(r.bounds);
            //}
            
            //This diameter works correctly for circular or square objects
            float diameter = bigBounds.size.z;
            diameter *= 1.25f;



            this.transform.position = new Vector3(bigBounds.size.x, bigBounds.size.y, bigBounds.size.z);
            this.transform.localScale = new Vector3(bigBounds.size.x, bigBounds.size.y, bigBounds.size.z);
        }  
	}
}
