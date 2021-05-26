using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExitLevel: MonoBehaviour
{
    [SerializeField]public Inventory player;
    [SerializeField]public List<Item> requiredItem;
    [SerializeField]private MenuButtonsScript pause;

    private void Start(){}
    private void OnMouseDown()
    {
        if (requiredItem.Any(item => !player.items.Contains(item)))
            return;

        Invoke(nameof(ExitGame), 2);
    }

    private void ExitGame()
    {
        pause.ChangeScene("ExitGame");
    }
}