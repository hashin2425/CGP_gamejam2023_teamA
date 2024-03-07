using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameData.ConstSettings;

public class ButtonController : MonoBehaviour
{
    private UIManager uiManager;
    public void OnButtonClicked(string buttonName)
    {
        switch (buttonName)
        {
            case "stage":
                SceneManager.LoadScene(GAMESCENE_NAME); break;
            case "menu":
                PanelChange.titleLoadMode = 1;
                SceneManager.LoadScene(MENUSCENE_NAME); break;
            case "stageSelect":
                PanelChange.titleLoadMode = 2;
                SceneManager.LoadScene(MENUSCENE_NAME); break;
            case "restart":
                GManager.Instance.StopCountdownCoroutine();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); break;
            case "resumeGame":
                GManager.Instance.TogglePause(); break;
            case "resumeResult":
                uiManager = UIManager.Instance;
                uiManager.ShowItemUI(false); break;
            case "item":
                uiManager = UIManager.Instance;
                uiManager.ShowItemUI(true); break;
        }
    }
}
