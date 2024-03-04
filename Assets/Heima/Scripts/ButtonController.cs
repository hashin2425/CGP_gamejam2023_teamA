using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameData.ConstSettings;

public class ButtonController : MonoBehaviour
{
    public void OnButtonClicked(string buttonName)
    {
        switch (buttonName)
        {
            case "stage":
                SceneManager.LoadScene("Test_Heima"); break;
            case "menu":
                SceneManager.LoadScene("Test_Menu"); break;
            case "restart":
                GManager.Instance.StopCountdownCoroutine();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); break;
            case "resume":
                GManager.Instance.TogglePause(); break;
        }
    }
}
