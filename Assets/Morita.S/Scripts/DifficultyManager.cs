using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyManager
{
    public static int DifficultyLevel = 1; // 初期難易度を1とする

    // 難易度を増加させる関数
    public static void IncreaseDifficulty()
    {
        DifficultyLevel++;

    }

    // 難易度を減少させる関数
    public static void DecreaseDifficulty()
    {
        DifficultyLevel--;
        if (DifficultyLevel < 1)
        {
            DifficultyLevel = 1;
        }

    }
}