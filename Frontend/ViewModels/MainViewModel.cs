namespace Frontend.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    /// <summary>
    /// The main header text shown in the app.
    /// </summary>
    public string Greeting => "Welcome to HOMM Calculator!";

    /// <summary>
    /// The descriptive tagline under the header.
    /// </summary>
    public string Subtitle => "Plan your army, estimate costs, and track growth per week.";

    /// <summary>
    /// The version label displayed on the right side of the header.
    /// </summary>
    public string VersionTag => "v0.1 • Preview";
}
