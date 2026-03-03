using System;
using Godot;

public partial class EditorDebugOnly : Node2D
{
    public override void _Ready()
    {
        Visible = Engine.IsEditorHint() || GetTree().IsDebuggingCollisionsHint();
    }
}
