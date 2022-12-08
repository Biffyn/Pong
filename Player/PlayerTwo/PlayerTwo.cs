using Godot;

public class PlayerTwo : KinematicBody2D
{
    private Ball _ball;
    private Vector2 _velocity = Vector2.Zero;

    public override void _Ready()
    {
        _ball = (Ball)GetParent().FindNode("Ball");
    }

    public override void _PhysicsProcess(float delta)
    {
        if (Globals.GameMode == GameMode.TwoPlayer)
        {
            GetInput();
            MoveAndCollide(_velocity * delta);
        }
        else
        {
            _velocity = new Vector2(0, GetDirection());
            MoveAndSlide(_velocity * Globals.AiPlayerSpeed);
        }
    }

    private int GetDirection()
    {
        if (Mathf.Abs(_ball.Position.y - Position.y) > 25)
        {
            return _ball.Position.y > Position.y ? 1 : -1;
        }

        return 0;
    }

    private void GetInput()
    {
        _velocity = _velocity = new Vector2();

        if (Input.IsActionPressed("ui_up"))
        {
            _velocity.y -= 1;
        }

        if (Input.IsActionPressed("ui_down"))
        {
            _velocity.y += 1;
        }

        _velocity = _velocity.Normalized() * Globals.PlayerSpeed;
    }
}
