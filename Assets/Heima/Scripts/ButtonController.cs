using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void OnButtonClicked(string buttonName)
    {
        switch (buttonName)
        {
            case "stage":
                SceneManager.LoadScene(""); break;
            case "menu":
                SceneManager.LoadScene(""); break;
            case "restart":
                GManager.Instance.StopCountdownCoroutine();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); break;
            case "resume":
                GManager.Instance.TogglePause(); break;
        }
    }
}
