using System;
using Godot;
using Utils;

public partial class Chat : Sprite2D, IEntity
{
    [ExportGroup("External")]
    [Export]
    public bool IsActive
    {
        get => SimplePlayer.EnsureValid().IsActive;
        set { SimplePlayer.EnsureValid().IsActive = value; }
    }

    public void SetCible(Node2D InCible) { }

    [ExportGroup("Internal")]
    [Export]
    SimplePlayer SimplePlayer;
}
