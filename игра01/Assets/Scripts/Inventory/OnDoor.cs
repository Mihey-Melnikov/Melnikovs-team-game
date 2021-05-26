using UnityEngine;

public class OnDoor : MonoBehaviour
{
    [SerializeField]private Inventory player;
    [SerializeField]private string gameObjeck;
    [SerializeField]private Item itemOn;


    private void OnMouseDown()
    {
        if (player.take != itemOn) return;
        player.RemuveItems(itemOn);
        player.onInventoryChanged.Invoke();
        player.take = null;
        GameObject.Find(gameObjeck).GetComponent<ExitLevel>().enabled = true;
    }
}