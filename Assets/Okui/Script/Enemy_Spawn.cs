using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnpoint;
    [SerializeField] GameObject[] Enemy;
    private int count;
    private int DifficultyLeve;

    List<int> numbers = new List<int>();

    void Start()
    {
        count = 0;
        DifficultyLeve = 2;

        for (int i = 0; i <= spawnpoint.Length - 1; i++)
        {
            numbers.Add(i);
        }

        for (int j = 1; j <= DifficultyLeve; j++)
        {
            int random_number = Random.Range(0, numbers.Count);
            int ransu = numbers[random_number];
            GameObject randompoint = spawnpoint[ransu];
            Debug.Log(random_number);
            Instantiate(Enemy[count], randompoint.transform.position, Quaternion.identity);

            numbers.RemoveAt(random_number);

            count++;
        }
    }

    void Update()
    {
        
    }
}