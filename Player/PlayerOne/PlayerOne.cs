using Godot;

public class PlayerOne : KinematicBody2D
{
    private Vector2 _velocity = Vector2.Zero;

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        MoveAndCollide(_velocity * delta);
    }

    private void GetInput()
    {
        _velocity = _velocity = new Vector2();

        if (Input.IsActionPressed("p1_up"))
        {
            _velocity.y -= 1;
        }

        if (Input.IsActionPressed("p1_down"))
        {
            _velocity.y += 1;
        }

        _velocity = _velocity.Normalized() * Globals.PlayerSpeed;
    }
}
