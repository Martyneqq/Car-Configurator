using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpoilerContainer : MonoBehaviour
{
    public GameObject prefabs;
    public Transform transforms, spoiler;

    private void Start()
    {
        GameObject[] gameObjects = Resources.LoadAll<GameObject>("Spoilers");
        foreach (GameObject o in gameObjects)
        {
            GameObject go = Instantiate(prefabs) as GameObject;
            go.transform.SetParent(transforms);

            string objectName = o.name;

            go.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(objectName));

        }
    }

    void Update()
    {
        
    }

    public void OnButtonClick(string objName)
    {
        //Debug.Log(objName);
        prefabs = Resources.Load<GameObject>("Spoilers/" + objName);

        Instantiate(prefabs, spoiler.position, Quaternion.Euler(0, 75, 0));
    }
}
