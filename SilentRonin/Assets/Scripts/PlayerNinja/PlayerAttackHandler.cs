using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float attackCooldown = 0.5f;
    private float nextAttackTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attack");
            nextAttackTime = Time.time + attackCooldown;
            // TODO: thêm collider hoặc VFX đường chém ở đây
        }
    }
}
