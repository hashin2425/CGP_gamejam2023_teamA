using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameClearUI;
    private readonly float TIME_LIMIT_SEC = 30.0f;
    private float countdownSec;
    private bool isPause;
    private Coroutine countdownCoroutine;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    //初期化処理
    void Init()
    {
        Debug.Log("initialize");
        Time.timeScale = 1;
        isPause = false;
        countdownSec = TIME_LIMIT_SEC;
        SetCountdownText(countdownSec);
        countdownCoroutine = StartCoroutine(CountDown());
    }
    //カウントダウンの表示を設定
    void SetCountdownText(float sec)
    {
        var span = new TimeSpan(0, 0, (int)sec);
        countdownText.text = span.ToString(@"mm\:ss");
    }
    //ポーズの切り替え
    public void TogglePause()
    {
        if (!isPause)
        {
            isPause = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Pause");
        }
        else
        {
            isPause = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("UnPause");
        }
    }
    public void StopCountdownCoroutine()
    {
        StopCoroutine(countdownCoroutine);
    } 
    //カウントダウンするコルーチン
    IEnumerator CountDown()
    {
        Debug.Log("StartCoroutine");
        while (countdownSec > 0)
        {
            if (!isPause)
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
    }
}