using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameData.ConstSettings;

public class MoritaSceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void change_button()
    {
        SceneManager.LoadScene(GAMESCENE_NAME);
    }
}
