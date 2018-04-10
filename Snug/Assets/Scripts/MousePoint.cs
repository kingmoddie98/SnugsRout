using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour {

    RaycastHit hit;
    public GameObject Target;
    private float rayCastLength = 500;

     void Update()
    {
        //GameObject target = GameObject.Find("Target");
      
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.name == "Plane")
            {
                //target.transform.position = hit.point;
                //When we right click instantiate object
                //0 is left mouse 1 right 2 middle
                if(Input.GetMouseButton(1))
                {
                    GameObject TargetObj = Instantiate(Target, hit.point, Quaternion.identity) as GameObject;
                    TargetObj.name = "Target Instantiated";

                    GameObject.Destroy(TargetObj, 2.0f);

                }
            }


        }


        Debug.DrawRay(ray.origin, ray.direction * rayCastLength, Color.yellow);

    }
}
