using UnityEngine;

public class SteelPlatesController : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private float lenghtSteel;

    private void Update()
    {
        foreach (var child in GetComponentsInChildren<Transform>())
        {
            if (child.position.x + lenghtSteel * 1.5 < player.position.x)
                child.Translate(lenghtSteel * 3, 0, 0);
            if (child.position.x - lenghtSteel * 1.5 > player.position.x)
                child.Translate(lenghtSteel * -3, 0, 0);
        }
    }
}
