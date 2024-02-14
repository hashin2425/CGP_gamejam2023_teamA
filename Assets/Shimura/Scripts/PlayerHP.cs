using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [Header("プレイヤーのHPの数")] public int HP;
    [SerializeField] GameObject heartImage1;
    [SerializeField] GameObject heartImage2;
    [SerializeField] GameObject heartImage3;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            HP--;
        }
        if (HP==2)
        {
            heartImage3.SetActive(true);
        }
        else if (HP==1)
        {
            heartImage2.SetActive(true);
        }
        else if (HP==0)
        {
            heartImage1.SetActive(true);
        }
    }
}
