using System;
using Godot;
using Utils;

public partial class Chien : Node2D, ICiblable
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

    [Export]
    EntityAnimation _Animation;

    public override void _Ready()
    {
        base._Ready();
        Vector2 oldScale = Scale;
        Scale = Vector2.Zero;
        Tween tween = CreateTween();
        tween
            .TweenProperty(this, "scale", oldScale, 0.5f)
            .SetTrans(Tween.TransitionType.Back)
            .SetEase(Tween.EaseType.Out);
    }

    public void SetCible(Node2D InCible)
    {
        Cible = InCible;
    }
}
