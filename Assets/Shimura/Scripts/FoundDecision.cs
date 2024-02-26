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
            if (Physics.Raycast(ray, out hit, 100f, 1))
            {
                Debug.DrawRay(ray.origin, ray.direction * 15, Color.red, 0.5f);
                Debug.Log(hit.collider.name);
                if(hit.collider.CompareTag("Eye"))
                {
                    //Debug.Log("目が合った!!");
                    EventSystem.gameObject.GetComponent<PlayerHP>().DecreaseHp();
                }
            }
        }
    }
    //解説
    //colliderをカメラに作った
    //collider内に敵がいるとき、rayを照射
    //rayに初めて当たったオブジェクトが目のとき、目が合っているということになる
}
