using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnDoor : MonoBehaviour
{
    [SerializeField]private Inventory player;
    [SerializeField]private Item itemOn;
    private List<string> text = new List<string>()
    {
        "Почему-то мне кажется, что я что-то забыл.",
        "Ключ должен быть где- то в комнате. Хотя..... Видимо я зря оставил окно открытым на ночь."
    };
    [SerializeField]public List<Item> requiredItem;
    [SerializeField]private MenuButtonsScript pause;
    private bool isOn = false;


    private void OnMouseDown()
    {
        if (isOn)
        {
            if (requiredItem.Any(item => !player.items.Contains(item)))
            {
                PlayText.UpdateText(text[0]);
            }
            else Invoke(nameof(ExitGame), 2);
        }
        else
        {
            if (player.take != itemOn) 
            {
                PlayText.UpdateText(text[1]);
            }
            else
            {
                player.RemuveItems(itemOn);
                player.onInventoryChanged.Invoke(); 
                player.take = null;
                isOn = true;
            }
        }
    }
    
    private void ExitGame()
    {
        pause.ChangeScene("ExitGame");
    }
}