using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBrowser : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParent;

    private void OnEnable()
    {
        for (int i = 0; i < PanelManager.Instance.inventoryCount[PanelManager.Instance.currentInventory]; i++)
        {
            int choice = i + 1;
            GameObject createButton = Instantiate(buttonPrefab, buttonParent.transform);
            createButton.GetComponent<LevelButton>().levelText.text = (i + 1).ToString();
            createButton.GetComponent<Button>().onClick.AddListener(() => SelectComponent(PanelManager.Instance.currentInventory, choice));
        }
    }
     
    private void SelectComponent(int component, int level)
    {
        Debug.Log("Loaded component" + component + " - " + level);
    }
}
