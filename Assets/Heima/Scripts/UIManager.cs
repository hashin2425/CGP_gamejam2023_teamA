using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameData.ConstSettings;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject pauseUI;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameClearUI;
    [SerializeField] GameObject itemUI;
    [SerializeField] GameObject content;
    //以下アイテムアイコンのprefab
    [SerializeField] GameObject iconMouse;
    [SerializeField] GameObject iconFish;
    [SerializeField] GameObject iconRoomba;
    [SerializeField] GameObject iconMatatabi;
    [SerializeField] GameObject iconCannedFood;
    [SerializeField] GameObject iconGoldfishBowl;
    [SerializeField] GameObject iconDorayaki;
    [SerializeField] GameObject iconCucumber;
    [SerializeField] GameObject iconGeta;
    [SerializeField] GameObject iconBristleGrass;
    [SerializeField] GameObject iconKoban;
    [SerializeField] GameObject iconPearl;
    [SerializeField] GameObject iconScroll;
    [SerializeField] GameObject iconBonitoFrakes;
    [SerializeField] GameObject iconBell;
    private GManager gManager;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Initialize();
    }
    //初期化処理
    void Initialize()
    {
        //GManagerのインスタンスを取得
        gManager = GManager.Instance;
        //UIの初期化
        pauseUI.SetActive(false);
        gameClearUI.SetActive(false);
        gameOverUI.SetActive(false);
        itemUI.SetActive(false);
        SetCountdownText(TIME_LIMIT_SEC);
    }
    //アイテム表示の準備
    void PrepItemScrollView(List<Items> itemList)
    {
        GameObject itemPrefab = null;
        foreach (var item in itemList)
        {
            switch (item)
            {
                case Items.Mouse:
                    itemPrefab = iconMouse; break;
                case Items.Fish:
                    itemPrefab = iconFish; break;
                case Items.Roomba:
                    itemPrefab = iconRoomba; break;
                case Items.Matatabi:
                    itemPrefab = iconMatatabi; break;
                case Items.CannedFood:
                    itemPrefab = iconCannedFood; break;
                case Items.GoldfishBowl:
                    itemPrefab = iconGoldfishBowl; break;
                case Items.Dorayaki:
                    itemPrefab = iconDorayaki; break;
                case Items.Cucumber:
                    itemPrefab = iconCucumber; break;
                case Items.Geta:
                    itemPrefab = iconGeta; break;
                case Items.BristleGrass:
                    itemPrefab = iconBristleGrass; break;
                case Items.Koban:
                    itemPrefab = iconKoban; break;
                case Items.Pearl:
                    itemPrefab = iconPearl; break;
                case Items.Scroll:
                    itemPrefab = iconScroll; break;
                case Items.BonitoFlakes:
                    itemPrefab = iconBonitoFrakes; break;
                case Items.Bell:
                    itemPrefab = iconBell; break;
            }
            GameObject iconInstance = Instantiate(itemPrefab);
            iconInstance.transform.SetParent(content.transform, false);
        }
    }
    //アイテムUIの表示切り替え
    public void ShowItemUI(bool tf)
    {
        itemUI.SetActive(tf);
    }
    //ポーズUIの表示切り替え
    public void ShowPauseUI(bool tf)
    {
        pauseUI.SetActive(tf);
    }
    //ゲームオーバー時の処理
    public void ActionGameOver()
    {
        gameOverUI.SetActive(true);
    }
    //ゲームクリア時の処理
    public void ActionGameClear()
    {
        PrepItemScrollView(gManager.ItemList);
        scoreText.SetText("Score: " + gManager.Score.ToString("N0"));
        gameClearUI.SetActive(true);
    }
    //カウントダウン表示
    public void SetCountdownText(float sec)
    {
        var span = new TimeSpan(0, 0, (int)sec);
        countdownText.text = span.ToString(@"mm\:ss");
    }
}