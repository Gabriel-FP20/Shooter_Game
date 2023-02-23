using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] spawner;

    public int randomShip;
    public int randomSpawner;

    public float spwanTime;
    public static float spwanDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpwanRandom",spwanTime,spwanDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpwanRandom()
    {
        randomSpawner = Random.Range(0, spawner.Length);
        randomShip = Random.Range(0, enemies.Length);
        Instantiate(enemies[randomShip], spawner[randomSpawner].transform.position, spawner[randomSpawner].transform.rotation);

    }
}
