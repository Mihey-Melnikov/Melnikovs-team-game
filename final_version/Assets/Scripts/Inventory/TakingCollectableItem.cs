using UnityEngine;

public class TakingCollectableItem : MonoBehaviour //взять
{
    public Item item;
    public Pause pause;
    [SerializeField] public AudioSource audio;

    private void OnMouseDown()
    {
        if (!item) return;
        audio.PlayOneShot(audio.clip);
        var inventory = GameObject.Find("player").GetComponent<Inventory>();
        if (!inventory || !inventory.AddItems(item)) return;
        if(pause.boxcollider.Contains(gameObject)) pause.boxcollider.Remove(gameObject);
        Destroy(gameObject);
    }
}