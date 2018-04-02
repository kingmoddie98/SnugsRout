using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Controller : MonoBehaviour {

    public GameObject playerCamGO;
    Camera playerCam;

    Vector3 mousePosStart;
    Vector3 mousePosCurrent;

    Vector3 worldUnderMouse;
    Tile tileUnderMouse;



	// Use this for initialization
	void Start () {

        //Protect against weird clicks before game start
        mousePosCurrent = mousePosStart = Vector3.zero;
        playerCam = playerCamGO.GetComponent < Camera >();
    }
	
	// Update is called once per frame
	void Update () {

        //Conversion from mouse to world viewpoints
        Debug.Log(playerCam.ScreenToWorldPoint(mousePosCurrent - mousePosStart));


        worldUnderMouse = playerCam.ScreenToViewportPoint(Input.mousePosition);

        tileUnderMouse = MapController._instance.gameboard.GetTileAt(
            (int)worldUnderMouse.x,
             (int)worldUnderMouse.y
            );

        if(tileUnderMouse != null)
        {
            Debug.Log(tileUnderMouse.X + "," + tileUnderMouse.Y);
        }

        //Right clicking on position will move the camera
        //Do things when mouse if clicked, namely get position
        if (Input.GetMouseButtonDown(1))
        {
            mousePosStart = Input.mousePosition;
            playerCamGO.transform.Translate(mousePosCurrent - mousePosStart/50);

        }
        //Do things if mouse is held down, still get position
        if (Input.GetMouseButton(1))
        {
            mousePosCurrent = Input.mousePosition;

            mousePosCurrent.x = Mathf.Clamp(mousePosCurrent.x, -10, 10);
        }
        //Once mouse if lifted
        if(Input.GetMouseButtonUp(1))
        {
            mousePosCurrent = mousePosStart = Vector3.zero;
        }

        playerCam.orthographicSize = Screen.height/ 16f / 2f;
    }
}
