using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //何かがGetItemAreaのCollider内に入ったら発動
    void OnTriggerEnter(Collider other)
    {
        //その何かのtagがitemのとき
        if(other.gameObject.CompareTag("item"))
        {
            //ここに獲得したときの処理
            Debug.Log(other);
            Destroy(other.gameObject);
        }
    }
}
