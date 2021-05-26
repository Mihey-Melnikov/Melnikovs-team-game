using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> icons = new List<SpriteRenderer>();
    [SerializeField] public List<bool> taken = new List<bool>();
    [SerializeField] private Inventory player;


    public void UpdateUI(Inventory inventory)
    {
        foreach (var t in icons)
            t.sprite = null;
        for (var i = 0; i < inventory.GetSize() && i < icons.Count; i++)
        {
            icons[i].sprite = inventory.GetItem(i).icon;
            taken[i] = false;
        }
    }

    public void Take(int i)
    {
        var take = taken[i];
        for (var j = 0; j < taken.Count; j++)
                taken[j] = false;
        if (!take && icons[i].sprite != null)
            taken[i] = true;

        player.take = null;
        for (var j = 0; j < taken.Count; j++)
        {
            icons[j].color = taken[j]
            ?Color.cyan : Color.white;

            if (taken[j]) player.take = player.items[j];
        }
    }
}
