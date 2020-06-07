using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Vector2 direction = Vector2.right;
    [SerializeField] float speed = 4;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var newX = transform.position.x + direction.x * speed * Time.deltaTime;
        var newY = transform.position.y + direction.y * speed * Time.deltaTime;
        transform.position = new Vector2(newX, newY);
    }
}
