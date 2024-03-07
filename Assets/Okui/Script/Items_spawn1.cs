using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items_spawn1 : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoint;
    [SerializeField] GameObject[] item;


    private int count;

    List<int> numbers = new List<int> ();

    void Start()
    {        
        count = 0;
        
        for(int i = 0; i <= item.Length-1; i++)
        { 
            numbers.Add (i);
        }

        while(count < spawnPoint.Length)
        {
            int random_number = Random.Range(0, numbers.Count);
            int ransu = numbers[random_number];
            GameObject randomItem = item[ransu];
            Debug.Log(random_number);
            Debug.Log(randomItem);
            Instantiate(randomItem, spawnPoint[count].transform.position, Quaternion.identity);

            numbers.RemoveAt(random_number);

            count++;
        }
    }

    void Update()
    {
        
    }
}