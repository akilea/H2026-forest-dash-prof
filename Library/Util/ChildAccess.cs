using System.Collections.Generic;
using System.Linq;
using Godot;
using Utils;

class ChildAccess
{
    public static IEnumerable<Node2D> GatherChildren(
        PackedScene InPackedSceneType,
        Node2D InDCMToGatherFrom
    )
    {
        InPackedSceneType.EnsureValid();
        InDCMToGatherFrom.EnsureValid();
        var state = InPackedSceneType.GetState();
        // index 0 = root node dans de la scène
        StringName nodeType = state.GetNodeType(0);
        return InDCMToGatherFrom
            .FindChildren("*", nodeType, recursive: false, owned: false)
            .OfType<Node2D>();
    }
}
