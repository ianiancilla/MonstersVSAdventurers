using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Mechanics")]
    [SerializeField] int maxHealth = 10;
    int currentHealth;


    [Header("SFX")]
    [SerializeField] AudioClip deathSFX;

    // cache
    Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;

        // cache
        animator = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (animator)
            {
                animator.SetBool("isDying", true);
            }
            else
            {
                Die(0);
            }
        }
    }

    public void Die(float delay)
    {
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);
        Destroy(gameObject, delay);
    }

}
