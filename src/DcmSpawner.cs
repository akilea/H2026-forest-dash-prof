using System;
using Godot;
using Godot.Collections;
using Utils;

public partial class DcmSpawner : Node2D
{
    [ExportGroup("External")]
    [Export]
    private PackedScene SpawneeScene;

    [Export]
    private Vector2 IntervalRange = new(1.0f, 2.0f);

    [ExportGroup("Internal")]
    [Export]
    private Timer timer;

    public override void _Ready()
    {
        base._Ready();
        timer.EnsureValid().Timeout += Spawn;
    }

    public void Spawn()
    {
        SpawneeScene.EnsureValid();
        Node2D newInstance = SpawneeScene.Instantiate<Node2D>();
        newInstance.EnsureValid();
        AddChild(newInstance);
        timer.EnsureValid().WaitTime = GD.RandRange(IntervalRange.X, IntervalRange.Y);
    }
}
