using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour, Touchable, Flashable
{
    public Flashcard card { get; set; }

    public Transform firePoint;
    public GameObject bulletPrefab;
    public LineRenderer laserLine;
    public TextMeshProUGUI tmpText;

    // private float shipSpeed = 10f;    

    private void Start()
    {        
    }

    private void Update()
    {             
        /*if (Input.GetButtonDown("Fire1"))
        {
            MoveShip(Input.mousePosition);
            // transform.position = Input.mousePosition;
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Flashable flashComponent = bullet.GetComponent<Flashable>();
        flashComponent.SetFlashcard(card);
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
        Vector3 position = transform.position;
        position.x = Camera.main.ScreenToWorldPoint(touchPosition).x;
        transform.position = position;
        // Vector3 position = Camera.main.ScreenToWorldPoint(touchPosition);
        // position.z = 0;
        // transform.position = Vector3.Lerp(transform.position, position, shipSpeed * Time.deltaTime);
    }

    // Touchable Interface Implementation    
    public void DidBeginTouch(Vector3 position)
    {
        MoveShip(position);
    }

    public void DidMoveTouch(Vector3 position)
    {
        MoveShip(position);
    }

    public void DidEndTouch(Vector3 position)
    {
        MoveShip(position);
        ShootBullet();
    }

    // Flashable Interface Implementation
    public void SetFlashcard(Flashcard card)
    {
        this.card = card;
        tmpText.text = card.GetBack();        
    }
}
