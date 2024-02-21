using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    protected Transform xCam;
    protected Transform xParent;
    protected Vector3 LocalRotation;
    protected float camDistance = 2f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitivity = 10f;
    public float RotationSpeed = 5f;
    public float ScrollSpeed = 6f;

    public bool CameraDisabled = false;

    private void Start()
    {
        this.xCam = this.transform;
        this.xParent = this.transform.parent;
    }
    void LateUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButton(0))
        {
            if (!CameraDisabled)
            {
                if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                {
                    LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                    LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                    LocalRotation.y = Mathf.Clamp(LocalRotation.y, 0f, 90f);
                }
            }
            //TODO
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;

                ScrollAmount *= (this.camDistance * 0.3f);
                this.camDistance += ScrollAmount * -1f;
                this.camDistance = Mathf.Clamp(this.camDistance, 2f, 5f);
            }
        }

        Quaternion QT = Quaternion.Euler(LocalRotation.y, LocalRotation.x, 0);
        this.xParent.rotation = Quaternion.Lerp(this.xParent.rotation, QT, Time.deltaTime * RotationSpeed);
    }
}
