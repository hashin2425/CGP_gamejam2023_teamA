using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;//Linqという機能があるらしい。へー
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameData.ConstSettings;
public class sGManager : MonoBehaviour
{
    private static sGManager instance;
    public static sGManager Instance => instance; //他のスクリプトからのアクセス用
    private sGManager() { }
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
        //シーンロードをイベントリスナーに追加
        //シーンの読み込みが完了したタイミングで、今追加した関数(SceneLoaded)が呼ばれるようにしている
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.C)) //仮
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
                score += (int)countdownSec * SCORE_PER_SEC;
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
        if (countdownCoroutine != null) StopCountdownCoroutine();
        countdownCoroutine = StartCoroutine(Countdown());
    }
    //アイテム拾った時の処理
    public void CollectItem(Items item)
    {
        itemList.Add(item);
        score += itemScores[item];
    }
    //セーブ, 使うかわからん, 並列処理
    void Save()
    {
        Task.Run(() =>
        {
            //リストを集計して辞書型にする
            var itemDict = itemList.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            //アイテムごとにその数をセーブ
            foreach (var item in itemDict)
            {
                int numOfItem = PlayerPrefs.GetInt(item.Key.ToString(), 0);
                numOfItem += item.Value;
                PlayerPrefs.SetInt(item.Key.ToString(), numOfItem);
            }
        });
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