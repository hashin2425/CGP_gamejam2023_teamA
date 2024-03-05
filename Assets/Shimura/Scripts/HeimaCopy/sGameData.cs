namespace GameData
{
    //�Q�[���Ŏg�p����萔�Ȃǂ̐ݒ�
    public static class sConstSettings
    {
        public static readonly float TIME_LIMIT_SEC = 30.0f;
        public static readonly int SCORE_PER_SEC = 100;
        public static readonly int DEFAULT_ITEM_SCORE = 500;
        public static readonly string GAMESCENE_NAME = "Test_Heima";

        //enumとは複数の定数をまとめておく型
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
            Swordfish,
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