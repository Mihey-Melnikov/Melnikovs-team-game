using UnityEngine;
using UnityEngine.UI;

public class UsageCollectableItemOn : MonoBehaviour //использовать
{
    [SerializeField] private Inventory player;
    [SerializeField] private GameObject gameObjeck;
    [SerializeField] private Item itemOn;
    [SerializeField] private Item item;
    [SerializeField] private string text;
    [SerializeField] private AudioSource[] audio;

    private void OnMouseDown()
    {
        if (player.take == itemOn)
        {
            player.RemuveItems(itemOn);
            player.onInventoryChanged.Invoke();
            player.take = null;
            gameObjeck.AddComponent<ReceivingCollectableItem>().item = item;
            gameObjeck.GetComponent<ReceivingCollectableItem>().audio = audio[1];
        }
        else
        {
            PlayText.UpdateText(text);
            audio[0].PlayOneShot(audio[0].clip);
        }
    }
}