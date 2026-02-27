using System;
using Godot;
using Utils;

public partial class Poursuite : Node2D
{
    [Export]
    public Node2D Cible;

    [Export]
    private Node2D Poursuivant;

    // Peut aller de 0 à 1000 à coup de 1. unités: pixel per seconds
    [Export(PropertyHint.Range, "-1000,1000,10,suffix:pps")]
    private float Velocity = 100.0f;

    public override void _PhysicsProcess(double InDelta)
    {
        base._PhysicsProcess(InDelta);
        Poursuivant.EnsureValid();
        Cible.EnsureValid();

        //Manière longue de calculer la direction - important
        //direction et altDirection donnent le même résultat
        //Calcul dans l'espace global
        Vector2 distance = Cible.GlobalPosition - Poursuivant.GlobalPosition;
        Vector2 direction = distance.Normalized();

        //En pratique, utilise ceci.
        Vector2 altDirection = Poursuivant.GlobalPosition.DirectionTo(Cible.GlobalPosition);

        Vector2 deplacement = altDirection * Velocity * (float)InDelta;
        Poursuivant.GlobalPosition += deplacement;

        float scaleX =
            deplacement.X > 0.0f ? Math.Abs(Poursuivant.Scale.X) : -Math.Abs(Poursuivant.Scale.X);
        Vector2 newScale = new Vector2(scaleX, Poursuivant.Scale.Y);
        Poursuivant.Scale = newScale;
    }
}
