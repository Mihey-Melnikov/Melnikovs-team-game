using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On : MonoBehaviour
{
    [SerializeField]private Inventory player;
    [SerializeField]private string gameObjeck;
    [SerializeField]private Item itemOn;
    [SerializeField]private Item item;


    private void OnMouseDown()
    {
        if (player.take == itemOn)
        {
            player.RemuveItems(itemOn);
            player.take = null;
            GameObject.Find(gameObjeck).AddComponent<CollectableItem>().item = item;
        }
    }
}
