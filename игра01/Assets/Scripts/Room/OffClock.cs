using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffClock : MonoBehaviour
{
    private static readonly int On = Animator.StringToHash("On");
    private bool isSlip;

    public static List<string> phrase = new List<string>
    {
        "Какой же он громкий... только он меня точно разбудит. Так... А зачем мне так рано вставать?",
        "******\nСегодня же первый учебный день, а я еще ничего не собрал. Хорошо, что вчера я составил список. Он должен быть на доске."
    };
    private int number = 0;

    private void OnMouseDown()
    {
        gameObject.GetComponent<Animator>().SetBool(On, false);
        PlayText.isContinuation = true;
        isSlip = true;
    }

    private void Update()
    {
        if (number == 2)
        {
            isSlip = false;
            PlayText.isContinuation = false;
            return;
        }

        if (isSlip)
        {
            PlayText.UpdateText(phrase[number]);
            if (Input.GetKeyDown(KeyCode.Space) && isSlip)
                number += 1;
        }
        
    }
}
