using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using Godot.Collections;
using Utils;

public class ChildManipulator
{
    public static IEnumerable<Node2D> GatherChildren(
        PackedScene InPackedSceneAFiltrer,
        Node2D InDCMQuiFiltre
    )
    {
        InPackedSceneAFiltrer.EnsureValid();
        InDCMQuiFiltre.EnsureValid();

        SceneState state = InPackedSceneAFiltrer.GetState();
        //index = 0 = noeud racine de la scène
        StringName nodeType = state.GetNodeType(0);
        Array<Node> ret = InDCMQuiFiltre.FindChildren("*", nodeType, false, false);
        return ret.OfType<Node2D>();
    }
}
