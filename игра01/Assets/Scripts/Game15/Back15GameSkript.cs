using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game15;
using UnityEngine;

public class Back15GameSkript : MonoBehaviour
{
    public Game15Script game15Script;
    public Pause pause;
    void OnMouseDown()
    {
        pause.isplayer = false;
        game15Script.Start();
    }
}
