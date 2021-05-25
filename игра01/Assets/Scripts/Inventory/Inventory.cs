using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<Item> items;
    [SerializeField] private int size = 5;
    [SerializeField] public Item take;
    

    [SerializeField] public UnityEvent OnInventoryChanged;
    
    public bool AddItems(Item item)
    {
        if (items.Count >= size) return false;
        items.Add(item);
        OnInventoryChanged.Invoke();
        return true;
    }
    
    public bool RemuveItems(Item item)
    {
        if (!items.Contains(item)) return false;
        items.Remove(item);
        OnInventoryChanged.Invoke();
        return true;
    }

    public Item GetItem(int i)
        => i < items.Count
            ? items[i]
            : null;

    public int GetSize()
        => items.Count;
}
