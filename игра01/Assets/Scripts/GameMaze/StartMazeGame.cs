using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMazeGame : MonoBehaviour
{
    public MazeSpawner gameMazeScript;
    public Pause pause;
    public GameObject bird;
    
    void OnMouseDown()
    {
        bird.GetComponent<PlayerControls>().enabled = true;
        pause.isplayer = true;
        gameMazeScript.OnStart();
    }
}
