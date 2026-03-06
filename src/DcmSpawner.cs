using System;
using System.Collections.Generic;
using System.Linq;
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

    [Export]
    private MedCible MediateurCible;

    [Export]
    MedCible.EAlgoSelectionCible AlgoSelectionCible;

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

        if (newInstance is ICiblable ciblable)
        {
            Node2D cible = MediateurCible
                .EnsureValid()
                .ChoisirCible(AlgoSelectionCible, GlobalPosition);
            ciblable.SetCible(cible);
        }
        timer.EnsureValid().WaitTime = GD.RandRange(IntervalRange.X, IntervalRange.Y);
    }

    public IEnumerable<Node2D> GatherChildren()
    {
        return ChildManipulator.GatherChildren(SpawneeScene, this);
    }
}
