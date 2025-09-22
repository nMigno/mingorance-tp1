using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;
    private Animator animator;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
       sr = GetComponent<SpriteRenderer>();
       animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        //Flip Sprite if X is negative
        if (moveInput.x < 0)
        {
            sr.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            sr.flipX = false;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isRunning", true);

        if(context.canceled)
        {
            animator.SetBool("isRunning", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }

        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }
}
