using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using PSA.Models.TempDB;
using PSA.Services.TempDB;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Microsoft.Toolkit.Uwp.UI.Extensions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PSA.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainJobMenuPage : Page, INotifyPropertyChanged
    {
        public MainJobMenuPage()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<Note> Notes
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return MainJobMenuNotesDataService.AllNotes;
            }
        }

        public ObservableCollection<BuilderInfo> CurrentBuilder
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return MainJobMenuNotesDataService.CurrentBuilderSampleData();
            }
        }

        public ObservableCollection<BuilderInfoContact> CurrentBuilderContact
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return MainJobMenuNotesDataService.CurrentBuilderContactSampleData();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        // DRY Methods
        private void AddNote()
        {
            MainJobMenuNotesDataService.AllNotes.Add(new Note()
            {
                Date = DateTime.Now.ToString("g"),
                Text = NoteToAdd.Text
            });
            AddNoteFlyout.Hide();
        }


        // Events
        private void Input_OnkeyDown_NumericOnly(object sender, KeyRoutedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.Key.ToString(), "[0-9]"))
                e.Handled = false;
            else e.Handled = true;
        }

        private void AddNoteCancled(object sender, RoutedEventArgs e)
        {
            AddNoteFlyout.Hide();
        }

        private void AddNoteSaved(object sender, RoutedEventArgs e)
        {
            AddNote();
        }

        private void NoteInput_EnterPressed(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.ToString() == "Enter")
            {
                AddNote();
            }
        }

        private void NoteRow_RightClicked(object sender, RightTappedRoutedEventArgs e)
        {
            var test1 = (DataGrid)sender;
            var test2 = sender as Grid;

            Console.WriteLine(e);
        }
    }
}
