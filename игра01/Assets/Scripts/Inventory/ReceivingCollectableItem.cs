using System;
using UnityEngine;

public class ReceivingCollectableItem : MonoBehaviour //достать
{
    public Item item;
    private void OnMouseDown()
    {
        if (!item) return;
        var inventory = GameObject.Find("player").GetComponent<Inventory>();
        if (inventory && inventory.AddItems(item))
            Destroy(gameObject.GetComponent<ReceivingCollectableItem>());
        
    }
}