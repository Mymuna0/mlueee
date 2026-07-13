using Godot;

public partial class EndLine : Area2D
{
    [Export(PropertyHint.File, "*.tscn")]
    public string GameOverScenePath;

    public override void _Ready()
    {
        // Connect the signal in code
        BodyEntered += OnBodyEntered;
    }

	private void OnBodyEntered(Node2D body)
	{
		
		if (body.IsInGroup("Player"))
		{
		    if (!string.IsNullOrEmpty(GameOverScenePath)){
				CallDeferred(MethodName.ChangeScene);
		    }
		    else{
		        GD.PrintErr("Error: GameOverScenePath is empty! Set it in the Inspector.");
		    }
		}
	}


	// This method handles the change safely after physics is done
    private void ChangeScene()
    {
        GetTree().ChangeSceneToFile(GameOverScenePath);
    }

}