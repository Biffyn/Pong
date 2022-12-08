using Godot;

public class Level : Node
{
    private int _playerOneScore = 0;
    private int _playerTwoScore = 0;

    public override void _Ready()
    {
        GetNode<Timer>("StartTimer").Start();
        GetNode<Label>("UI/Countdown").Visible = true;
    }

    public override void _Process(float delta)
    {
        var timeLeft = (int)GetNode<Timer>("StartTimer").TimeLeft + 1;

        GetNode<Label>("UI/PlayerOneScore").Text = _playerOneScore.ToString();
        GetNode<Label>("UI/PlayerTwoScore").Text = _playerTwoScore.ToString();
        GetNode<Label>("UI/Countdown").Text = timeLeft.ToString();
    }

    protected void OnPlayerOneGoalBodyEntered(Node _body)
    {
        _playerTwoScore += 1;
        ScoreAchieved();
    }

    protected void OnPlayerTwoGoalBodyEntered(Node _body)
    {
        _playerOneScore += 1;
        ScoreAchieved();
    }

    protected void OnStartTimerTimeout()
    {
        GetNode<Label>("UI/Countdown").Visible = false;
        GetTree().CallGroup("BallGroup", "Start");
    }

    protected void OnGameOverTimerTimeout()
    {
        GetTree().ChangeScene("res://MainMenu/MainMenu.tscn");
    }

    private void ScoreAchieved()
    {
        bool gameOver =
            _playerOneScore == Globals.WinningScore || _playerTwoScore == Globals.WinningScore;

        GetTree().CallGroup("BallGroup", "Stop");

        if (gameOver)
        {
            string winText =
                _playerOneScore == Globals.WinningScore ? "Player One Wins" : "Player Two Wins";

            GetNode<Label>("UI/WinLabel").Text = winText;
            GetNode<Label>("UI/WinLabel").Visible = true;
            GetNode<Timer>("GameOverTimer").Start();
        }
        else
        {
            GetNode<Ball>("Ball").Position = new Vector2(640, 360);
            GetNode<Timer>("StartTimer").Start();
            GetNode<Label>("UI/Countdown").Visible = true;
        }
    }
}
