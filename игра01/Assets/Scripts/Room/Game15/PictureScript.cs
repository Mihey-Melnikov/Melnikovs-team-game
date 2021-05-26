using UnityEngine;

public class PictureScript : MonoBehaviour
{
    [SerializeField]private Game15Script game15Script;
    [SerializeField]private Pause pause;

    private void OnMouseDown()
    {
        pause.isplayer = true;
        game15Script.OnStart();
    }
}
