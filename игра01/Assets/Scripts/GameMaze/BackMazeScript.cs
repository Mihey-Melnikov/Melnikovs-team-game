using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMazeScript : MonoBehaviour
{
    public MazeSpawner gameScript;
    public Pause pause;
    void OnMouseDown()
    {
        pause.isplayer = false;
        gameScript.Start();
        gameScript.FinishGame();
    }
}
