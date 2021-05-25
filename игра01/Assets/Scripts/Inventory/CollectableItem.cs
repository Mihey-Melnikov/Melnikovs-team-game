using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public Item item;

    private void OnMouseDown()
    {
        if (!item) return;
        var inventory = GameObject.Find("player").GetComponent<Inventory>();
        if (inventory && inventory.AddItems(item))
                Destroy(gameObject.GetComponent<CollectableItem>());
        if(gameObject.name == "KeyDoor") Destroy(gameObject);
        
    }
}
