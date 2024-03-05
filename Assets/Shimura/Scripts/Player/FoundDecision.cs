using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundDecision : MonoBehaviour
{
    GameObject EventSystem; //これはHP3managerがついてるオブジェクト
    GameObject DamagePanel;
    GameObject CatPlayer;
    [SerializeField] AudioClip Catvoice;
    AudioSource audioSource;
    public bool isFound = false;
    [Header("ダメージを受けたときに無敵にする時間")] [SerializeField] float mutekiTime;
    bool ismuteki = false;
    void Start()
    {
        EventSystem = GameObject.Find ("EventSystem"); //HP3managerがついてるオブジェクトの名前に変えといて
        DamagePanel = GameObject.Find ("DamagePanel");
        CatPlayer = GameObject.Find ("CatPlayer");
        audioSource = CatPlayer.GetComponent<AudioSource>();
        DamagePanelfalse();
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
                    if (!ismuteki)
                    {
                        Debug.Log("目が合った!!");
                        EventSystem.gameObject.GetComponent<HP3manager>().DecreaseHp();
                        isFound = true;
                        DamageEffect();
                        StartCoroutine(Mutekijikan());
                    }
                }
                else
                {
                    isFound = false;
                }
            }
            else
            {
                isFound = false;
            }
        }
        else
        {
            isFound = false;
        }
    }
    //解説
    //colliderはカメラ内にあるもの
    //collider内に敵がいるとき、rayを照射
    //rayに初めて当たったオブジェクトが目のとき、目が合っているということになる
    //逆に壁とか敵自身の体に当たったときは目は合っていない

    //無敵時間のコルーチン
    IEnumerator Mutekijikan()
    {
        ismuteki = true;

        yield return new WaitForSeconds(mutekiTime);

        ismuteki = false;
    }

    //ダメージくらった時のエフェクトアニメーション
    void DamageEffect()
    {
        Invoke("DamagePaneltrue",0f);
        Invoke("DamagePanelfalse",0.1f);
        Invoke("DamagePaneltrue",0.2f);
        Invoke("DamagePanelfalse",0.3f);
        audioSource.PlayOneShot(Catvoice);
    }
    void DamagePaneltrue()
    {
        DamagePanel.SetActive(true);
    }
    void DamagePanelfalse()
    {
        DamagePanel.SetActive(false);
    }
}
