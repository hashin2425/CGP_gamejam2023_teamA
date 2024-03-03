using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP3manager : MonoBehaviour
{  
    [Header("プレイヤーのHPの数")] public int HP = Mathf.Clamp(3,0,3);
    [SerializeField] GameObject HeartBlackImage1;
    [SerializeField] GameObject HeartBlackImage2;
    [SerializeField] GameObject HeartBlackImage3;
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
        switch (HP)
        {
            case 3:
                HeartBlackImage1.SetActive(false);
                HeartBlackImage2.SetActive(false);
                HeartBlackImage3.SetActive(false);break;
            case 2:
                HeartBlackImage1.SetActive(false);
                HeartBlackImage2.SetActive(false);
                HeartBlackImage3.SetActive(true);break;
            case 1:
                HeartBlackImage1.SetActive(false);
                HeartBlackImage2.SetActive(true);
                HeartBlackImage3.SetActive(true);break;
            default:
                HeartBlackImage1.SetActive(true);
                HeartBlackImage2.SetActive(true);
                HeartBlackImage3.SetActive(true);break;
        }
    }
}
