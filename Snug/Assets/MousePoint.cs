using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour {

    RaycastHit hit;

    private float rayCastLength = 500;

     void Update()
    {
        GameObject target = GameObject.Find("Target");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.name == "Plane")
            {
                target.transform.position = hit.point;
            }


        }


        Debug.DrawRay(ray.origin, ray.direction * rayCastLength, Color.yellow);

    }
}
