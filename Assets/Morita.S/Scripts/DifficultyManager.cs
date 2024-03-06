using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyManager
{
    public static int DifficultyLevel = 1; // ‰Šú“ïˆÕ“x‚ğ1‚Æ‚·‚é

    // “ïˆÕ“x‚ğ‘‰Á‚³‚¹‚éŠÖ”
    public static void IncreaseDifficulty()
    {
        DifficultyLevel++;

    }

    // “ïˆÕ“x‚ğŒ¸­‚³‚¹‚éŠÖ”
    public static void DecreaseDifficulty()
    {
        DifficultyLevel--;
        if (DifficultyLevel < 1)
        {
            DifficultyLevel = 1;
        }

    }
}