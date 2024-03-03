using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameData.ConstSettings;

public class sUIManager : MonoBehaviour
{
    private static sUIManager instance;
    public static sUIManager Instance => instance; //���̃X�N���v�g����̃A�N�Z�X�p
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameClearUI;
    private sGManager gManager;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Initialize();
    }
    //����������
    void Initialize()
    {
        //GManager�̃C���X�^���X���擾
        gManager = sGManager.Instance;
        //UI�̏�����
        pauseUI.SetActive(false);
        gameClearUI.SetActive(false);
        gameOverUI.SetActive(false);
        SetCountdownText(TIME_LIMIT_SEC);
    }
    //�|�[�YUI�̕\���؂�ւ�
    public void ShowPauseUI(bool tf)
    {
        pauseUI.SetActive(tf);
    }
    //�Q�[���I�[�o�[���̏���
    public void ActionGameOver()
    {
        gameOverUI.SetActive(true);
    }
    //�Q�[���N���A���̏���
    public void ActionGameClear()
    {
        scoreText.SetText("Score: " + gManager.Score.ToString("N0"));
        gameClearUI.SetActive(true);
    }
    //�J�E���g�_�E���\��
    public void SetCountdownText(float sec)
    {
        var span = new TimeSpan(0, 0, (int)sec);
        countdownText.text = span.ToString(@"mm\:ss");
    }
}