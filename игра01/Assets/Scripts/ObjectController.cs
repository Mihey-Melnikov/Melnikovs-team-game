using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
