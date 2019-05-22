using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Transform target;

    private void Start()
    {
        Shoot();
    }

    private void Update()
    {
        if (target != null)
        {
            Aim();
        }
    }    

    private void Aim()
    {
        Vector2 direction = new Vector2(
            target.position.x - transform.position.x,
            target.position.y - transform.position.y
        );
        transform.up = direction;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
