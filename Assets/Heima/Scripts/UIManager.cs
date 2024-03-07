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
    [SerializeField] Canvas pauseUI;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;
    [SerializeField] Canvas gameOverUI;
    [SerializeField] Canvas gameClearUI;
    [SerializeField] Canvas itemUI;
    [SerializeField] GameObject content;
    //�ȉ��A�C�e���A�C�R����prefab
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
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip gameCreaSE;
    [SerializeField] AudioClip gameOverSE;

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
    //����������
    void Initialize()
    {
        //GManager�̃C���X�^���X���擾
        gManager = GManager.Instance;
        //UI�̏�����
        pauseUI.enabled = false;
        gameClearUI.enabled = false;
        gameOverUI.enabled = false;
        itemUI.enabled = false;
        SetCountdownText(TIME_LIMIT_SEC);
    }
    //�A�C�e���\���̏���
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
    //�A�C�e��UI�̕\���؂�ւ�
    public void ShowItemUI(bool tf)
    {
        itemUI.enabled = tf;
    }
    //�|�[�YUI�̕\���؂�ւ�
    public void ShowPauseUI(bool tf)
    {
        pauseUI.enabled = tf;
    }
    //�Q�[���I�[�o�[���̏���
    public void ActionGameOver()
    {
        gameOverUI.enabled = true;
        audioSource.GetComponent<AudioSource>().PlayOneShot(gameOverSE);
    }
    //�Q�[���N���A���̏���
    public void ActionGameClear()
    {
        PrepItemScrollView(gManager.ItemList);
        scoreText.SetText("Score: " + gManager.Score.ToString("N0"));
        audioSource.GetComponent<AudioSource>().PlayOneShot(gameCreaSE);
        gameClearUI.enabled = true;
    }
    //�J�E���g�_�E���\��
    public void SetCountdownText(float sec)
    {
        var span = new TimeSpan(0, 0, (int)sec);
        countdownText.text = span.ToString(@"mm\:ss");
    }
}