using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameData.Settings;
public class GManager : MonoBehaviour
{
    private static GManager instance;
    public static GManager Instance => instance; //���̃X�N���v�g����̃A�N�Z�X�p
    private GManager() { }
    void Awake()
    {
        //GManager�̃C���X�^���X��1�ł��邱�Ƃ�ۏ�
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //������
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
    //�Q�[����Ԃ̕ύX
    public void ChangeGameState(GameState state)
    {
        Debug.Log("Current Game State:" + state);
        currentGameState = state;
        OnGameStateChanged(state);
    }
    //�Q�[����Ԃ��ς�������̏���
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
    //����������
    void Init()
    {
        Debug.Log("initialize");
        Time.timeScale = 1;
        countdownSec = TIME_LIMIT_SEC;
        SetCountdownText(countdownSec);
        ChangeGameState(GameState.Playing);
        countdownCoroutine = StartCoroutine(Countdown());
    }
    //�J�E���g�_�E���̕\����ݒ�
    void SetCountdownText(float sec)
    {
        var span = new TimeSpan(0, 0, (int)sec);
        countdownText.text = span.ToString(@"mm\:ss");
    }
    //�A�C�e���E�������̏���, �܂�
    public void CollectItem()
    {
    }
    //�|�[�Y�̐؂�ւ�
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
    //�J�E���g�_�E���̃R���[�`�����~�߂�
    public void StopCountdownCoroutine() => StopCoroutine(countdownCoroutine);
    //�J�E���g�_�E������R���[�`��
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
        //�Q�[���I�[�o�[
        Debug.Log("GameOver");
        ChangeGameState(GameState.GameOver);
        yield break;
    }
}