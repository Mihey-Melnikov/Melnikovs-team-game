using UnityEngine;
using UnityEngine.UI;

public class UsageCollectableItemOn : MonoBehaviour //использовать
{
    [SerializeField]private Inventory player;
    [SerializeField]private GameObject gameObjeck;
    [SerializeField]private Item itemOn;
    [SerializeField]private Item item;
    [SerializeField] private string text;

    private void OnMouseDown()
    {
        if (player.take == itemOn)
        {
            player.RemuveItems(itemOn);
            player.onInventoryChanged.Invoke();
            player.take = null;
            gameObjeck.AddComponent<ReceivingCollectableItem>().item = item;
        }
        else
        {
            PlayText.UpdateText(text);
        }
    }
}