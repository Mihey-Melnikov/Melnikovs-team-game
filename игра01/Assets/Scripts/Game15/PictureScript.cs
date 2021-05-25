using UnityEngine;

public class PictureScript : MonoBehaviour
{
    public Game15Script game15Script;
    public Pause pause;
    
    void OnMouseDown()
    {
        pause.isplayer = true;
        game15Script.OnStart();
    }
}
