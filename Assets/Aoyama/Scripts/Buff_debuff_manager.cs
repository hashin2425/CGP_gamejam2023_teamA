using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_debuff_manager : MonoBehaviour
{
    [Header("PlayerController script")] public PlayerController playerCon;
    [Header("バフアイテム獲得時の効果音（シャキーン2）")] public AudioClip buffSE;
    [Header("デフアイテム獲得時の効果音（クイズ不正解）")] public AudioClip debuffSE;
    [Header("猫じゃらし獲得時、止まる時間（デバフ）")] public float stopTime = 2f;
    [Header("マタタビ獲得時、上げる速度倍率（バフ）")] public float speedUp = 1.5f;
    [Header("マタタビ獲得時のバフ効果時間")] public float upTime = 10f;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Playerを一定時間停止させるコルーチン開始
    public void PlayerStop()
    {
        StartCoroutine(StopTimer());
    }

    //Playerを一定時間停止させる
    private IEnumerator StopTimer()
    {
        //デバフ音を鳴らす
        audioSource.PlayOneShot(debuffSE);
        Debug.Log("c");
        var speed = playerCon.PlayerSpeed; //元のPlayerSpeedを記録
        playerCon.PlayerSpeed = 0; //PlayerSpeedを0に

        yield return new WaitForSeconds(stopTime); //～秒間停止

        //Debug.Log("飽きた");
        playerCon.PlayerSpeed = speed; //speedをもとに戻す
    }

    //PlayerのSpeedを一定時間上げるコルーチン開始
    public void SpeedUp()
    {
        Debug.Log("b");
        StartCoroutine(SpeedUpTimer());
    }

    //PlayerのSpeedを一定時間上げる
    private IEnumerator SpeedUpTimer()
    {
        //バフ音を鳴らす
        audioSource.PlayOneShot(buffSE);

        playerCon.PlayerSpeed *= speedUp;

        yield return new WaitForSeconds(upTime); //～秒間効果持続

        playerCon.PlayerSpeed /= speedUp;
    }
}
