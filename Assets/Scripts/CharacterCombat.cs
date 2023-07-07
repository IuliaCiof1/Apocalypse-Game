using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterCombat : MonoBehaviour
{
    public PlayerStats mystats;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayer;
    Collider[] hitEnemies;
    public int damage;
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    private void Start()
    {
        mystats = GetComponent<PlayerStats>();
    }


    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
                Attack(mystats);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void Attack(PlayerStats targetStats)
    {
        animator.SetTrigger("Attack");
 
        Debug.Log("ss");
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
       
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
