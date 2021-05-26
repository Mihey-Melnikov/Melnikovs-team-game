using UnityEngine;

public class TakingCollectableItem : MonoBehaviour //взять
{
    public Item item;
    public Pause pause;

    private void OnMouseDown()
    {
        if (!item) return;
        var inventory = GameObject.Find("player").GetComponent<Inventory>();
        if (!inventory || !inventory.AddItems(item)) return;
        if(pause.boxcollider.Contains(gameObject)) pause.boxcollider.Remove(gameObject);
        Destroy(gameObject);

    }
}