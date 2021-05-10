using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public Game15Script game15Script;
    
    void OnMouseDown()
    {
        Debug.Log(name);
        game15Script.OnClick(name);
    }
}
