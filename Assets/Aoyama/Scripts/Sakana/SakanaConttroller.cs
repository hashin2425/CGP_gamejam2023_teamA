using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakanaConttroller : MonoBehaviour
{
    [Header("PlayerのHP管理のscript")] [SerializeField] HP3manager HP3manager;

    // Start is called before the first frame update
    void Start()
    {
        
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