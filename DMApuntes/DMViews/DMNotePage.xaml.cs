namespace DMApuntes.DMViews
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class DMNotePage : ContentPage
    {
        public string ItemId
        {
            set { LoadNote(value); }
        }

        public DMNotePage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is DMModels.DMNote note)
                File.WriteAllText(note.Filename, TextEditor.Text);

            await Shell.Current.GoToAsync("..");
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is DMModels.DMNote note)
            {
                // Delete the file.
                if (File.Exists(note.Filename))
                    File.Delete(note.Filename);
            }

            await Shell.Current.GoToAsync("..");
        }

        private void LoadNote(string fileName)
        {
            DMModels.DMNote noteModel = new DMModels.DMNote
            {
                Filename = fileName
            };

            if (File.Exists(fileName))
            {
                noteModel.Date = File.GetCreationTime(fileName);
                noteModel.Text = File.ReadAllText(fileName);
            }

            BindingContext = noteModel;
        }
    }
}
