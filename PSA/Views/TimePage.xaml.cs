using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PSA.Models.TempDB;
using PSA.Services.TempDB;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using PSA.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PSA.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimePage : Page, INotifyPropertyChanged
    {
        public TimePage()
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



        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            HttpClient client = new HttpClient();
            var JsonResponse = await client.GetStringAsync("http://localhost:62611/api/TimeEntries");
            var lotResult = JsonConvert.DeserializeObject<List<TimeEntry>>(JsonResponse);
            TimeEntryList.ItemsSource = lotResult;
        }

        
    }
}
