using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_ahead : MonoBehaviour
{
    [SerializeField] NezumiController nezumiController;
    [SerializeField] RunbaController runbaController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("MainCamera"))
        {
            //Debug.Log("障害物あり");

            //親のオブジェクト名を取得
            string parentObjectName = transform.parent.name;
            //Debug.Log(parentObjectName);
            
            //ねずみ用
            if (parentObjectName == "Nezumi")
            {
                nezumiController.ChangeDirection(); //方向転換する関数を呼び出す
            }


            //ルンバ用
            if (parentObjectName == "Runba")
            {
                runbaController.ChangeDirection();
            }
        }

        
    }
}
