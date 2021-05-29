using System;
using UnityEngine;

public class ReceivingCollectableItem : MonoBehaviour //достать
{
    public Item item;
    [SerializeField] public AudioSource audio;
    private void OnMouseDown()
    {
        if (!item) return;
        audio.PlayOneShot(audio.clip);
        var inventory = GameObject.Find("player").GetComponent<Inventory>();
        if (inventory && inventory.AddItems(item))
            Destroy(gameObject.GetComponent<ReceivingCollectableItem>());
        
    }
}