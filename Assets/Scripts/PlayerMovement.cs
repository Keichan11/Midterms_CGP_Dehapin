using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private float horizontalInput;

    void Update()
    {
        if (Keyboard.current != null)
        {
            horizontalInput = 0f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) 
                horizontalInput = 1f;
            else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) 
                horizontalInput = -1f;
        }

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; 
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;  
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            animator.SetTrigger("Attack");
            Debug.Log("Attacking!");
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }
}
