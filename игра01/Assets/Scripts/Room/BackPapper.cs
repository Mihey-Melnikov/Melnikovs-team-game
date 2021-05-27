using UnityEngine;

public class BackPapper : MonoBehaviour
{
    [SerializeField]private Papper papper;
    [SerializeField]private Pause pause;

    private void OnMouseDown()
    {
        pause.isplayer = false;
        papper.Start();
    }
}
