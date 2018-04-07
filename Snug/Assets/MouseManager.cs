using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

    public GameObject hoveredObject;

    private void Update()
    {
        //Origin of the beam is where the camera is and the direction is where the mouse is
        //FPS doesnt need the mouseposition and can just use a beam, whereas an RTS would need it
        //due to the position of the camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //We only care about the first thing we are hovering over, else this can be an array
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            //Whatever we hit, find the root of the object 
            //Not need to have objects seperated out into different game objects
            GameObject hitObject = hitInfo.transform.root.gameObject;

            SelectObject(hitObject);

        }
        else
        {
            ClearSelection();
        }

       
    }

    void SelectObject(GameObject obj)
    {
        if (hoveredObject != null)
        {
            if (obj == hoveredObject)
            {
                return;
            }
            ClearSelection();


        }

        hoveredObject = obj;

        // By default does not include active renderings
        Renderer[] rs = hoveredObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in rs)
        {
            Material m = r.materials[0];
            m.color = Color.green;
            r.material = m;
        }
    }

    void ClearSelection()
    {

        if (hoveredObject == null)
            return;

        // By default does not include active renderings
        Renderer[] rs = hoveredObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in rs)
        {
            Material m = r.materials[0];
            m.color = Color.white;
            r.material = m;
        }
        hoveredObject = null;
    }
}
