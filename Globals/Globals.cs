public enum GameMode
{
    OnePlayer,
    TwoPlayer
}

public static class Globals
{
    public static GameMode GameMode { get; set; } = GameMode.OnePlayer;
    public static int WinningScore { get; set; } = 5;
    public static int PlayerSpeed { get; set; } = 400;
    public static int AiPlayerSpeed { get; set; } = 420;
}
