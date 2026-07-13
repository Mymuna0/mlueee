using Godot;

public partial class TouchJoystick : Control
{
    private Vector2 _origin;
    private bool _isDragging = false;
    private Vector2 _joystickVector = Vector2.Zero;

    // This is the strength of the movement
    public Vector2 GetJoystickVector() => _joystickVector;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventScreenTouch touch)
        {
            if (touch.Pressed)
            {
                _origin = touch.Position;
                _isDragging = true;
            }
            else
            {
                _isDragging = false;
                _joystickVector = Vector2.Zero;
            }
        }
        else if (@event is InputEventScreenDrag drag && _isDragging)
        {
            // Calculate the difference between start and current position
            Vector2 diff = drag.Position - _origin;
            
            // Normalize and clamp to a max radius (e.g., 100 pixels)
            float maxRadius = 100.0f;
            _joystickVector = diff.Length() > maxRadius ? diff.Normalized() : diff / maxRadius;
        }
    }
}