using System;
using System.Collections.Generic;
//Language Integrated Query

using System.Linq;
using Godot;
using Godot.Collections;
using Utils;

public partial class DCM_Spawner : Node2D
{
    [ExportGroup("External")]
    [Export]
    private PackedScene SpawneeScene;

    [Export]
    private MedCible.EAlgoSelectionCible AlgoSelectionCible;

    [Export]
    private MedCible MediateurCible;

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

    //Pourrait retourner des Souris ou autre classe au besoin
    public IEnumerable<Node2D> GatherChildren()
    {
        var state = SpawneeScene.GetState();
        // index 0 = root node dans de la scène
        StringName nodeType = state.GetNodeType(0);
        return FindChildren("*", nodeType, recursive: false, owned: false).OfType<Node2D>();
    }
}
