namespace DMApuntes.DMViews;

public partial class DMNotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public DMNotePage()
    {
        InitializeComponent();

        // Generate a random file name.
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        _fileName = Path.Combine(appDataPath, randomFileName);

        // Load the note with the generated file name.
        LoadNote(_fileName);
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        File.WriteAllText(_fileName, TextEditor.Text);
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (File.Exists(_fileName))
            File.Delete(_fileName);

        TextEditor.Text = string.Empty;
    }

    private void LoadNote(string fileName)
    {
        DMModels.DMNote noteModel = new DMModels.DMNote();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}