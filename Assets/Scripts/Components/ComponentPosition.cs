using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetTransform;

    private void Start()
    {
        transform.position = targetTransform;
    }
    private void Update()
    {
        
    }
}
