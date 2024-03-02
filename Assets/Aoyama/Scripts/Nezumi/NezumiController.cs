using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NezumiController : MonoBehaviour
{
    [Header("プレイヤーのゲームオブジェクト")]public GameObject player;
    [Header("移動速度(0.02~0.1 プレイヤーより遅めに)")]public float speed = 0.04f;   
    [Header("「移動 → 止まる」ループの移動する時間")]public float moveTime = 2.0f; //～秒動いて、
    [Header("「移動 → 止まる」ループの止まる時間")]public float stopTime = 1.0f; //～秒止まる
    [Header("逃げる（走る）時間")]public float runTime = 5.0f; //～秒走る
    
    private float moveTimeCount; //移動している時間の計測
    private float rotationTimeCount; //方向転換する時間の計測

    Vector3 direction;

    bool normal = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTimeCount += Time.deltaTime;
        rotationTimeCount += Time.deltaTime;

        //通常時（プレイヤーを発見していない時）の行動
        if (normal == true)
        {
            //2秒間前進
            if (moveTimeCount > 0 && moveTimeCount < moveTime)
            {
                transform.position += -transform.right * speed;
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
                Vector3 course = new Vector3(0, Random.Range(-90, 90), 0);
                transform.localRotation *= Quaternion.Euler(course);
    
                //カウントを戻す
                rotationTimeCount = -0.5f;
            }
        }

        //逃げるときの行動
        if (normal == false)
        {
            transform.position += -transform.right * speed * 2; //通常時の2倍の速さで逃げる

            if(rotationTimeCount > 1)
            {
                //進路をランダムに変更する
                Vector3 course = new Vector3(0, Random.Range(-60, 60), 0);
                transform.localRotation *= Quaternion.Euler(course);

                //カウントを0に戻す
                rotationTimeCount = 0;
            }

            if(moveTimeCount > runTime)
            {
                //Debug.Log("逃げきれた！");

                normal = true; //通常時の行動に戻る
                moveTimeCount = 0; //カウントを0に戻す
                rotationTimeCount = 0; //カウントを0に戻す
            }
        }

    }

    //プレイヤーを発見したときに反対方向へ逃げる
    public void RunAway()
    {
        
        //Debug.Log("逃げろ！");

        normal = false;

        //プレイヤーから逃げるために後ろを向く
        Vector3 course = new Vector3(0, Random.Range(150, 210), 0);
        transform.localRotation *= Quaternion.Euler(course);

        //カウントを0に戻す
        rotationTimeCount = 0;
        moveTimeCount = 0;
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
