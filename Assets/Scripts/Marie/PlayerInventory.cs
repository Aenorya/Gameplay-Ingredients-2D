using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private const int MAX_INVENTORY = 10;

    // A dictionary is a type of data container that matches a unique object (called key) to another value.
    // The key and the value can be of different types
    private Dictionary<Item, int> items = new Dictionary<Item, int>();

    //static is a keyword used to store a value across all of the instances of a class
    //That means that every new object of this type will share this value
    public static PlayerInventory Instance;

    private void Awake()
    {
        //The player inventory is what we call a Singleton
        //Only one object PlayerInventory exists in the world, so we can share it with the class instead of a specific instance
        //PlayerInventory.Instance gives me the object reference without needing to know which one I am talking about
        Instance = this;
    }

    public void AddItemToInventory(Item newItem)
    {
        if (items.Count < MAX_INVENTORY)
        {
            if (items.ContainsKey(newItem))
            {
                items[newItem] += 1;
            }
            else
            {
                items.Add(newItem, 1);
            }
        }
        else
        {
            Debug.LogWarning("Oh oh, this inventory can only hold 10 different item types...");
        }
    }

    public void RemoveItemFromInventory(Item oldItem, int quantity) {
        if (items.ContainsKey(oldItem)){
            if (items[oldItem] <= quantity)
            {
                items.Remove(oldItem);
            }
            else
            {
                items[oldItem] -= quantity;
            }
        }
    }

    public Dictionary<Item, int> GetInventory()
    {
        return items;
    }
}
