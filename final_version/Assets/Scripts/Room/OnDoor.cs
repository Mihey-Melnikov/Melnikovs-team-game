using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnDoor : MonoBehaviour
{
    [SerializeField]private Inventory player;
    [SerializeField]private Item itemOn;
    [SerializeField] private AudioSource[] audio;
    
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
                audio[1].PlayOneShot(audio[1].clip);
            }
            else
            {
                audio[0].PlayOneShot(audio[0].clip);
                Invoke(nameof(ExitGame), 0.5f);
            }
        }
        else
        {
            if (player.take != itemOn) 
            {
                PlayText.UpdateText(text[1]);
                audio[1].PlayOneShot(audio[1].clip);
            }
            else
            {
                audio[2].PlayOneShot(audio[2].clip);
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