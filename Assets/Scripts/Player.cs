using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Touchable
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public LineRenderer laserLine;

    private float shipSpeed = 10f;

    private void Update()
    {     
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(FireLaser());
        }
        */
    }        

    public void ShootBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioManager.Instance.Play("Shoot");
    }

    private IEnumerator FireLaser()
    {
        Debug.Log("LASER FIRED!!");
        RaycastHit2D hitInfo = Physics2D.Raycast(origin: firePoint.position, direction: firePoint.up, distance: 100f, layerMask: LayerMask.GetMask("Enemy"));
        if(hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            laserLine.SetPosition(0, firePoint.position);
            laserLine.SetPosition(1, hitInfo.point);
        }
        else
        {
            laserLine.SetPosition(0, firePoint.position);
            laserLine.SetPosition(1, firePoint.position + firePoint.up * 100);
        }

        laserLine.enabled = true;
        
        // wait a bit
        yield return new WaitForSeconds(0.5f);

        laserLine.enabled = false;
    }

    public void MoveShip(Vector2 touchPosition)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(touchPosition);
        position.z = 0;
        transform.position = Vector3.Lerp(transform.position, position, shipSpeed * Time.deltaTime);
    }

    // Touchable Interface Implementation
    public void DidTap(Touch touch)
    {
        ShootBullet();
    }

    public void DidMoveTouch(Touch touch)
    {
        MoveShip(touch.position);
    }

    public void DidStationaryTouch(Touch touch)
    {
        MoveShip(touch.position);
    }
}
