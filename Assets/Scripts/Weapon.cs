using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{



    public GameObject bulletPrefab;

    public Transform frontPoint;

    public Transform rightPoint1;
    public Transform rightPoint2;
    public Transform rightPoint3;

    public Transform leftPoint1;
    public Transform leftPoint2;
    public Transform leftPoint3;

    public GameObject fire;




    public void FireFront()
    {

        GameObject bullet = Instantiate(bulletPrefab, frontPoint.position, frontPoint.rotation);
        Fire();

    }

    public void FireRight()
    {

            GameObject bullet1 = Instantiate(bulletPrefab, rightPoint1.position, rightPoint1.rotation);
            GameObject bullet2 = Instantiate(bulletPrefab, rightPoint2.position, rightPoint2.rotation);
            GameObject bullet3 = Instantiate(bulletPrefab, rightPoint3.position, rightPoint3.rotation);
    }

    public void FireLeft()
    {

            GameObject bullet4 = Instantiate(bulletPrefab, leftPoint1.position, leftPoint1.rotation);
            GameObject bullet5 = Instantiate(bulletPrefab, leftPoint2.position, leftPoint2.rotation);
            GameObject bullet6 = Instantiate(bulletPrefab, leftPoint3.position, leftPoint3.rotation);
    }

    public void Fire()
    {
        fire.SetActive(true);  
        StartCoroutine(FireDelay());

    }

    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(0.2f);
        fire.SetActive(false);  
    }
}
