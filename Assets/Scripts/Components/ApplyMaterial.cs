using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyMaterial : MonoBehaviour // commit check
{
    public FlexibleColorPicker fcp;
    [SerializeField] private Toggle toggle1, toggle2;
    public Material material;
    void Start()
    {

    }

    void Update()
    {
        material.color = fcp.color;
        if (toggle1.isOn)
        {
            material.SetFloat("_Metallic", 0.04f);
            material.SetFloat("_Glossiness", 0.5f);
        }
        else if (toggle2.isOn)
        {
            material.SetFloat("_Metallic", 0.98f);
            material.SetFloat("_Glossiness", 0.98f);
        }
    }
}
