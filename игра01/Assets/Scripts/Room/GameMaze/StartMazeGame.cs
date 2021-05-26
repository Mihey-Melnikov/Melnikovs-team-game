using UnityEngine;

public class StartMazeGame : MonoBehaviour
{
    [SerializeField]private MazeSpawner gameMazeScript;
    [SerializeField]private Pause pause;
    [SerializeField]private GameObject bird;

    private void OnMouseDown()
    {
        bird.GetComponent<PlayerControls>().enabled = true;
        pause.isplayer = true;
        gameMazeScript.OnStart();
    }
}
