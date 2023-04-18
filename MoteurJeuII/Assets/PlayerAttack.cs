using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (Time.time >= nextAttackTime && Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
