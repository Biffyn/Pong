using Godot;

public class Ball : KinematicBody2D
{
    private int _speed = 0;
    private Vector2 _velocity = new Vector2();

    public override void _PhysicsProcess(float delta)
    {
        _velocity = _velocity.Normalized() * _speed;
        var collision = MoveAndCollide(_velocity * delta);

        if (collision != null)
        {
            string collisionName = collision.Collider.GetType().Name;

            if (collisionName != "StaticBody2D") 
            {
                GetNode<AudioStreamPlayer>("CollisionSound").Play();
            }

            _velocity = _velocity.Bounce(collision.Normal);            
        }
    }

    public void Start()
    {
        _speed = 750;
        RandomDirection();
    }

    public void Stop()
    {
        _speed = 0;
    }

    private void RandomDirection()
    {
        GD.Randomize();

        float[] xCoords = new float[] { -1, 1 };
        float[] yCoords = new float[] { -0.6f, -0.8f, 0.6f, 0.8f };

        _velocity.x = xCoords[(int)(GD.Randi() % 2)];
        _velocity.y = yCoords[(int)(GD.Randi() % 4)];
    }
}
