using UnityEditor.PackageManager.UI;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float Speed = 2;

    public Rigidbody2D componentRigidbody;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        var movementX = Input.GetAxisRaw("Horizontal");
        var movementY = Input.GetAxisRaw("Vertical");
        Walk(movementX, movementY);
    }
    
    private void Walk(float movementX, float movementY)
    {
        componentRigidbody.velocity = new Vector2(movementX * Speed, movementY * Speed);
    }
}