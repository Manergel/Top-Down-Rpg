using UnityEngine;

public class Player : MonoBehaviour
{
    [Space]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D capsuleColl;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleColl = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        MovementInput();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void MovementInput()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        animator.SetFloat("velocityX", mx);
        animator.SetFloat("velocityY", my);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        movement = new Vector2(mx, my).normalized;
    }
}
