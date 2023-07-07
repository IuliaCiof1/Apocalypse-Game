using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animation animator;

    public static event Action<EnemyHealth> enemyKilled; 

    void Start()
    {
        currentHealth = maxHealth;
        animator = gameObject.GetComponent<Animation>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("dead");
            animator.Play("Death");
    
            Die();
        }
    }

    public void Die()
    {
        gameObject.GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        enemyKilled?.Invoke(this);
        Invoke("DisableObj", 1.5f);

    }

    void DisableObj()
    {
        Destroy(gameObject);
    }
    
}
