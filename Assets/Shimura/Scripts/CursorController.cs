using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameData.ConstSettings;

public class CursorController : MonoBehaviour
{
    [SerializeField] GManager gManager;
    void Start()
    {
        //カーソルを非表示
        Cursor.visible = false;
        //カーソルを画面中央にロック
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            //カーソルを表示
            Cursor.visible = true;
            //カーソルを自由に動かせるように
            Cursor.lockState = CursorLockMode.None;
            //Time.timeScaleを0に
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //カーソルを非表示
            Cursor.visible = false;
            //カーソルを画面中央にロック
            Cursor.lockState = CursorLockMode.Locked;
            //Time.timeScaleを1に
            Time.timeScale = 1;
        }
        //CursorDisplay();
    }
    void CursorDisplay()
    {
        switch (gManager.CurrentGameState)
        {
            case GameState.Playing:
                if (Input.GetKeyDown(KeyCode.Escape))
                {   
                    //カーソルを表示
                    Cursor.visible = true;
                    //カーソルを自由に動かせるように
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    //カーソルを非表示
                    Cursor.visible = false;
                    //カーソルを画面中央にロック
                    Cursor.lockState = CursorLockMode.Locked;   
                }
                break;
            
            default:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    //カーソルを表示
                    Cursor.visible = true;
                    //カーソルを自由に動かせるように
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
        }
    }
}
