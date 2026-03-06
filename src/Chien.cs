using System;
using Godot;
using Utils;

public partial class Chien : Node2D, IEntity
{
    [ExportGroup("External")]
    [Export]
    public Node2D Cible
    {
        get { return _Poursuite.EnsureValid().Cible; }
        set { _Poursuite.EnsureValid().Cible = value; }
    }

    [ExportGroup("Internal")]
    [Export]
    Poursuite _Poursuite;

    public void SetCible(Node2D InCible)
    {
        Cible = InCible;
    }

    public override void _Ready()
    {
        base._Ready();
        Scale = Vector2.Zero;
        Tween tween = CreateTween();
        tween
            .TweenProperty(this, "scale", Vector2.One, 0.5f)
            .SetTrans(Tween.TransitionType.Back)
            .SetEase(Tween.EaseType.Out);
    }
}
