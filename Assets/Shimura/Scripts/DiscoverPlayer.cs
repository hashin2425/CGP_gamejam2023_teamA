using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverPlayer : MonoBehaviour
{
    public bool isDiscovered = false;
    void Start()
    {
        
    }

    void Update()
    {
        //Rayを照射してPlayerを見つける処理
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;
        var layerMask = LayerMask.NameToLayer("Enemy");
        //Rayに当たったオブジェクトのレイヤーがEnemyとIgnoreRaycastじゃない時
        if (Physics.Raycast(ray, out hit,Mathf.Infinity,~layerMask) && Physics.Raycast(ray, out hit))
        {    
            Debug.DrawRay(ray.origin, ray.direction * 15, Color.blue, 0.5f);
            if(hit.collider.CompareTag("Player"))
            {
                //ここに見つかった時の処理
                isDiscovered= true;
            }
            
        }
        else
        {
            //ここに見つかってない時の処理(見つかっているときと逆の処理)
            isDiscovered=false;
        }

    }
}
