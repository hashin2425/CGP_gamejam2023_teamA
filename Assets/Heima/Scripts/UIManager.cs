using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameData.ConstSettings;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameClearUI;
    GManager gManager;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
    // Update is called once per frame
    void Update()
    {
        
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
    public void ShowPauseUI(bool tf)
    {
        pauseUI.SetActive(tf);
    }
    public void ActionGameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void ActionGameClear()
    {
        int score = gManager.Score + (int)gManager.CountdownSec * SCORE_PER_SEC;
        scoreText.SetText("Score: " + score.ToString("N0"));
        gameClearUI.SetActive(true);
    }
    public void SetCountdownText(float sec)
    {
        var span = new TimeSpan(0, 0, (int)sec);
        countdownText.text = span.ToString(@"mm\:ss");
    }
}