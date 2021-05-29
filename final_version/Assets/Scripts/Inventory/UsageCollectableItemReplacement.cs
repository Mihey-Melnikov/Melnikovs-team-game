using System.Collections.Generic;
using UnityEngine;

public class UsageCollectableItemReplacement : MonoBehaviour //использовать
{
    [SerializeField]private Inventory player;
    [SerializeField]private GameObject gameObjeck;
    [SerializeField]private List<Item> itemOn;
    [SerializeField]private List<Sprite> item;
    [SerializeField]private List<AudioSource> audio;

    private void OnMouseDown()
    {
        if (player.take == itemOn[0])
        {
            player.RemuveItems(itemOn[0]);
            player.onInventoryChanged.Invoke();
            player.take = null;
            gameObjeck.GetComponent<SpriteRenderer>().sprite = item[0];
            item.Remove(item[0]);
            itemOn.Remove(itemOn[0]);
            audio[0].PlayOneShot(audio[0].clip);
            audio.Remove(audio[0]);
        }
        if (item.Count == 0 || itemOn.Count ==0)
            Destroy(gameObjeck.GetComponent<UsageCollectableItemReplacement>());
    }
}