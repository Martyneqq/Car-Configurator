using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TunningContainer : MonoBehaviour
{
    public GameObject prefabs, panel; //button, item description panel
    public Transform transforms, frontLeft, frontRight, backLeft, backRight, spoiler;
    public string nameTag;

    private void Start()
    {
        if (nameTag == "Wheel")
        {
            GameObject[] gameObjects = Resources.LoadAll<GameObject>("Wheels");
            Load(gameObjects);
        }
        if (nameTag == "Spoiler")
        {
            GameObject[] gameObjects = Resources.LoadAll<GameObject>("Spoilers");
            Load(gameObjects);
        }
    }

    void Load(GameObject[] lObject)
    {
        foreach (GameObject o in lObject)
        {
            string objectName = o.name;

            GameObject go = Instantiate(prefabs) as GameObject;
            go.transform.SetParent(transforms);

            TextMeshProUGUI TMP = GameObject.Find("BtnPrefabText (TMP)").GetComponent<TextMeshProUGUI>();

            if (TMP.text == "Button")
            {
                TMP.text = objectName;
            }

            go.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(objectName));
        }
    }
    public void OnButtonClick(string objName)
    {
        GameObject[] gameObjectsInit = GameObject.FindGameObjectsWithTag("InitWheel"); // just here to hide the initial wheels
        foreach (GameObject target in gameObjectsInit)
        {
            target.SetActive(false); // cant destroy them because its transforms are already in use, there is prefab of them in Resources/Wheels/Wheel4
        }

        //Debug.Log(objName);
        if (nameTag == "Wheel")
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Wheel");
            foreach (GameObject target in gameObjects)
            {
                GameObject.Destroy(target);
            }

            prefabs = Resources.Load<GameObject>("Wheels/" + objName);

            Instantiate(prefabs, frontLeft.position, Quaternion.Euler(0, -15, 0));
            Instantiate(prefabs, frontRight.position, Quaternion.Euler(0, 165, 0));
            Instantiate(prefabs, backLeft.position, Quaternion.Euler(0, -15, 0));
            Instantiate(prefabs, backRight.position, Quaternion.Euler(0, 165, 0));
        }
        if (nameTag == "Spoiler")
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Spoiler");
            foreach (GameObject target in gameObjects)
            {
                GameObject.Destroy(target);
            }

            prefabs = Resources.Load<GameObject>("Spoilers/" + objName);

            Instantiate(prefabs, spoiler.position, Quaternion.Euler(0, 75, 0));
        }
        panel.SetActive(true);

    }
}
