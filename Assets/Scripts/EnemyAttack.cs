using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool canShoot;
    public GameObject fire;



    // Start is called before the first frame update
    void Start()
    {   
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Attack();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&(canShoot))
        {
            Attack();
        }

    }

    private void Attack()
    {
        if(canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            canShoot = false;
            StartCoroutine(ShootFrontDelay());
        }
    }

    
    IEnumerator ShootFrontDelay()
    {
        Fire();
        yield return new WaitForSeconds(2.0f);
        canShoot = true;
    }

    public void Fire()
    {
        fire.SetActive(true);  
        StartCoroutine(FireDelay());

    }

    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(0.3f);
        fire.SetActive(false);  

    }

    public void StopShoot()
    {
        canShoot = false;
    }
}
