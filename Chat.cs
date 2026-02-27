using System;
using Godot;
using Utils;

public partial class Chat : Sprite2D
{
    [ExportGroup("External")]
    [Export]
    public bool IsActive
    {
        get => SimplePlayer.EnsureValid().IsActive;
        set { SimplePlayer.EnsureValid().IsActive = value; }
    }

    [ExportGroup("Internal")]
    [Export]
    SimplePlayer SimplePlayer;
}
