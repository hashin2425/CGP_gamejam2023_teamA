using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    public enum Difficulty { Easy, Normal, Hard }; // ��Փx�̗񋓌^

    public Difficulty difficultyLevel; // �{�^���ɑΉ������Փx

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

        // �Q�[���v���C�̃V�[���Ɉړ�
        //SceneManager.LoadScene("GamePlayScene");
    }
}