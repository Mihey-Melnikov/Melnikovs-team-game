using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControls : MonoBehaviour
{
    [FormerlySerializedAs("Speed")] public float speed = 2;

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
        componentRigidbody.velocity = new Vector2(movementX * speed, movementY * speed);
    }
}