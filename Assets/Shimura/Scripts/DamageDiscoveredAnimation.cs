using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDiscoveredAnimation : MonoBehaviour
{
    GameObject Enemy;
    GameObject DamagePanel;
    void Start()
    {
        Enemy = GameObject.Find ("ghost");
        DamagePanel = GameObject.Find ("DamagePanel");
        
    }

    void Update()
    {
            
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
