using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIsland : MonoBehaviour
{
    public GameObject[] islands;
    public GameObject[] spawner;

    public int randomIsland;
    public int randomSpawner;

    public float spwanTime;
    public float spwanDelay;

    public bool canSpawn;


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
        randomIsland = Random.Range(0, islands.Length);
        Instantiate(islands[randomIsland], spawner[randomSpawner].transform.position, spawner[randomSpawner].transform.rotation);
    }


    
}
