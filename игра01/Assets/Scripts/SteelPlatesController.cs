using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelPlatesController : MonoBehaviour
{
    public Transform player;
    public float lenghtSteel;
    
    void Update()
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
