using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nekozyarashi : MonoBehaviour
{
    [Header("Buff_debuff_manager script")]public Buff_debuff_manager buff_debuff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Playerが獲得すると少しの間止まる
    private void OnDestroy()
    {
        //Debug.Log("猫じゃらしに夢中！")

        buff_debuff.PlayerStop(); //Playerを一定時間停止させるデバフの関数を呼び出す
    }
}
