using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class NinjaController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    private Animator animator;
    private Collider2D col;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkGroundDistance = 0.1f;

    private float moveInput = 0f;
    private bool facingRight = true;

    private bool isGrounded = false;
    private bool wasGrounded = false;
    private bool isJumping = false;
    private bool isFalling = false;

    // Animator parameters
    private int animWalk;
    private int animJumpUp;
    private int animFall;
    private int animLand;
    private int animGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        // Cache animation parameter names
        animWalk = Animator.StringToHash("Walk");
        animJumpUp = Animator.StringToHash("JumpUp");
        animFall = Animator.StringToHash("Falling");
        animLand = Animator.StringToHash("Land");
        animGrounded = Animator.StringToHash("Grounded");
    }

    private void Update()
    {
        // Kiểm tra chạm đất
        CheckGround();

        // Cập nhật animation đi bộ
        if (animator != null)
            animator.SetFloat(animWalk, Mathf.Abs(moveInput));

        // Kiểm tra trạng thái nhảy / rơi
        HandleAirState();
    }

    private void FixedUpdate()
    {
        // Áp dụng vận tốc ngang
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    // Gọi khi giữ nút trái
    public void MoveLeft()
    {
        moveInput = -1f;
        if (facingRight) Flip();
    }

    // Gọi khi giữ nút phải
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

    // Gọi khi nhấn nút nhảy
    public void Jump()
    {
        if (isGrounded)
        {
            isJumping = true;
            isFalling = false;

            // Reset vận tốc Y trước khi nhảy
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Gọi animation JumpUp
            if (animator != null)
                animator.SetTrigger(animJumpUp);

            EffectPool.Instance.PlayJumpEffect(transform.position);
        }
    }

    private void CheckGround()
    {
        // Lấy vị trí trung tâm đáy của collider
        Vector2 origin = new Vector2(col.bounds.center.x, col.bounds.min.y);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, checkGroundDistance, groundLayer);

        wasGrounded = isGrounded;
        isGrounded = hit.collider != null;

        if (animator != null)
            animator.SetBool(animGrounded, isGrounded);

        // Khi vừa chạm đất sau khi nhảy
        if (!wasGrounded && isGrounded)
        {
            if (isFalling)
            {
                // Gọi animation đáp đất
                animator.SetTrigger(animLand);
                isFalling = false;
                isJumping = false;

                EffectPool.Instance.PlayLandEffect(transform.position);
            }
        }
    }

    private void HandleAirState()
    {
        // Nếu đang ở trên không
        if (!isGrounded)
        {
            // Nếu đang nhảy mà vận tốc y < 0 thì chuyển sang rơi
            if (rb.linearVelocity.y < 0 && !isFalling)
            {
                isFalling = true;
                if (animator != null)
                    animator.SetTrigger(animFall);
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Debug đường raycast kiểm tra đất
    private void OnDrawGizmosSelected()
    {
        if (col == null) return;
        Gizmos.color = Color.yellow;
        Vector2 origin = new Vector2(col.bounds.center.x, col.bounds.min.y);
        Gizmos.DrawLine(origin, origin + Vector2.down * checkGroundDistance);
    }
}
