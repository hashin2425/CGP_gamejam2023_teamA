using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP3manager : MonoBehaviour
{  
    [Header("プレイヤーのHPの数")] public int HP = Mathf.Clamp(3,0,3);
    [SerializeField] GameObject HeartBlImage1;
    [SerializeField] GameObject HeartBlImage2;
    [SerializeField] GameObject HeartBlImage3;
    void Start()
    {
        DisplayHPImage();
    }

    void Update()
    {
        
    }
    //HPが減った時の処理の関数
    public void DecreaseHp()
    {
        HP--;
        DisplayHPImage();
    }
    //HPが増えた時の処理の関数
    public void IncreaseHp()
    {
        HP++;
        DisplayHPImage();
    }
    //hpの表示に関するメソッド
    void DisplayHPImage()
    {
        if (HP==3)
        {
            HeartBlImage1.SetActive(false);
            HeartBlImage2.SetActive(false);
            HeartBlImage3.SetActive(false);
        }
        else if (HP==2)
        {
            HeartBlImage1.SetActive(false);
            HeartBlImage2.SetActive(false);
            HeartBlImage3.SetActive(true);
        }
        else if (HP==1)
        {
            HeartBlImage1.SetActive(false);
            HeartBlImage2.SetActive(true);
            HeartBlImage3.SetActive(true);
        }
        else
        {
            HeartBlImage1.SetActive(true);
            HeartBlImage2.SetActive(true);
            HeartBlImage3.SetActive(true);
        }
    }
}
