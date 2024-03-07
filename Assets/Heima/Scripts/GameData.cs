using System.Collections.Generic;

namespace GameData
{
    //ÉQÅ[ÉÄÇ≈égópÇ∑ÇÈíËêîÇ»Ç«ÇÃê›íË
    public static class ConstSettings
    {
        public static readonly float TIME_LIMIT_SEC = 180.0f;
        public static readonly int SCORE_PER_SEC = 50;
        public static readonly string GAMESCENE_NAME = "Test_Heima";
        public static readonly string MENUSCENE_NAME = "Title_Scene";
        public static IReadOnlyList<int> requiredItemNum = new List<int>() { 0, 3, 5 };
        public static IReadOnlyDictionary<Items, int> itemScores = new Dictionary<Items, int>() {
            { Items.Mouse, 800 },
            { Items.Fish, 500 },
            { Items.Roomba, 700 },
            { Items.Matatabi, 300 },
            { Items.CannedFood, 500},
            { Items.GoldfishBowl, 500 },
            { Items.Dorayaki, 500 },
            { Items.Cucumber, 500 },
            { Items.Geta, 500 },
            { Items.BristleGrass, 1000 },
            { Items.Koban, 500 },
            { Items.Pearl, 600 },
            { Items.Scroll, 400 },
            { Items.BonitoFlakes, 500 },
            { Items.Bell, 500}
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