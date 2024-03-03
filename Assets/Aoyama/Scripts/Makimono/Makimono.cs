using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Makimono : MonoBehaviour
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

    //プレイイヤーが獲得するとアイテムの位置が一定時間分かる
    private void OnDestroy()
    {
        Debug.Log("千里眼");

        buff_debuff.Clairvoyance(); //アイテムの位置が分かる関数を呼び出す
    }
}
