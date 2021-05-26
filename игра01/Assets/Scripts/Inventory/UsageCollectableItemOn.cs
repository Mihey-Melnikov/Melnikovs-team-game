using UnityEngine;

public class UsageCollectableItemOn : MonoBehaviour //использовать
{
    [SerializeField]private Inventory player;
    [SerializeField]private GameObject gameObjeck;
    [SerializeField]private Item itemOn;
    [SerializeField]private Item item;

    private void OnMouseDown()
    {
        if (player.take == itemOn)
        {
            player.RemuveItems(itemOn);
            player.onInventoryChanged.Invoke();
            player.take = null;
            gameObjeck.AddComponent<ReceivingCollectableItem>().item = item;
        }
    }
}