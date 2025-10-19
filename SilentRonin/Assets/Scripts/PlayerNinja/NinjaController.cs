using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NinjaController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    private float moveInput = 0f;
    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Cập nhật animation nếu có
        if (animator != null)
            animator.SetFloat("Walk", Mathf.Abs(moveInput));
    }

    private void FixedUpdate()
    {
        // Áp dụng vận tốc
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    // Gọi khi đè giữ nút trái
    public void MoveLeft()
    {
        moveInput = -1f;
        if (facingRight) Flip();
    }

    // Gọi khi đè giữ nút phải
    public void MoveRight()
    {
        moveInput = 1f;
        if (!facingRight) Flip();
    }

    // Gọi khi thả nút
    public void StopMove()
    {
        moveInput = 0f;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
