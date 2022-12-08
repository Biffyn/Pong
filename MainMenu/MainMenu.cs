using Godot;

public class MainMenu : Node
{
    [Export]
    private readonly PackedScene _levelSceneFile;

    public override void _Ready()
    {
        GetNode<Button>("UI/Buttons/OnePlayerButton").GrabFocus();
    }

    protected void OnOnePlayerButtonUp()
    {
        Globals.GameMode = GameMode.OnePlayer;
        GetTree().ChangeScene(_levelSceneFile.ResourcePath);
    }

    protected void OnTwoPlayerButtonUp()
    {
        Globals.GameMode = GameMode.TwoPlayer;
        GetTree().ChangeScene(_levelSceneFile.ResourcePath);
    }

    protected void OnQuitButtonUp()
    {
        GetTree().Quit();
    }
}
