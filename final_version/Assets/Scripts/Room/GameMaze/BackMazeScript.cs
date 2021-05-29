using UnityEngine;

public class BackMazeScript : MonoBehaviour
{
    [SerializeField]private MazeSpawner gameScript;
    [SerializeField]private Pause pause;

    private void OnMouseDown()
    {
        pause.isplayer = false;
        gameScript.Start();
        gameScript.FinishGame();
    }
}
