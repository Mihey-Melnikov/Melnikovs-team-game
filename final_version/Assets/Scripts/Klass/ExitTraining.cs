using UnityEngine;
using UnityEngine.UI;

public class ExitTraining : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private AudioSource audio;
    private MenuButtonsScript pause;
    
    public static bool UpdateExit(GameObject text)
    {
        if (text.GetComponent<Text>().text !=
            "Ты не закончил обучение. Чтобы вернуться нажми пробел. Для завершения нажми на дверь еще раз.") 
            return true;
        return false;
    }

    private void Exit()
    {
        Application.LoadLevel("GameLevels");
    }

    public void OnMouseDown()
    {
        if ((GameObject.Find("Cactus").GetComponent<UsageCollectableItemReplacement>() != null
             || GameObject.Find("KALAKAMALAKA").GetComponent<UsageCollectableItemReplacement>() != null)
            && text.GetComponent<Text>().text !=
            "Ты не закончил обучение. Чтобы вернуться нажми пробел. Для завершения нажми на дверь еще раз.")
            text.GetComponent<Text>().text = "Ты не закончил обучение. Чтобы вернуться нажми пробел. Для завершения нажми на дверь еще раз.";
        else
        {
            audio.PlayOneShot(audio.clip);
            Invoke("Exit", 0.5f);
        }
    }
}
