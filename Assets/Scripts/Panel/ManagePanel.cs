using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePanel : MonoBehaviour
{
    [SerializeField] public List<GameObject> objects;
    public void ClosePanel()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }
    public void OpenPanel()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }
}
