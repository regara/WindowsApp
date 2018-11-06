using System.ComponentModel;

namespace PSA.Models
{
    public class ModelTesting : INotifyPropertyChanged
    {
        public string City;
        public string State;
        public int Zip;
        public string CrossSt;
        public int Zone;
        public string Division;
        public string StartDate;
        public string ComDate;
        public string SalesRep;
        public string Registry;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
