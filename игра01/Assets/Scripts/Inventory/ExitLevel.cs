using System.Collections.Generic;
using UnityEngine;

public class ExitLevel: MonoBehaviour
{
    [SerializeField]public Inventory player;
    [SerializeField]public List<Item> requiredItem;
    [SerializeField]private MenuButtonsScript pause;
    
    void Start(){}
    private void OnMouseDown()
    {
        Invoke("ExitGame", 2);
    }

    private void ExitGame()
    {
        foreach (var item in requiredItem)
        {
            if (!player.items.Contains(item)) return;
        }
        pause.ChangeScene("ExitGame");
    }
}