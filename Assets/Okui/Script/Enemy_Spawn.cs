using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnpoint;
    [SerializeField] GameObject Enemy;
       
    void Start()
    {
        GameObject randompoint = spawnpoint[Random.Range(0, spawnpoint.Length)];
        Instantiate(Enemy, randompoint.transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}