using System;
using Godot;

public partial class DCM_PlayerSwitch : Node
{
    private Chat activePlayer;

    [Export]
    private Color HighlightColor = Colors.SkyBlue;

    public override void _Ready()
    {
        bool isFirstOne = true;
        foreach (Node2D n in GetChildren())
        {
            if (n is not Chat sp)
            {
                continue;
            }
            SetPlayerActive(sp, isFirstOne);
            isFirstOne = false;
        }
    }

    public override void _Process(double delta)
    {
        if (!Input.IsActionJustPressed("ui_accept"))
        {
            return;
        }
        ChooseNextActivePlayer();
    }

    private void ChooseNextActivePlayer()
    {
        //On a  des enfants?
        if (GetChildCount() <= 0)
        {
            return;
        }

        //Joueur actif est valide?
        if (!IsInstanceValid(activePlayer))
        {
            foreach (Node2D n in GetChildren())
            {
                if (n is Chat sp)
                {
                    activePlayer = sp;
                    break;
                }
            }
        }
        SetPlayerActive(activePlayer, false);

        //Index du joueur courrant
        int index = GetChildren().IndexOf(activePlayer);
        if (index == -1)
        {
            return;
        }
        index = (index + 1) % GetChildCount();
        Chat nextSp = GetChildOrNull<Chat>(index);
        if (nextSp is null)
        {
            return;
        }
        activePlayer = nextSp;
        SetPlayerActive(activePlayer, true);
    }

    private void SetPlayerActive(Chat InSP, bool InIsActive)
    {
        InSP.Modulate = InIsActive ? HighlightColor : Colors.White;
        InSP.IsActive = InIsActive;
    }
}
