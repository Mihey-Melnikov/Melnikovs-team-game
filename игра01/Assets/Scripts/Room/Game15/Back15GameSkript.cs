using UnityEngine;

public class Back15GameSkript : MonoBehaviour
{
    [SerializeField]private Game15Script game15Script;
    [SerializeField]private Pause pause;

    private void OnMouseDown()
    {
        pause.isplayer = false;
        game15Script.Start();
    }
}
