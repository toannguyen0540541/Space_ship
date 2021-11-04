using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawEnemies : MonoBehaviour
{
    public GameObject platformPrefabs;
    public float timeSpawn = 5f;

    private float currentTimePawn;
    private int countPlatform = 0;

    void Start()
    {
        currentTimePawn = timeSpawn;
    }


    void Update()
    {
        _spawnPlatform();
    }



    void _spawnPlatform()
    {
        currentTimePawn += Time.deltaTime;
        GameObject newPlatform = null;
        Vector2 temp = transform.position;
        temp.y = Random.Range(-4f, 4f);


        if (currentTimePawn > timeSpawn)
        {
            countPlatform += 1;


            if (countPlatform >= 2)
            {
                newPlatform = Instantiate(platformPrefabs, temp, Quaternion.identity);
                currentTimePawn = 0;
                countPlatform = 0;
            }
            currentTimePawn = 0;
            if (newPlatform)
            {
                newPlatform.transform.parent = transform;
            }
            currentTimePawn = 0;
        }
    }
}
