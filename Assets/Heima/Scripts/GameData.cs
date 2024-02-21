namespace GameData
{
    //ゲームで使用する定数などの設定
    public static class Settings
    {
        public static readonly float TIME_LIMIT_SEC = 30.0f;
        public enum GameState
        {
            Playing,
            Pause,
            GameOver,
            GameClear
        }
    }
}