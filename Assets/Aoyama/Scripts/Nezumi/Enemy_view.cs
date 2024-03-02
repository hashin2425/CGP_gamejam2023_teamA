using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_view : MonoBehaviour
{
    [Header("視野角（40 ~ 70ぐらい）")]public float searchAngle = 30f;
    public NezumiController nezumiController;

    Ray ray;
    RaycastHit hit;
    Vector3 direction; //Rayを飛ばす方向

    private float distance_red = 10; //Ray(赤色)を飛ばす距離
    private float warningCount;

    bool discovered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーを見つけてから、
        if (discovered == true)
        {
            warningCount += Time.deltaTime;
        }
        //Rayが次にプレイヤーを認識するまで猶予を開ける
        if(warningCount > 1)
        {
            discovered = false;
            warningCount = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //プレイヤーの認識
        if (other.CompareTag("Player"))
        {
            //Rayを飛ばす方向を計算
            Vector3 temp = other.transform.position - transform.position;
            direction = temp.normalized;
            //敵の前方からのプレイヤーの方向を計算
            var angle = Vector3.Angle(transform.forward, temp);
            //Debug.Log(angle);

            //視野角内にプレイヤーがいるとき
            if (angle <= searchAngle)
            {
                ray = new Ray(transform.position, direction);  //Rayを飛ばす
                Debug.DrawRay(ray.origin, ray.direction * distance_red, Color.red);  // Rayをシーン上に描画
            }

            //Rayが最初に当たった物体を調べる
            if (Physics.Raycast(ray.origin, ray.direction * distance_red, out hit))
            {
                //Debug.Log(hit.collider.tag);

                if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("GetItemArea")) //GetItemAreaが最初にRayに当たるはず
                {
                    if (discovered == false)
                    {
                        discovered = true;
                        Debug.Log("プレイヤー発見");
                        nezumiController.RunAway(); //ねずみが逃げる関数を呼び出す
                    }
                }
                else
                {
                    //Debug.Log("プレイヤーとの間に壁がある");
                }
            }
        }
    }
}
