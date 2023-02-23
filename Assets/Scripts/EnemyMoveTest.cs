using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTest : MonoBehaviour
{
    public float speed = 0.3f;

    public GameObject enemyShip;
    public GameObject enemyDetect;
    public GameObject ship;
    public GameObject bar;
    public GameObject player;
    public GameObject point;
    public GameObject barPoint;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            gameObject.transform.position = enemyShip.transform.position;
            ship.transform.position = Vector2.MoveTowards(ship.transform.position, player.transform.position, speed * Time.deltaTime);
            Vector3 direction = player.transform.position - ship.transform.position;
            enemyShip.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f);
            enemyDetect.transform.position = point.transform.position;
            bar.transform.position = barPoint.transform.position;
            enemyDetect.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);        

        }
    }

    public void Stop()
    {
        speed = 0f;
    }
}
