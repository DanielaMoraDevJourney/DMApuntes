using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Provider.ContactsContract.CommonDataKinds;

namespace DMApuntes.DMModels
{
    internal class DMAllNotes
    {
        public ObservableCollection<DMNote> DMNotes { get; set; } = new ObservableCollection<DMNote>();

        public DMAllNotes() =>
            LoadNotes();

        public void LoadNotes()
        {
            DMNotes.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<DMNote> dmnotes = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.notes.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new DMNote()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetLastWriteTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(note => note.Date);

            // Add each note into the ObservableCollection
            foreach (DMNote dmnote in dmnotes)
                DMNotes.Add(dmnote);
        }

    }
}
