using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundDecision : MonoBehaviour
{
    GameObject EventSystem;
    void Start()
    {
        EventSystem = GameObject.Find ("EventSystem");
    }

    void Update()
    {
        
    }

    //目が合った判定の関数
    
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Eye"))
        {
            Ray ray = new Ray(transform.position, other.gameObject.transform.position - transform.position);
            RaycastHit hit;
            var layerMask = LayerMask.NameToLayer("Player");
            Debug.DrawRay(ray.origin, ray.direction * 15, Color.red, 0.5f);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~layerMask) && Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.name);
                if(hit.collider.CompareTag("Eye"))
                {
                    //Debug.Log("目が合った!!");
                    EventSystem.gameObject.GetComponent<HP3manager>().DecreaseHp();
                }
            }
        }
    }
    //解説
    //colliderはカメラ内にあるもの
    //collider内に敵がいるとき、rayを照射
    //rayに初めて当たったオブジェクトが目のとき、目が合っているということになる
}
