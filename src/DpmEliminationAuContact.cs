using System;
using Godot;
using Utils;

public partial class DpmEliminationAuContact : Area2D
{
    [ExportGroup("External")]
    [Export]
    private Node2D RootToEliminate;

    public override void _Ready()
    {
        base._Ready();
        AreaEntered += OnTouch;
    }

    private void OnTouch(Area2D InArea)
    {
        RootToEliminate.EnsureValid();
        //1) Toujours tester simplement
        //GD.Print("Souris POUF");

        //2) Éliminer
        //Le noeud devient invalide immédiatement.
        Tween tween = CreateTween();
        tween
            .TweenProperty(RootToEliminate, "scale", Vector2.Zero, 0.8f)
            .SetTrans(Tween.TransitionType.Cubic)
            .SetEase(Tween.EaseType.Out);
        tween.SetParallel(true);
        tween
            .TweenProperty(RootToEliminate, "rotation", 2 * Mathf.Pi, 0.8f)
            .SetTrans(Tween.TransitionType.Cubic)
            .SetEase(Tween.EaseType.Out);
        tween.SetParallel(false);
        tween.Finished += RootToEliminate.QueueFree;
    }
}
