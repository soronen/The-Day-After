using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 1;
    public LayerMask enemyLay;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    // When the attack is being made, there is a short cool down (nextAttackTime).
    // There are also booleans for attacking animation.
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Attack1();
                nextAttackTime = Time.time + 1f / attackRate;
                animator.SetBool("Attacking", true);
            }
        }
        if (Time.time >= nextAttackTime)
        {
            animator.SetBool("Attacking", false);
        }
    }

    /// <summary>
    /// When the enemy is in the attack range and Attack-command is being called,
    /// the attack activates the TakeDamage method which makes the enemy to take damage.
    /// </summary>
    void Attack1()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLay);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyAI1>().TakeDamage(attackDamage);
        }
    }

    // Made to make it easyer to adjust the attack range.
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
