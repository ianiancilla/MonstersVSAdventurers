using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectile_origin;

    Animator animator;
    AttackerSpawner myLaneSpawner;

    public void Start()
    {
        // cache
        animator = GetComponent<Animator>();

        SetLaneSpawner();
    }

    public void Update()
    {
        if (isEnemyInLane())
        {
            // set animation state to shooting
            animator.SetBool("isAttacking", true);
        }
        else
        {
            // set animation state to idle
            animator.SetBool("isAttacking", false);
        }
    }

    public void Fire()
    {
        Instantiate(projectile, projectile_origin.position, Quaternion.identity);
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in attackerSpawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) 
                                    <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
    }

    private bool isEnemyInLane()
    {
        if (!myLaneSpawner) { return false; }

        if (myLaneSpawner.transform.childCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
