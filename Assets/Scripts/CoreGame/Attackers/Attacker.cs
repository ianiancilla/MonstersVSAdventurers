﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Header("Speed")]
    [Range (0, 5)][SerializeField] float walkSpeed = 1f;
    [Range(0, 5)] [SerializeField] float jumpSpeed = 3f;

    [Header("Damage")]
    [SerializeField] float damageDealt = 50; // modified by difficulty in actual use.

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

        // set damage based on difficulty modifier
        damageDealt *= PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }

    public void StopMoving()
    {
        currentSpeed = 0f;
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

    public void Jump()
    {
        currentSpeed = jumpSpeed;
        animator.SetTrigger("jumpTrigger");
    }

    public float GetDamageDealt() { return damageDealt; }
}
