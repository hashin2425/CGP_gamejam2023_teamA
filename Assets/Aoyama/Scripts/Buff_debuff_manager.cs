using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_debuff_manager : MonoBehaviour
{
    [Header("PlayerのPlayerController script")] public PlayerController playerCon;

    [Header("Playerアイテム獲得時、止まる時間（デバフ）")] public float stopTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        var speed = playerCon.PlayerSpeed; //元のPlayerSpeedを記録
        playerCon.PlayerSpeed = 0; //PlayerSpeedを0に

        yield return new WaitForSeconds(stopTime); //～秒間停止

        //Debug.Log("飽きた");
        playerCon.PlayerSpeed = speed; //speedをもとに戻す
    }
}
