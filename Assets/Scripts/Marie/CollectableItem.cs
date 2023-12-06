using System;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Item itemData;
    bool pickable = false;
    private void Start()
    {
        Invoke("Load", Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && pickable)
        {
            PlayerInventory.Instance.AddItemToInventory(itemData);
            Destroy(gameObject);
        }
    }

    private void Load()
    {
        if (PlayerInventory.Instance.IsInInventory(itemData.uniqueID))
        {
            Destroy(gameObject);
        }
        else pickable = true;
    }
}

[Serializable]
public class Item
{
    public string uniqueID;
    public Sprite icon;
}
