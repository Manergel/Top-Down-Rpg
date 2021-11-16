using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private int attackDamage = 1;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            Debug.Log("Attack");
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attacking");

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
