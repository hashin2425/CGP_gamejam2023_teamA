using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoint;
    [SerializeField] GameObject[] item;

    private float spawnTimer;

    void Start()
    {
        spawnTimer = 0;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {

            GameObject randomPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];
            GameObject Item = item[Random.Range(0, item.Length)];
            GameObject instance = Instantiate(Item, randomPoint.transform.position, Item.transform.rotation);
            instance.name = Item.name;
            spawnTimer = 1;
        }
    }
}
