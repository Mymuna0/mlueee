using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public float Speed = 300.0f;
    [Export] private TouchJoystick Joystick;
    
    private AnimatedSprite2D _animatedSprite2D;

    public override void _Ready(){
        _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta) {
        Vector2 keyboardInput = Input.GetVector(
            "move_left", "move_right", "move_up", "move_down"
        );

        Vector2 touchInput = Vector2.Zero;
        if (Joystick != null)
        {
            touchInput = Joystick.GetJoystickVector();
        }

        Vector2 finalInput = (keyboardInput != Vector2.Zero) ? keyboardInput : touchInput;

        // Apply movement
        Velocity = finalInput * Speed;

        // Flip sprite logic
        if (finalInput.X != 0)
        {
            _animatedSprite2D.FlipH = (finalInput.X > 0);
        }

        // Animation logic
        if (finalInput == Vector2.Zero)
        {
            _animatedSprite2D.Play("idle");
        }
        else
        {
            _animatedSprite2D.Play("run");
        }

        MoveAndSlide();
    }
}