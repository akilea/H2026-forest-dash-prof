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
        Node2D cible = MediateurCible
            .EnsureValid()
            .ChoisirCible(MedCible.EAlgoSelectionCible.eChien, GlobalPosition);

        GD.Print(cible);
        cible.EnsureValid();

        //2 choix: interface (classique) OU classe commune
        if (newInstance is IEntity ent)
        {
            ent.SetCible(cible);
        }
        timer.EnsureValid().WaitTime = GD.RandRange(IntervalRange.X, IntervalRange.Y);
    }

    //Pourrait retourner des Souris ou autre classe au besoin
    public IEnumerable<Node2D> GatherChildren()
    {
        return ChildAccess.GatherChildren(SpawneeScene, this);
    }
}
