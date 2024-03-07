using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_spawn : MonoBehaviour
{
    [SerializeField] GameObject spawnpoint;
    [SerializeField] GameObject Player;

    void Start()
    {
        Instantiate(Player, spawnpoint.transform.position, Quaternion.identity);
    }

    void Update()
    {

    }
}