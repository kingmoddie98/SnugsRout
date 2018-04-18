using UnityEngine;
using System.Collections;
using System;

public class CameraControl : MonoBehaviour
{

    public struct BoxLimit
    {
        public float leftLimit;
        public float rightLimit;
        public float topLimit;
        public float bottomLimit;
    }

    public static BoxLimit controlLimits = new BoxLimit();
    public static BoxLimit mouseScrollLimits = new BoxLimit();
    public static CameraControl instance;

    private float cameraMoveSpeed = 60f;
    private float shiftBonus = 45f;
    private float mouseBoundary = 15f;

    private float mouseX;
    private float mouseY;

    private bool verticalRotationEnabled = true;
    private float VertialRotationMin = 0f;
    private float VertialRotationMax = 65f;

    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        controlLimits.leftLimit = -400f;
        controlLimits.rightLimit = 400f;
        controlLimits.topLimit = 400f;
        controlLimits.bottomLimit = -400f;

        mouseScrollLimits.leftLimit = mouseBoundary;
        mouseScrollLimits.rightLimit = mouseBoundary;
        mouseScrollLimits.topLimit = mouseBoundary;
        mouseScrollLimits.bottomLimit = mouseBoundary;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        HandleMouseRotation();

        if (CheckIfUserCameraInput())
        {
            Vector3 cameraDesiredMove = GetDesiredTranslation();

            if (!IsDesiredPositionOverBoundaries(cameraDesiredMove))
            {
                this.transform.Translate(cameraDesiredMove);
            }
        }

        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
    }

    private void HandleMouseRotation()
    {
        float easeFactor = 10f;
        if(Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.mousePosition.x != mouseX)
            {
                var yRoatation = (Input.mousePosition.x - mouseX) * easeFactor * Time.deltaTime;
                this.transform.Rotate(0, yRoatation, 0);
            }

            if(verticalRotationEnabled && Input.mousePosition.y != mouseY)
            {
                GameObject MainCamera = this.gameObject.transform.FindChild("Main Camera").gameObject;
                var xRoatation = (mouseY - Input.mousePosition.y) * easeFactor * Time.deltaTime;
                var desiredRoatationX = MainCamera.transform.eulerAngles.x + xRoatation;

                if(desiredRoatationX >= VertialRotationMin && desiredRoatationX <= VertialRotationMax)
                {
                    MainCamera.transform.Rotate(xRoatation, 0, 0);
                }
            }
        }
    }

    private bool CheckIfUserCameraInput()
    {
        bool keyboardMove;
        bool mouseMove;
        bool canMove;

        if (CameraControl.AreCameraKeyboardButtonPressed())
        {
            keyboardMove = true;
        }
        else
            keyboardMove = false;
        if (CameraControl.IsMousePositionWithinBoundaries())
        {
            mouseMove = true;
        }
        else mouseMove = false;


        if (keyboardMove || mouseMove)
            canMove = true;
        else canMove = false;

        return canMove;
    }

    public Vector3 GetDesiredTranslation()
    {
        float moveSpeed = 0f;
        float desiredX = 0f;
        float desiredZ = 0f;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = (cameraMoveSpeed + shiftBonus) * Time.deltaTime;
        }
        else
        {
            moveSpeed = cameraMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            desiredZ = moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            desiredZ = moveSpeed * -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            desiredX = moveSpeed * -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            desiredX = moveSpeed;
        }

        if (Input.mousePosition.x < mouseScrollLimits.leftLimit)
        {
            desiredX = moveSpeed * -1;
        }
        if (Input.mousePosition.x > (Screen.width - mouseScrollLimits.rightLimit))
        {
            desiredX = moveSpeed;
        }
        if (Input.mousePosition.y < mouseScrollLimits.bottomLimit)
        {
            desiredZ = moveSpeed * -1;
        }
        if (Input.mousePosition.y > (Screen.height - mouseScrollLimits.topLimit))
        {
            desiredZ = moveSpeed;
        }

        return new Vector3(desiredX, 0, desiredZ);
    }

    public bool IsDesiredPositionOverBoundaries(Vector3 desiredPosition)
    {
        bool overBoundaries = false;

        if ((this.transform.position.x + desiredPosition.x) < controlLimits.leftLimit)
        {
            overBoundaries = true;
        }
        if ((this.transform.position.x + desiredPosition.x) > controlLimits.rightLimit)
        {
            overBoundaries = true;
        }
        if ((this.transform.position.z + desiredPosition.z) > controlLimits.topLimit)
        {
            overBoundaries = true;
        }
        if ((this.transform.position.z + desiredPosition.z) < controlLimits.bottomLimit)
        {
            overBoundaries = true;
        }
        return overBoundaries;
    }
    public static bool AreCameraKeyboardButtonPressed()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            return true;
        else return false;
    }
    public static bool IsMousePositionWithinBoundaries()
    {
        if (
           (Input.mousePosition.x < mouseScrollLimits.leftLimit && Input.mousePosition.x > -5) ||
           (Input.mousePosition.x > (Screen.width - mouseScrollLimits.rightLimit) && Input.mousePosition.x < (Screen.width + 5)) ||
           (Input.mousePosition.y < mouseScrollLimits.bottomLimit && Input.mousePosition.y > -5) ||
           (Input.mousePosition.y > (Screen.height - mouseScrollLimits.topLimit) && Input.mousePosition.y < (Screen.height + 5))
           )
            return true;
        else return false;
    }
}
