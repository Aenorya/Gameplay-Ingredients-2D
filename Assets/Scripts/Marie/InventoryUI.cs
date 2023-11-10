using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;
    [SerializeField] public GameObject inventoryBoxContainer;
    private GameObject[] inventoryBoxes;

    private void Awake()
    {
        Instance = this;
        inventoryBoxes = inventoryBoxContainer.GetComponentsInChildren<GameObject>();
    }
    void UpdateUI()
    {
        int itemCount = 0;
        foreach (KeyValuePair<Item, int> item in PlayerInventory.Instance.GetInventory()){
            inventoryBoxes[itemCount].transform.GetChild(0).GetComponent<Image>().sprite = item.Key.icon;
            inventoryBoxes[itemCount].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
            inventoryBoxes[itemCount].transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
    }
}
