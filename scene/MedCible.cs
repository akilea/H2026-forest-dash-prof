using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Godot;
using Godot.Collections;
using Utils;

public partial class MedCible : Node2D
{
    [ExportGroup("External")]
    [Export]
    private DCM_Spawner SpawnerChat;

    [Export]
    private DCM_Spawner SpawnerSouris;

    [Export]
    private DCM_Spawner SpawnerChien;

    public enum EAlgoSelectionCible
    {
        eSouris = 0,
        eChat, //1
        eChien, //2
        eMAX,
    }

    public Node2D ChoisirCible(EAlgoSelectionCible InAlgoSelectionCible, Vector2 InPosition)
    {
        SpawnerSouris.EnsureValid();
        SpawnerChien.EnsureValid();
        Node2D retCible = null;

        switch (InAlgoSelectionCible)
        {
            case EAlgoSelectionCible.eSouris: { }
                break;
            case EAlgoSelectionCible.eChien:
                {
                    IEnumerable<Souris> list = SpawnerSouris.GatherChildren().OfType<Souris>();
                    retCible = list.FirstOrDefault<Souris>();

                    IEnumerable<Souris> list2 = SpawnerSouris.GatherChildren().OfType<Souris>();
                }
                break;
            default:
            case EAlgoSelectionCible.eChat:
                {
                    //Rien
                }
                break;
        }
        return retCible;
    }
}
