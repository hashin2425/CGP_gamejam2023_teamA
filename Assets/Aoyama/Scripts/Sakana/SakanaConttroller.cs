using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakanaConttroller : MonoBehaviour
{
    [Header("PlayerのHP管理のscript")] [SerializeField] HP3manager HP3manager;

    private GameObject ES;

    // Start is called before the first frame update
    void Start()
    {
        //生成時にBuff_debuff_managerのスクリプトを読み込む
        ES = GameObject.Find("EventSystem");
        HP3manager = ES.GetComponent<HP3manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        HP3manager.IncreaseHp();
    }
}
