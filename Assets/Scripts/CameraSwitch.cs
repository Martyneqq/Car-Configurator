using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    public CinemachineFreeLook cam1, cam2, cam3;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        //animator.Play("InitialCamera");
    }

    public void SwitchCamera(int x)
    {
        if (x == 0)
        {
            animator.Play("MainCamera");
            cam1.enabled = true;
        }
        else if (x == 1)
        {
            animator.Play("WheelCamera");
            cam2.enabled = true;
        }
        else if (x == 2)
        {
            animator.Play("SpoilerCamera");
            cam3.enabled = true;
        }
    }

    public void DeactivateCamera()
    {
        cam1.enabled = false;
        cam2.enabled = false;
        cam3.enabled = false;
    }
}
