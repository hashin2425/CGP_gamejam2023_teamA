using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameData.Settings;
public class GManager : MonoBehaviour
{
    private static GManager instance;
    public static GManager Instance => instance; //他のスクリプトからのアクセス用
    private GManager() { }
    void Awake()
    {
        //GManagerのインスタンスが1つであることを保証
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //初期化
        Init();
    }
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameClearUI;
    private float countdownSec;
    private Coroutine countdownCoroutine;
    private GameState currentGameState;
    public GameState CurrentGameState => currentGameState;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    //ゲーム状態の変更
    public void ChangeGameState(GameState state)
    {
        Debug.Log("Current Game State:" + state);
        currentGameState = state;
        OnGameStateChanged(state);
    }
    //ゲーム状態が変わった時の処理
    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.GameOver:
                gameOverUI.SetActive(true); break;
            case GameState.GameClear:
                StopCountdownCoroutine();
                gameClearUI.SetActive(true); break;
            default: break;
        }
    }
    //初期化処理
    void Init()
    {
        Debug.Log("initialize");
        Time.timeScale = 1;
        countdownSec = TIME_LIMIT_SEC;
        SetCountdownText(countdownSec);
        ChangeGameState(GameState.Playing);
        countdownCoroutine = StartCoroutine(Countdown());
    }
    //カウントダウンの表示を設定
    void SetCountdownText(float sec)
    {
        var span = new TimeSpan(0, 0, (int)sec);
        countdownText.text = span.ToString(@"mm\:ss");
    }
    //アイテム拾った時の処理, まだ
    public void CollectItem()
    {
    }
    //ポーズの切り替え
    public void TogglePause()
    {
        switch (currentGameState)
        {
            case GameState.Playing:
                ChangeGameState(GameState.Pause);
                pauseUI.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Pause");
                break;
            case GameState.Pause:
                ChangeGameState(GameState.Playing);
                pauseUI.SetActive(false);
                Time.timeScale = 1;
                Debug.Log("UnPause");
                break;
            default : break;
        }
    }
    //カウントダウンのコルーチンを止める
    public void StopCountdownCoroutine() => StopCoroutine(countdownCoroutine);
    //カウントダウンするコルーチン
    IEnumerator Countdown()
    {
        Debug.Log("StartCoroutine");
        while (countdownSec > 0)
        {
            if (currentGameState == GameState.Playing)
            {
                yield return new WaitForSeconds(1.0f);
                countdownSec -= 1.0f;
                SetCountdownText(countdownSec);
                Debug.Log("Time Limit: " + countdownSec);
            }
            else
            {
                yield return null;
            }
        }
        //ゲームオーバー
        Debug.Log("GameOver");
        ChangeGameState(GameState.GameOver);
        yield break;
    }
}