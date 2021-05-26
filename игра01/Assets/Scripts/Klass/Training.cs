using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private Canvas canvas;
    private int number = 0;
    public static List<string> phrase = new List<string>{
        "Привет. Спасибо, что решился запустить нашу игру. Щас будет небольшое обучение в управлении. Для проделжения нажимай пробел.",
        "Для передвижения используй стрелки навигации влево и вправо или A и D.",
        "Также ты можешь взаимодействовать с предметами. Попробуй нажать на тряпку на столе. Она появится у тебя в инвентаре.",
        "Чтобы воспользоваться предметом/взять его в руку, нажми на его иконку в инвентаре. Она должна поменять цвет. Нажми еще раз, чтобы положить.",
        "Теперь сотри надпись с доски. Возьми тряпку и нажми на доску.",
        "Ты освоил основные действия в игре. Теперь попробуй воспользоваться этим.",
        "Перед тем как закончить обучение, самостоятельно написаши новую надпись на доске и полить кактус. После этого можешь покинуть уровень, нажав на дверь.",
        "Нажми пробел, чтобы повторить, или Backspace, если повторять не надо."
    };

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ExitTraining.UpdateExit(text))
            {
                number += 1;
            }
            
            if (phrase.Count == number)
            {
                number = 1;
            }
            text.GetComponent<Text>().text = phrase[number];
        }
    }
}
