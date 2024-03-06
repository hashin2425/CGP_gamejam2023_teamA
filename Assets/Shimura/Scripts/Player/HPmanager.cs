using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPmanager : MonoBehaviour
{
    [Header("プレイヤーのHPの数")] public int HP = 3;
    [SerializeField] GameObject HPImage;
    [SerializeField] GameObject GamePanel;
    GameObject[] HPImages = new GameObject[100];
    bool muteki = false;
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
        if (!muteki)
        {
            HP--;
            DestroyHPImage();
            DisplayHPImage();
            muteki = true;
            Invoke("Mutekijikan",3.0f);
        }
    }
    //HPが増えた時の処理の関数
    public void IncreaseHp()
    {
        DestroyHPImage();
        HP++;
        DisplayHPImage();
    }

    //HPを画面上に表示させる関数
    void DisplayHPImage()
    {
        HP = Mathf.Clamp(HP,0,3);
        for (int i = 0; i < HP; i++)
        {
            HPImages[i] = Instantiate(HPImage, new Vector3(i*75,0,0), Quaternion.identity);
            HPImages[i].transform.SetParent (GamePanel.transform, false);
        }
    }

    //HPを画面上から破壊
    void DestroyHPImage()
    {
        for (int i = 0; i <= HP; i++)
        {
            Destroy(HPImages[i]);
        }
    }



    //無敵時間
    void Mutekijikan()
    {
        muteki=false;
    }
}
