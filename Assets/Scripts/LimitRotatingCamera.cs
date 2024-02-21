using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LimitRotatingCamera : MonoBehaviour
{
    public float TouchSensitivity_x = 10f;
    public float TouchSensitivity_y = 10f;

    // Use this for initialization
    void Start()
    {
        CinemachineCore.GetInputAxis = this.HandleAxisInputDelegate;
    }

    private float HandleAxisInputDelegate(string axisName)
    {
        switch (axisName)
        {
            case "Mouse X":
                if (Input.GetMouseButton(0))
                {
                    // is mouse click
                    return Input.GetAxis("Mouse X");
                }
                break;
            case "Mouse Y":
                if (Input.GetMouseButton(0))
                {
                    // is mouse click
                    return Input.GetAxis(axisName);
                }
                break;
            default:
                Debug.LogError("Input <" + axisName + "> not recognized.", this);
                break;
        }

        return 0f;
    }
}