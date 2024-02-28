using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NezumiController : MonoBehaviour
{
    [Header("移動速度(0.04~0.1 プレイヤーより遅めに)")]public float speed = 0.04f;   
    [Header("「移動 → 止まる」ループの移動する時間")]public float moveTime = 2.0f; //～秒動いて、
    [Header("「移動 → 止まる」ループの止まる時間")]public float stopTime = 1.0f; //～秒止まる
    
    private float moveTimeCount; //移動している時間の計測
    private float stopTimeCount; //止まっている時間の計測
    private float rotationTimeCount; //

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTimeCount += Time.deltaTime;
        rotationTimeCount += Time.deltaTime;

        if (moveTimeCount > 0 && moveTimeCount < moveTime)
        {
            transform.position += -transform.right * speed;
        }
        else if (moveTimeCount > moveTime)
        {
            moveTimeCount = 0 - stopTime;
        }
 
        //進路（角度）の変更
        if (rotationTimeCount > 3)
        {
            // 進路をランダムに変更する
            Vector3 course = new Vector3(0, Random.Range(0, 180), 0);
            transform.localRotation = Quaternion.Euler(course);
 
            // タイムカウントを０に戻す
            rotationTimeCount = 0;
        }
    }
}
