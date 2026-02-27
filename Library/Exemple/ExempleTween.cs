using Godot;

public partial class ExempleTween : Node2D
{
    [Export]
    private Node2D node;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Créer un tween (in-between, ou entre-deux)
        //Une ligne du temps sur laquelle tu vas créer des effets spéciaux
        Tween tw = CreateTween();

        //Effet: Tweener
        //Déplace le noeud À la position X = 500.0
        //tw.TweenProperty(node, "position:x", 500.0f, 3.0);

        //Déplace le noeud DE X = 500.0
        tw.TweenProperty(node, "position:x", node.Position.X + 500.0f, 2.0);

        //Attendre
        tw.TweenInterval(0.5);

        //Tween le vecteur de scale
        tw.TweenProperty(node, "scale", node.Scale + new Vector2(10.0f, 10.0f), 1.0);

        tw.TweenInterval(0.5);

        //Tween en parallèle
        //Attention, la valeur de node.Scale est celle initiale ici, on l'évite donc.
        tw.TweenProperty(node, "scale", node.Scale, 1.0);
        tw.Parallel();
        //Un tour sur soi-même
        tw.TweenProperty(node, "rotation", node.Rotation + 2.0f * Mathf.Pi, 1.0);
        //Ajout de nouveaux tween en parallèle possible ici
        tw.SetParallel(false); // Quand tu veux revenir séquentiel

        tw.TweenProperty(node, "position:y", node.Position.Y + 100.0f, 1.0);
        tw.TweenCallback(Callable.From(OnEndTween));
    }

    private void OnEndTween()
    {
        GD.Print("C'est la fin!");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }
}
