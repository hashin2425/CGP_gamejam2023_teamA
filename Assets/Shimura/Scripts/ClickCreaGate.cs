using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCreaGate : MonoBehaviour
{
    [SerializeField] GameObject GateCanvas;
    void Start()
    {
        GateCanvas.SetActive(false);
    }

    
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GateCanvas.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                //ゲーム中断みたいになって、脱出しますか？　はい　いいえ　を表示する処理を書いといてほしい
                //アイテム数が足りないときは、あと何個で脱出できますと表示するとかも親切でいいと思う
                GateCanvas.SetActive(false);

            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GateCanvas.SetActive(false);
        }
    }
}
