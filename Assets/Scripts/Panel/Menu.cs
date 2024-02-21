using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject inventoryBrowser;

    public void ShowLevels(int component)
    {
        PanelManager.Instance.currentInventory = component;
        inventoryBrowser.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
