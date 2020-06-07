using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectile_origin;
    public void Fire()
    {
        Instantiate(projectile, projectile_origin.position, Quaternion.identity);
    }
}
