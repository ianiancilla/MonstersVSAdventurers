﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] AudioClip impactSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collider = collision.gameObject;

        // checks if damage should/can be dealt, and does so.
        if (collider.GetComponent<Attacker>())
        {
            try
            {
                collider.GetComponent<Health>().TakeDamage(damage);

            }
            catch
            {
                Debug.Log(collider + ": Object has no Health script assigned to it, cannt deal damage to it.");
            }
        }

        // destroys itself on collision, playing impact sound
        Impact();

    }

    private void Impact()
    {
        try
        {
            AudioSource.PlayClipAtPoint(impactSFX, transform.position);
        }
        catch (UnassignedReferenceException) 
        {
            Debug.Log(gameObject + "has no impact sound assigned to it. Is that ok?");
        }
        Destroy(gameObject);
    }

}