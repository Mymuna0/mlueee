using Godot;

public partial class WinScreen : Control
{

    [Export(PropertyHint.File, "*.tscn")] 
    public string GameOverScenePath;

	[Export] public Button ReturnButton;

    public override void _Ready()
    {
        ReturnButton.Pressed += ReturnToMenu;
    }


    private void ReturnToMenu()
    {
        GetTree().ChangeSceneToFile(GameOverScenePath);
    }
}