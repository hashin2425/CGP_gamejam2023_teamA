using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameData.ConstSettings;

public class ClickCreaGate : MonoBehaviour
{
    [SerializeField] GameObject GateCanvas;
    [SerializeField] Canvas escapeDialogue;
    [SerializeField] TextMeshProUGUI confirmText;
    [SerializeField] GameObject yButton;
    [SerializeField] GameObject nButton;
    [SerializeField] GameObject okButton;
    private GManager gManager;
    void Start()
    {
        GateCanvas.SetActive(false);
        escapeDialogue.enabled = false;
        gManager = GManager.Instance;
        yButton.GetComponent<Button>().onClick.AddListener(OnYesButtonClicked);
        nButton.GetComponent<Button>().onClick.AddListener(OnNoButtonClicked);
        okButton.GetComponent<Button>().onClick.AddListener(OnOkButtonClicked);
    }

    
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GateCanvas.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                //ゲーム中断みたいになって、脱出しますか？　はい　いいえ　を表示する処理を書いといてほしい
                //アイテム数が足りないときは、あと何個で脱出できますと表示するとかも親切でいいと思う
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                GateCanvas.SetActive(false);
                Time.timeScale = 0;
                if (gManager.canEscape())
                {
                    confirmText.SetText("脱出しますか？");
                    yButton.SetActive(true);
                    nButton.SetActive(true);
                    okButton.SetActive(false);
                    escapeDialogue.enabled = true;
                }
                else
                {
                    int remainItemNum = requiredItemNum[DifficultyManager.DifficultyLevel - 1] - gManager.GetItemNum();
                    confirmText.SetText("まだ脱出できません！\n必要アイテム数: " + remainItemNum.ToString() + "個");
                    yButton.SetActive(false);
                    nButton.SetActive(false);
                    okButton.SetActive(true);
                    escapeDialogue.enabled = true;
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GateCanvas.SetActive(false);
        }
    }
    void OnYesButtonClicked()
    {
        escapeDialogue.enabled = false;
        gManager.ChangeGameState(GameState.GameClear);
    }
    void OnNoButtonClicked()
    {
        escapeDialogue.enabled = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void OnOkButtonClicked()
    {
        escapeDialogue.enabled = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
