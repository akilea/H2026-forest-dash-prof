using System;
using Godot;
using Godot.Collections;
using Utils;

public partial class DcmSpawnerCible : Node2D
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
    }

    public void Spawn()
    {
        SpawneeScene.EnsureValid();
        Node2D newInstance = SpawneeScene.Instantiate<Node2D>();
        newInstance.EnsureValid();
        AddChild(newInstance);
        timer.EnsureValid().WaitTime = GD.RandRange(IntervalRange.X, IntervalRange.Y);
    }

    public Node2D ChoisirCible(Vector2 InPosition)
    {
        Array<Node> groupNode = GetTree().GetNodesInGroup("Chasseur");

        Node2D cible = null;
        float distance = float.MaxValue;

        foreach (Node node in groupNode)
        {
            Node2D cibleCandidate = node as Node2D;
            if (!cibleCandidate.IsValid())
            {
                continue;
            }
            float distanceCandidate = (InPosition - cibleCandidate.GlobalPosition).Length();
            cibleCandidate = distanceCandidate < distance ? cibleCandidate : cible;
        }
        return cible;
    }
}
