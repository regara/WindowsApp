using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PSA.Models.TempDB;

namespace PSA.Services.TempDB
{
    public class MainJobMenuNotesDataService
    {

        public static ObservableCollection<Note> AllNotes { get; set; } = new ObservableCollection<Note>
        {
            new Note
            {
                Date = DateTime.Now.ToString("g"),
                Text = "This is the first note!"
            },

            new Note
            {
                Date = "10/06/2018 7:00 AM",
                Text = "This is the Second note!"
            },

            new Note
            {
                Date = "10/02/2018 11:00 PM",
                Text = "Loren ipsum filler text."
            },

            new Note
            {
                Date = "09/16/2018 2:00 PM",
                Text = "2X4 R-13 2X6 R-19 Attic R49 Floor Over Garage Metal Roof Most glass in front"
            }
        };

       

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
