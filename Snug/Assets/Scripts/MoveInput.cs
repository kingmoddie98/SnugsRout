using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour {

    public Transform kir1Pointer;
    public KirMovement kir1Movement;
    public float minMoveRange;
    public SpriteRenderer cursor1;
	
	// Update is called once per frame
	void Update () {

        //set left mouse button
        if(Input.GetButton("Fire1"))
        {
            //cast ray to position on terrain
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 100))
            {
                //Go to scene and add a tag on the right insepctor menu after 
                //selecting what you want to consider terrain, need to make a custom one for 
                //terrain tag
                if (hit.collider.tag == "Terain")
                {
                    //Debug ray
                    Debug.DrawLine(ray.origin, hit.point);

                    kir1Pointer.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

                    //only move to distance between unit and cursor is big enough
                    if (Vector3.Distance(kir1Pointer.position, kir1Movement.transform.position) > minMoveRange)
                    {
                        kir1Movement.moving = true;
                        cursor1.enabled = true;
                    }

                }
            }
        }
	}
}
