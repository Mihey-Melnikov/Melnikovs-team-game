using UnityEngine;
using UnityEngine.Serialization;

public class Cell : MonoBehaviour
{
    [FormerlySerializedAs("WallLeft")] public GameObject wallLeft;
    [FormerlySerializedAs("WallBottom")] public GameObject wallBottom;
}