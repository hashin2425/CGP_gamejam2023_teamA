using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameData.ConstSettings;

public class sButtonController : MonoBehaviour
{
    public void OnButtonClicked(string buttonName)
    {
        //switchとは、引数の変数の値によって、処理を分岐させる文
        //case 値　の後に処理を書く
        //ここにはないが、変数がどのcaseにも当てはまらないときの処理をdefault;と書く(elseみたいなもの)
        switch (buttonName)
        {
            case "stage":
                SceneManager.LoadScene("Test_Heima"); break;
            case "menu":
                SceneManager.LoadScene("Test_Menu"); break;
            case "restart":
                GManager.Instance.StopCountdownCoroutine();
                //現在のシーンを再度読み込む処理
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); break;
            case "resume":
                GManager.Instance.TogglePause(); break;
        }
    }
}
