using Godot;

public partial class MainMenu : Control
{

    [Export(PropertyHint.File, "*.tscn")]
    public string GameOverScenePath;
    // By doing this, you can just drag the button from the scene tree 
    // into this slot in the Inspector. No more typing strings!
    [Export] public Button PlayButton;

    public override void _Ready()
    {
        if (PlayButton != null)
        {
            GD.Print("The button type is: " + PlayButton.GetType().Name);
            PlayButton.Pressed += StartGame;
        }
        else
        {
            GD.Print("PlayButton is null!");
        }
    }

    private void StartGame()
    {
        GetTree().ChangeSceneToFile(GameOverScenePath);
    }
}