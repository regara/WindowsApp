using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PSA.Models.TempDB;

namespace PSA.Services.TempDB
{
    public class MainJobMenuNotesDataService
    {
        private static IEnumerable<Note> AllNotes()
        {
            var data = new ObservableCollection<Note>
            {
                new Note
                {
                    Date = DateTime.Today,
                    Text = "This is the first note!"
                },

                new Note
                {
                    Date = new DateTime(2018, 6, 10),
                    Text = "This is the Second note!"
                },

                new Note
                {
                    Date = new DateTime(2017, 3, 24),
                    Text = "Loren ipsum filler text."
                },

                new Note
                {
                    Date = new DateTime(2018, 7, 5),
                    Text = "2X4 R-13 2X6 R-19 Attic R49 Floor Over Garage Metal Roof Most glass in front"
                }
            };

            return data;
        }

//        new List<BuilderInfoContact>()
//        {
//            new BuilderInfoContact
//            {
//                Cellphone = "(209) 453-2121",
//                Contact = "Tom Hardy",
//                Email = "TomHardy64@gmail.com",
//                Fax = "( ) -",
//                Phone = "(480) 658-1122"
//            }
//        },
//
//        new BuilderInfo
//        {
//            Address = "Ad",
//            City = "",
//            State = "",
//            Zipcode = "",
//            SalesRep = "",
//            Division = "",
//            License = "",
//            Bond = "",
//            Vellum = true,
//            CustomerType = "",
//            GeoArea = "",
//            BuilderCriteria = ""
//        },
        // TODO WTS: Remove this once your grid page is displaying real data
        public static ObservableCollection<Note> GetNotesSampleData()
        {
            return new ObservableCollection<Note>(AllNotes());
        }

        public static ObservableCollection<Note> AddNote(string note)
        {
            var NotesList = new ObservableCollection<Note>(AllNotes());

            NotesList.Add(new Note
            {
                Date = DateTime.Today,
                Text = note
            });

            return NotesList;
        }

        // TODO WTS: Remove this once your MasterDetail pages are displaying real data
        public static async Task<IEnumerable<Note>> GetSampleModelDataAsync()
        {
            await Task.CompletedTask;
            
            return AllNotes();
        }

    }
}
