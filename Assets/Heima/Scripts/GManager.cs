using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private float countdownSec;
    private int score;
    public int Score => score;
    private UIManager uiManager;
    private Coroutine countdownCoroutine;
    private List<Items> itemList;
    public List<Items> ItemList => itemList;
    private GameState currentGameState;
    public GameState CurrentGameState => currentGameState;
    void Start()
    {
        //シーンロードをイベントリスナーに追加
        SceneManager.sceneLoaded += SceneLoaded;
        //現在のシーンがゲームシーンならば初期化, それ以外ならとりあえずゲームクリア状態に設定
        if (SceneManager.GetActiveScene().name == GAMESCENE_NAME)
        {
            Initialize();
            ChangeGameState(GameState.Playing);
        }
        else
        {
            currentGameState = GameState.GameClear;
        }
        //PlayerPrefs.DeleteAll();
    }
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
                uiManager.ActionGameOver(); 
                Time.timeScale = 0;break;
            case GameState.GameClear:
                StopCountdownCoroutine();
                Save();
                score += (int)countdownSec * SCORE_PER_SEC;
                uiManager.ActionGameClear(); 
                Time.timeScale = 0;break;
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
        if (countdownCoroutine != null) StopCountdownCoroutine();
        countdownCoroutine = StartCoroutine(Countdown());
    }
    //アイテムの数を返す
    public int GetItemNum()
    {
        int tmp = itemList.Count();
        return tmp;
    }
    //アイテム拾った時の処理
    public void CollectItem(Items item)
    {
        Debug.Log("Get item: " + item);
        itemList.Add(item);
        score += itemScores[item];
    }
    //クリア可能かチェック
    public bool canEscape()
    {
        if (GetItemNum() >= requiredItemNum[DifficultyManager.DifficultyLevel-1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //セーブ, 使うかわからん
    void Save()
    {
        //アイテムごとに累計取得数をセーブ
        foreach (var item in itemList)
        {
            int numOfItem = PlayerPrefs.GetInt(item.ToString(), 0);
            numOfItem++;
            PlayerPrefs.SetInt(item.ToString(), numOfItem);
        }
    }
    //シーン読み込みのイベントハンドラ
    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //ポーズ状態からシーン遷移するとtimeScaleが0のままなので
        if (Time.timeScale == 0) Time.timeScale = 1;
        //ゲームシーンが読み込まれたら初期化
        if (scene.name == GAMESCENE_NAME) Initialize();
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
            default: break;
        }
    }
    //カウントダウンのコルーチンを止める
    public void StopCountdownCoroutine()
    {
        StopCoroutine(countdownCoroutine);
    }
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
        Debug.Log("GameOver");
        ChangeGameState(GameState.GameOver);
        yield break;
    }
}