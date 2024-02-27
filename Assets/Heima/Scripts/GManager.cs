using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameData.ConstSettings;
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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        currentGameState = GameState.GameClear;
    }
    private float countdownSec;
    private int score;
    public int Score => score;
    private UIManager uiManager;
    private Coroutine countdownCoroutine;
    private List<Items> itemList;
    private GameState currentGameState;
    public float CountdownSec => countdownSec;
    public GameState CurrentGameState => currentGameState;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeGameState(GameState.GameClear);
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
                uiManager.ActionGameOver(); break;
            case GameState.GameClear:
                StopCountdownCoroutine();
                uiManager.ActionGameClear(); break;
            default: break;
        }
    }
    //初期化処理
    void Initialize()
    {
        Debug.Log("initialize");
        uiManager = UIManager.Instance;
        countdownSec = TIME_LIMIT_SEC;
        score = 0;
        itemList = new List<Items>();
        ChangeGameState(GameState.Playing);
        if (countdownCoroutine!=null) StopCountdownCoroutine();
        countdownCoroutine = StartCoroutine(Countdown());
    }
    //アイテム拾った時の処理
    public void CollectItem(Items item)
    {
        itemList.Add(item);
        switch (item)
        {
            case Items.Mouse:
                score += 200; break;
            default :
                score += DEFAULT_ITEM_SCORE; break;
        }
    }
    //シーン読み込みのイベントハンドラ
    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (Time.timeScale == 0) Time.timeScale = 1;
        if (scene.name == "Test_Heima") Initialize();
    }
    //ポーズの切り替え
    public void TogglePause()
    {
        switch (currentGameState)
        {
            case GameState.Playing:
                ChangeGameState(GameState.Pause);
                uiManager.ShowPauseUI(true);
                Time.timeScale = 0;
                Debug.Log("Pause");
                break;
            case GameState.Pause:
                ChangeGameState(GameState.Playing);
                uiManager.ShowPauseUI(false);
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
                uiManager.SetCountdownText(countdownSec);
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