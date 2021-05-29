using UnityEngine;

public class BackPapper : MonoBehaviour
{
    [SerializeField]private Papper papper;
    [SerializeField]private Pause pause;
    [SerializeField] private AudioSource audio;

    private void OnMouseDown()
    {
        audio.PlayOneShot(audio.clip);
        pause.isplayer = false;
        papper.Start();
    }
}
