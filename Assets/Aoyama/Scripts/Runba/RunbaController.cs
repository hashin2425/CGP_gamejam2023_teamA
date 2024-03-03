using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunbaController : MonoBehaviour
{
    [Header("移動速度(1秒で進む距離 プレイヤーより遅めに)")]public float speed = 3f;   
    [Header("「移動 → 止まる」ループの移動する時間")]public float moveTime = 2.0f; //～秒動いて、
    [Header("「移動 → 止まる」ループの止まる時間")]public float stopTime = 1.0f; //～秒止まる

    private float moveTimeCount; //移動している時間の計測
    private float rotationTimeCount; //方向転換する時間の計測

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTimeCount += Time.deltaTime;
        rotationTimeCount += Time.deltaTime;

        //2秒間前進
        if (moveTimeCount > 0 && moveTimeCount < moveTime)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        //移動時間をリセットして1秒止まる
        else if (moveTimeCount > moveTime)
        {
            moveTimeCount = 0 - stopTime;
        }

        //進路（角度）の変更
        if (rotationTimeCount > moveTime + stopTime - 0.5f)
        {
            //進路をランダムに変更する
            Vector3 course = new Vector3(0, Random.Range(0, 360), 0);
            transform.localRotation *= Quaternion.Euler(course);

            //カウントを0に戻す
            rotationTimeCount = -0.5f;
        }
    }

    //障害物で前に進めないので方向転換
    public void ChangeDirection()
    {
        Vector3 course = new Vector3(0, Random.Range(90, 270), 0);
        transform.localRotation *= Quaternion.Euler(course);

        //カウントを0に戻す
        rotationTimeCount = 0;
        moveTimeCount = 0;
    }
}
