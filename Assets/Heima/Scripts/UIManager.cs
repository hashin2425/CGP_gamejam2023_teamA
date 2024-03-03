using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameData.ConstSettings;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance; //他のスクリプトからのアクセス用
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameClearUI;
    private GManager gManager;
    void Awake()
    {
        instance = this;
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
        SetCountdownText(TIME_LIMIT_SEC);
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