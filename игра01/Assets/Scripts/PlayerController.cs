using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 10;
    private Rigidbody2D body;
    private Animator animator;
    private SpriteRenderer sprite;
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        var movementX = Input.GetAxisRaw("Horizontal");
        Walk(movementX);
    }
    
    private void Walk(float movementX)
    {
        body.velocity = new Vector2(movementX * playerSpeed, body.velocity.y);
        sprite.flipX = (movementX < 0 || movementX == 0 && sprite.flipX);
        animator.SetBool(IsRunning, Mathf.Abs(movementX) > 0.05);
    }
}
