using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public static float speed = 0.5f;

    public bool destroy;


    private float randomDirectionX;
    private float randomDirectionY;

    public Vector3 direction;
    public GameObject enemyShip;
    public GameObject enemyDetect;
    public GameObject point;



    // Start is called before the first frame update
    void Start()
    {
        randomDirectionX = Random.Range(-1f,1f);
        randomDirectionY = Random.Range(-1f,1f);
        direction = new Vector3(randomDirectionX, randomDirectionY,0f).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        enemyShip.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f); 
        enemyDetect.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f); 
        enemyDetect.transform.position = point.transform.position;      
        transform.position += direction * speed * Time.deltaTime;

    }

    public void ChangeDirection()
    {
        randomDirectionX = -transform.position.x;
        randomDirectionY = -transform.position.y;
        direction = new Vector3(randomDirectionX, randomDirectionY,0f).normalized;
    }

    public void SpeedChange()
    {
        speed = 0;
    }
}
