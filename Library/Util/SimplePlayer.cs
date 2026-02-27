using System;
using Godot;

public partial class SimplePlayer : Node2D
{
    [Export]
    private Node2D NodeToControl;

    [Export]
    private float VelocityPixelPerSecond = 100.0f;

    private bool _isActive = true;

    [Export]
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            //Alternative aux if dans les fonctions process et physics process
            SetProcess(value);
            SetPhysicsProcess(value);
        }
    }

    Vector2 _inputVector = new(0.0f, 0.0f);

    public override void _Ready() { }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double InDelta)
    {
        base._Process(InDelta);
        _inputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (_inputVector.Length() < 1.0f)
        {
            return;
        }
        _inputVector = _inputVector.Normalized();
    }

    public override void _PhysicsProcess(double InDelta)
    {
        base._PhysicsProcess(InDelta);
        if (NodeToControl is null)
        {
            return;
        }
        NodeToControl.Position += VelocityPixelPerSecond * (float)InDelta * _inputVector;
    }
}
