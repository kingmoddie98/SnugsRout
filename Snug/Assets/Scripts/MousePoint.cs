using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour {

    RaycastHit hit;
    public static GameObject CurrentlySelectedUnit;

    public static Vector3 rightClickPoint;

    public GameObject Target;
    
    private float rayCastLength = 500;

    private static Vector3 mouseDownPoint;

    public float autoAttackCurTime;
    public float autoAttackCooldown;
    

    private void Awake()
    {
        mouseDownPoint = Vector3.zero;
    }
    void Update()
    {
        //if(CurrentlySelectedUnit != null & CurrentlySelectedUnit.gameObject.GetComponent<Unit>().canAttack)
        //{
      //      if(autoAttackCurTime < autoAttackCooldown)
         //   {
            //    autoAttackCurTime += Time.deltaTime;
         //   }
            //else
           // {
          //      
           // }
        //}

        //GameObject target = GameObject.Find("Target");
      
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //store point of mouse button down
            if (Input.GetMouseButton(0))
            {
                mouseDownPoint = hit.point;
            }

            Debug.Log(hit.collider.name);
            if (hit.collider.name == "Plane")
            {
                //target.transform.position = hit.point;
                //When we right click instantiate object
                //0 is left mouse 1 right 2 middle
                if (Input.GetMouseButton(1))
                {


                        GameObject TargetObj = Instantiate(Target, hit.point, Quaternion.identity) as GameObject;
                        TargetObj.name = "Target Instantiated";
                        rightClickPoint = hit.point;

                        GameObject.Destroy(TargetObj, 2.0f);
                    

                }
                else if (Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(mouseDownPoint))
                {
                    DeselectGameObjectIfSelected();
                }
            }
            else
            {


                if (hit.collider.transform.FindChild("Enemy"))
                {
                    Debug.Log("Found an enemy");

                    if (Input.GetMouseButton(1))
                    {
                        rightClickPoint = hit.collider.transform.FindChild("Enemy").position;
                        CurrentlySelectedUnit.gameObject.GetComponent<Unit>().beginAttack(hit.collider.gameObject);
                    }
                }



                if (Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(mouseDownPoint))
                {
                    //is user hittign something we can select
                    if (hit.collider.transform.FindChild("Selected"))
                    {
                        Debug.Log("Found a unit");
                    

                        //are we selecting a different object
                        if(CurrentlySelectedUnit != hit.collider.gameObject)
                        {
                          

                            GameObject SelectedObj = hit.collider.transform.FindChild("Selected").gameObject;
                            SelectedObj.active = true;

                            hit.collider.gameObject.GetComponent<Unit>().Selected = true;
                            //deactive currently selected object
                            if(CurrentlySelectedUnit != null)
                            {
                                CurrentlySelectedUnit.transform.FindChild("Selected").gameObject.active = false;
                            }

                            CurrentlySelectedUnit = hit.collider.gameObject;


                        }
                    }
                    else
                    {
                        //if not a selected unit
                        DeselectGameObjectIfSelected();
                    }
                }
            }

        }
        else
        {
            if (Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(mouseDownPoint))
            {
                DeselectGameObjectIfSelected();
            }
        }
    

        


        Debug.DrawRay(ray.origin, ray.direction * rayCastLength, Color.yellow);

    }

    //helper functions


    public bool DidUserClickLeftMouse(Vector3 hitPoint)
    {
        float clickZone = 1.3f;

        if((mouseDownPoint.x < hitPoint.x + clickZone && mouseDownPoint.x > hitPoint.x - clickZone) &&
                (mouseDownPoint.y < hitPoint.y + clickZone && mouseDownPoint.y > hitPoint.y - clickZone) &&
                (mouseDownPoint.z < hitPoint.z + clickZone && mouseDownPoint.z > hitPoint.z- clickZone))
        {
            return true; 
        }
        return false;
    }

    public static void DeselectGameObjectIfSelected()
    {
        if(CurrentlySelectedUnit != null)
        {
            CurrentlySelectedUnit.transform.FindChild("Selected").gameObject.active = false;
            CurrentlySelectedUnit = null;
        }
    }

}
