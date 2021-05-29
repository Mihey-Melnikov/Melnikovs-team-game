using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<Item> items;
    [SerializeField] private int size = 5;
    [SerializeField] public Item take;
    

    [FormerlySerializedAs("OnInventoryChanged")] [SerializeField] public UnityEvent onInventoryChanged;
    
    public bool AddItems(Item item)
    {
        if (items.Count >= size) return false;
        items.Add(item);
        onInventoryChanged.Invoke();
        return true;
    }
    
    public bool RemuveItems(Item item)
    {
        if (!items.Contains(item)) return false;
        items.Remove(item);
        onInventoryChanged.Invoke();
        return true;
    }

    public Item GetItem(int i)
        => i < items.Count
            ? items[i]
            : null;

    public int GetSize()
        => items.Count;
}
