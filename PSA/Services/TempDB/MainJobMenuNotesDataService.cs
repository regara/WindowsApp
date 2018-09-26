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




        private static IEnumerable<BuilderInfo> CurrentBuilder()
        {
            var data = new ObservableCollection<BuilderInfo>
            {
                new BuilderInfo
                {
                    Address = "5050 Amadillo Way",
                    City = "City",
                    State = "State",
                    Zipcode = "Zip",
                    SalesRep = "Rep",
                    Division = "Div",
                    License = "License",
                    Bond = "Bond",
                    Vellum = true,
                    CustomerType = "Cust",
                    GeoArea = "Geo",
                    BuilderCriteria = "BuildCriteria"
                },

                new BuilderInfo
                {
                    Address = "3737 Dragon Court",
                    City = "City",
                    State = "State",
                    Zipcode = "Zip",
                    SalesRep = "Rep",
                    Division = "Div",
                    License = "License",
                    Bond = "Bond",
                    Vellum = true,
                    CustomerType = "Cust",
                    GeoArea = "Geo",
                    BuilderCriteria = "BuildCriteria"
                },

                new BuilderInfo
                {
                    Address = "924 Knights Veil",
                    City = "City",
                    State = "State",
                    Zipcode = "Zip",
                    SalesRep = "Rep",
                    Division = "Div",
                    License = "License",
                    Bond = "Bond",
                    Vellum = true,
                    CustomerType = "Cust",
                    GeoArea = "Geo",
                    BuilderCriteria = "BuildCriteria"
                }
            };

            return data;
        }



        private static IEnumerable<BuilderInfoContact> CurrentBuilderContact()
        {
            var data = new ObservableCollection<BuilderInfoContact>
            {
                new BuilderInfoContact
                {
                    Contact = "James",
                    Phone = "480-558-1245",
                    Fax = "-",
                    Email = "Jamesr55@gmail.com",
                    Cellphone = "480-558-1245"
                },

                new BuilderInfoContact
                {
                    Contact = "Morgana",
                    Phone = "480-558-1245",
                    Fax = "-",
                    Email = "Jamesr55@gmail.com",
                    Cellphone = "480-558-1245"
                },

                new BuilderInfoContact
                {
                    Contact = "Shivana",
                    Phone = "480-558-1245",
                    Fax = "-",
                    Email = "Jamesr55@gmail.com",
                    Cellphone = "480-558-1245"
                },

                new BuilderInfoContact
                {
                    Contact = "Olaf",
                    Phone = "480-558-1245",
                    Fax = "-",
                    Email = "Jamesr55@gmail.com",
                    Cellphone = "480-558-1245"
                }
            };

            return data;
        }




















        // accesses private setters
        public static ObservableCollection<Note> GetNotesSampleData()
        {
            return new ObservableCollection<Note>(AllNotes());
        }

        public static ObservableCollection<BuilderInfo> CurrentBuilderSampleData()
        {
            return new ObservableCollection<BuilderInfo>(CurrentBuilder());
        }

        public static ObservableCollection<BuilderInfoContact> CurrentBuilderContactSampleData()
        {
            return new ObservableCollection<BuilderInfoContact>(CurrentBuilderContact());
        }




        //        Updates Note
        //        public static ObservableCollection<Note> AddNote(string note)
        //        {
        //            var NotesList = new ObservableCollection<Note>(AllNotes());
        //
        //            NotesList.Add(new Note
        //            {
        //                Date = DateTime.Today,
        //                Text = note
        //            });
        //
        //            return NotesList;
        //        }

    }
}
