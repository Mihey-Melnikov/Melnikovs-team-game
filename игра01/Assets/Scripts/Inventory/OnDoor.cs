using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDoor : MonoBehaviour
{
    [SerializeField]private Inventory player;
    [SerializeField]private string gameObjeck;
    [SerializeField]private Item itemOn;


    private void OnMouseDown()
    {
        if (player.take == itemOn)
        {
            player.RemuveItems(itemOn);
            player.OnInventoryChanged.Invoke();
            player.take = null;
            GameObject.Find(gameObjeck).GetComponent<ExitLevel>().enabled = true;
        }
    }
}