using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBack : MonoBehaviour
{
    public void OnMouseDown()
    {
        Application.LoadLevel("StartGame");
    }
}
