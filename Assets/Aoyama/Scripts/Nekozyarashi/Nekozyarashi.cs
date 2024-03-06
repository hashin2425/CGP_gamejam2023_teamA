using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nekozyarashi : MonoBehaviour
{
    [Header("Buff_debuff_manager script")]public Buff_debuff_manager buff_debuff;

    private GameObject B_D_obj;
    
    // Start is called before the first frame update
    void Start()
    {
        //生成時にBuff_debuff_managerのスクリプトを読み込む
        B_D_obj = GameObject.Find("BuffDebuffManager");
        buff_debuff = B_D_obj.GetComponent<Buff_debuff_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Playerが獲得すると少しの間止まる
    private void OnDestroy()
    {
        Debug.Log("猫じゃらしに夢中！");

        buff_debuff.PlayerStop(); //Playerを一定時間停止させるデバフの関数を呼び出す
    }
}
