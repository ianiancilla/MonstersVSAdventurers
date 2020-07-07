using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range (0, 5)][SerializeField] float walkSpeed = 1f;
    [SerializeField] int damageDealt = 50;

    float currentSpeed;

    GameObject currentTarget;

    //cache
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // cache
        animator = GetComponent<Animator>();

        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }

    public void StopMoving()
    {
        currentSpeed = 0;
    }

    public void ResumeMoving()
    {
        currentSpeed = walkSpeed;
    }

    public void Attack (GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void DoneAttacking()
    {
        animator.SetBool("isAttacking", false);
    }

    public void StrikeCurrentTarget()
    {
        if (!currentTarget)
        {
            DoneAttacking();
            return;
        }
        Health targetHealth = currentTarget.GetComponent<Health>();
        if (targetHealth)
        {
            targetHealth.TakeDamage(damageDealt);
        }
    }

}
