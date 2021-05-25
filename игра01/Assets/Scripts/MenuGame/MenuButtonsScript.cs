using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonsScript : MonoBehaviour
{
    public Pause pause;
    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName); 
    }
    
    public void ExitButtom()
    {
        Application.Quit(); 
    }
    
    public void Continue()
    {
        pause.ispuse = false;
    }
}
