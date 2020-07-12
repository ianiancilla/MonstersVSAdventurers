using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fungarancio : MonoBehaviour
{
    // cache
    Attacker myAttacker;

    private void Start()
    {
        myAttacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherObject = collision.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            myAttacker.Attack(otherObject);
        }
    }
}
