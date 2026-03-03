using System;
using Godot;

public partial class DcmWindSystem : Node2D
{
    private float _SpeedScale = 1.0f;

    [Export]
    public float SpeedScale
    {
        get => _SpeedScale;
        set
        {
            //Style early return pour éviter les if imbriqués
            if (Mathf.IsEqualApprox(_SpeedScale, value))
            {
                return;
            }

            //value = valeur passée au setter
            _SpeedScale = value;
            SetSpeedScale(_SpeedScale);
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Tween tw = CreateTween();
        tw.TweenProperty(this, "SpeedScale", _SpeedScale + 0.5f, 2.0f);
        tw.TweenProperty(this, "SpeedScale", _SpeedScale - 0.5f, 2.0f);
        tw.SetLoops();
    }

    public void SetSpeedScale(float InSpeedScale)
    {
        //GetChildren() retourne les enfants directes (pas les petits-enfants)
        foreach (Node child in GetChildren())
        {
            if (child is Oscillation osc)
            {
                osc.SetSpeedScale(InSpeedScale);
            }
        }
    }
}
