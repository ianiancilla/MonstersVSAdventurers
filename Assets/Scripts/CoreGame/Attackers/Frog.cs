﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    // cache
    Attacker myAttacker;
    Animator myAnimator;

    private void Start()
    {
        // cache
        myAttacker = GetComponent<Attacker>();
        myAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherObject = collision.gameObject;
        bool isJumping = myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Frog_Jump");

        if (!isJumping)
        {
            if (otherObject.GetComponent<Snowman>())
            {
                myAttacker.Jump();
            }
            else if (otherObject.GetComponent<Defender>())
            {
                myAttacker.Attack(otherObject);
            }
        }


    }
}
