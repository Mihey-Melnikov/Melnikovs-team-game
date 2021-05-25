using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public Game15Script game15Script;
    
    public void OnMouseDown()
    {
        game15Script.OnClick(name);
    }
}
