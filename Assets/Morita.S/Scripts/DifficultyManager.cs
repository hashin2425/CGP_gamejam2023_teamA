using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyManager
{
    public static int DifficultyLevel = 1; // ������Փx��1�Ƃ���

    // ��Փx�𑝉�������֐�
    public static void IncreaseDifficulty()
    {
        DifficultyLevel++;

    }

    // ��Փx������������֐�
    public static void DecreaseDifficulty()
    {
        DifficultyLevel--;
        if (DifficultyLevel < 1)
        {
            DifficultyLevel = 1;
        }

    }
}