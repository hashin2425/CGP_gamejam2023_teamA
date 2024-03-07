using System.Collections.Generic;

namespace GameData
{
    //ÉQÅ[ÉÄÇ≈égópÇ∑ÇÈíËêîÇ»Ç«ÇÃê›íË
    public static class ConstSettings
    {
        public static readonly float TIME_LIMIT_SEC = 180.0f;
        public static readonly int SCORE_PER_SEC = 100;
        public static readonly string GAMESCENE_NAME = "Test_Heima";
        public static readonly string MENUSCENE_NAME = "Title_Scene";
        public static IReadOnlyList<int> requiredItemNum = new List<int>() { 0, 3, 5 };
        public static IReadOnlyDictionary<Items, int> itemScores = new Dictionary<Items, int>() {
            { Items.Mouse, 0 },
            { Items.Fish, 0 },
            { Items.Roomba, 0 },
            { Items.Matatabi, 0 },
            { Items.CannedFood, 0},
            { Items.GoldfishBowl, 0 },
            { Items.Dorayaki, 0 },
            { Items.Cucumber, 0 },
            { Items.Geta, 0 },
            { Items.BristleGrass, 0 },
            { Items.Koban, 0 },
            { Items.Pearl, 0 },
            { Items.Scroll, 0 },
            { Items.BonitoFlakes, 0 },
            { Items.Bell, 0}
        };
        public enum GameState
        {
            Playing,
            Pause,
            GameOver,
            GameClear
        }
        public enum Items
        {
            Mouse,
            Fish,
            Roomba,
            Matatabi,
            CannedFood,
            GoldfishBowl,
            Dorayaki,
            Cucumber,
            Geta,
            BristleGrass,
            Koban,
            Pearl,
            Scroll,
            BonitoFlakes,
            Bell
        }
    }
}