using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffClock : MonoBehaviour
{
    private void OnMouseDown()
    {
        gameObject.GetComponent<Animator>().SetBool("On", false);
    }
}
