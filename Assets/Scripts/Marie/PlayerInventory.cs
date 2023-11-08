using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int money = 0;
    private int life = 0;
    public List<Item> items = new List<Item>();
    
    public void AddItemToInventory(Item newItem)
    {
        items.Add(newItem);
    }

    public void RemoveItemFromInventory(Item oldItem) {
        items.Remove(oldItem);
    }

}
