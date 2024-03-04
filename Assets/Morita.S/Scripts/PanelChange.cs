using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject title;
    public GameObject mainmenu;
    public GameObject stage;
    public GameObject stage1; 
    public GameObject stage2;
    public GameObject stage3;
    public GameObject option;
    public GameObject item;

    void Start()
    {
        title.SetActive(true);
        mainmenu.SetActive(false);
        stage.SetActive(false);
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        option.SetActive(false);
        item.SetActive(false);
    }

    public void Title()
    {
        title.SetActive(true);
        mainmenu.SetActive(false);
        stage.SetActive(false);
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        option.SetActive(false);
        item.SetActive(false);
    }

    public void Mainmenu()
    {
        title.SetActive(false);
        mainmenu.SetActive(true);
        stage.SetActive(false);
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        option.SetActive(false);
        item.SetActive(false);
    }

    public void Stage()
    {
        title.SetActive(false);
        mainmenu.SetActive(false);
        stage.SetActive(true);
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        option.SetActive(false);
        item.SetActive(false);
    }
    public void Stage1()
    {
        title.SetActive(false);
        mainmenu.SetActive(false);
        stage.SetActive(false);
        stage1.SetActive(true);
        stage2.SetActive(false);
        stage3.SetActive(false);
        option.SetActive(false);
        item.SetActive(false);
    }
    public void Stage2()
    {
        title.SetActive(false);
        mainmenu.SetActive(false);
        stage.SetActive(false);
        stage1.SetActive(false);
        stage2.SetActive(true);
        stage3.SetActive(false);
        option.SetActive(false);
        item.SetActive(false);
    }
    public void Stage3()
    {
        title.SetActive(false);
        mainmenu.SetActive(false);
        stage.SetActive(false);
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(true);
        option.SetActive(false);
        item.SetActive(false);
    }
    public void Option()
    {
        title.SetActive(false);
        mainmenu.SetActive(false);
        stage.SetActive(false);
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        option.SetActive(true);
        item.SetActive(false);
    }
    public void Item()
    {
        title.SetActive(false);
        mainmenu.SetActive(false);
        stage.SetActive(false);
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        option.SetActive(false);
        item.SetActive(true);
    }
}