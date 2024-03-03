using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matatabi : MonoBehaviour
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

    //プレイイヤーが獲得すると少しの間速度が上がる
    private void OnDestroy()
    {
        //Debug.Log("興奮状態！")

        buff_debuff.SpeedUp(); //Playerの速度を一定時間上げるバフの関数を呼び出す
    }
}
