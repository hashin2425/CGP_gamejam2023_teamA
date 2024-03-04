using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    public enum Difficulty { Easy, Normal, Hard }; // 難易度の列挙型

    public Difficulty difficultyLevel; // ボタンに対応する難易度

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeDifficultyAndStartGame);
    }

    void ChangeDifficultyAndStartGame()
    {
        switch (difficultyLevel)
        {
            case Difficulty.Easy:
                DifficultyManager.DifficultyLevel = 1;
                Debug.Log("Difficultylv."+ DifficultyManager.DifficultyLevel);
                break;
            case Difficulty.Normal:
                DifficultyManager.DifficultyLevel = 2;
                Debug.Log("Difficultylv." + DifficultyManager.DifficultyLevel);
                break;
            case Difficulty.Hard:
                DifficultyManager.DifficultyLevel = 3;
                Debug.Log("Difficultylv." + DifficultyManager.DifficultyLevel);
                break;
        }

        // ゲームプレイのシーンに移動
        //SceneManager.LoadScene("GamePlayScene");
    }
}