using System;
using Godot;

public partial class Oscillation : Node2D
{
    [Export]
    private Node2D node;

    [Export]
    private Vector2 amplitudeRange = new(Mathf.Pi * 0.1f, Mathf.Pi * 0.25f);

    [Export]
    private Vector2 durationRange = new(0.1f, 0.5f);

    private Tween _Tween;

    public override void _Ready()
    {
        if (!IsInstanceValid(node))
        {
            return;
        }

        float randomAmplitude = (float)GD.RandRange(amplitudeRange.X, amplitudeRange.Y);
        float randomDuration = (float)GD.RandRange(durationRange.X, durationRange.Y);

        node.Rotation += randomAmplitude * 0.5f;

        _Tween = CreateTween();

        _Tween
            .TweenProperty(node, "rotation", node.Rotation - randomAmplitude, randomDuration)
            .SetEase(Tween.EaseType.InOut)
            .SetTrans(Tween.TransitionType.Cubic);

        //Tweener supportent le chaîning (appels subséquents de méthodes)
        _Tween
            .TweenProperty(node, "rotation", node.Rotation, randomDuration)
            .SetEase(Tween.EaseType.InOut)
            .SetTrans(Tween.TransitionType.Cubic);

        _Tween.SetLoops();
    }

    public void SetSpeedScale(float InSpeedScale)
    {
        _Tween?.SetSpeedScale(InSpeedScale);
    }
}
