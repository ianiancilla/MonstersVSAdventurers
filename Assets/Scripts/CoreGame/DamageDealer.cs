using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float damage = 10;
    [SerializeField] AudioClip impactSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collider = collision.gameObject;

        // checks if damage should/can be dealt, and does so.
        if (collider.GetComponent<Attacker>())
        {
            DealDamage(collider);            
            Impact();
        }

    }

    /// <summary>
    /// if collider has Health script, invokes its TakeDamage method
    /// </summary>
    private void DealDamage(GameObject collider)
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

    /// <summary>
    /// destroys itself on collision, playing impact sound
    /// </summary>
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
