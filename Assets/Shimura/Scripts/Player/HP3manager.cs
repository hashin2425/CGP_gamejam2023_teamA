using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP3manager : MonoBehaviour
{  
    [Header("プレイヤーのHPの数")] public int HP = Mathf.Clamp(3,0,3);
    [SerializeField] GameObject HeartBlackImage1;
    [SerializeField] GameObject HeartBlackImage2;
    [SerializeField] GameObject HeartBlackImage3;
    [SerializeField] AudioClip manuke2;
    GameObject SE_AudioSource;
    void Start()
    {
        DisplayHPImage();
        SE_AudioSource = GameObject.Find ("SE_Audio Source");
    }

    void Update()
    {
        
    }
    //HPが減った時の処理の関数
    public void DecreaseHp()
    {
        HP--;
        DisplayHPImage();
        if (HP == 0)
        {
            GManager.Instance.ChangeGameState(GameData.ConstSettings.GameState.GameOver);
            SE_AudioSource.GetComponent<AudioSource>().PlayOneShot(manuke2);
        }
    }
    //HPが増えた時の処理の関数
    public void IncreaseHp()
    {
        HP++;
        if (HP>3)
        {
            HP=3;
        }
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
