using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Mechanics")]
    [SerializeField] float maxHealth = 10;
    float currentHealth;


    [Header("SFX")]
    [SerializeField] AudioClip deathSFX;

    // cache
    Animator animator;

    private void Start()
    {
        if (GetComponent<Attacker>())
        {
            // change enemy health based on difficulty
            maxHealth *= PlayerPrefsController.GetDifficulty();
        }
        currentHealth = maxHealth;

        // cache
        animator = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (animator)
            {
                animator.SetBool("isDying", true);

                // to handle cases where there is an animator but not a death animation
                if (!animator.GetBool("isDying"))
                {
                    Die(0);
                }
            }
            else
            {
                Die(0);
            }
        }
    }

    public void Die(float delay)
    {
        if (deathSFX)
        {
            AudioSource.PlayClipAtPoint(deathSFX, transform.position);
        }
        Destroy(gameObject, delay);
    }

}
