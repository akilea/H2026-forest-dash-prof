using System;
using Godot;

public partial class EditorDebugOnly : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Est visible seulement dans l'éditeur OU quand on affiche les collisions dans le jeu.
        Visible = Engine.IsEditorHint() || GetTree().DebugCollisionsHint;
    }
}
