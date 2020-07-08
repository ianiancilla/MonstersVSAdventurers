using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    // cache
    Scoring scoring;

    private void Start()
    {
        // cache
        scoring = FindObjectOfType<Scoring>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collider = collision.gameObject;
        var attacker = collider.GetComponent<Attacker>();

        if (attacker)
        {
            scoring.TakeDamage(attacker.GetDamageDealt());
        }
    }
}
