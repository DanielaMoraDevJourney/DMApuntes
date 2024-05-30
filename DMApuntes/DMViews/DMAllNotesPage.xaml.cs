namespace DMApuntes.DMViews;

public partial class DMAllNotesPage : ContentPage
{
	public DMAllNotesPage()
	{
		InitializeComponent();
        BindingContext = new DMModels.DMAllNotes();
    }
    protected override void OnAppearing()
    {
        ((DMModels.DMAllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(DMNotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (DMModels.DMNote)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(DMNotePage)}?{nameof(DMNotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}