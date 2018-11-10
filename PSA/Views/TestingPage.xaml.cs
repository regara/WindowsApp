using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Data.SqlClient;
using System.Diagnostics;
using PSA.Models;
using Newtonsoft.Json;
using System.Net.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PSA.Views
{
    public sealed partial class TestingPage : Page
    {
        private List<SubDivision> TestingLotJson = new List<SubDivision>();

        public TestingPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            HttpClient client = new HttpClient();
            var JsonResponse = await client.GetStringAsync("http://localhost:62611/api/SubDivisions");
            var lotResult = JsonConvert.DeserializeObject<List<SubDivision>>(JsonResponse);

            TestingLotJson = lotResult;




            // Test Lot List Side Bar Selector
            List<string> formattedSubDivArray = new List<string>();

            foreach (var subDivision in lotResult)
            {
                formattedSubDivArray.Add(subDivision.Id + " " + subDivision.Name + " @ " + subDivision.City + subDivision.BuilderName);
            }

            TestingLotList.ItemsSource = formattedSubDivArray;

        }

        private void TestingLotList_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            int selectedLot = (sender as ListView).SelectedIndex;


            SubDInfoCity.Text = TestingLotJson[selectedLot].City;
            SubDInfoState.Text = TestingLotJson[selectedLot].State;
            SubDInfoZip.Text = TestingLotJson[selectedLot].Zip.ToString();
            SubDInfoCrossSt.Text = TestingLotJson[selectedLot].CrossSt;
            SubDInfoClimateZone.Text = TestingLotJson[selectedLot].ClimateZone.ToString();
            SubDInfoDivision.Text = TestingLotJson[selectedLot].Division;
            SubDInfoStartDate.Text = TestingLotJson[selectedLot].StartDate;
//            SubDInfoCompDate.Text = TestingLotJson[selectedLot].CompDate;
            SubDInfoCompDate.Text = "";
            SubDInfoSalesRep.Text = TestingLotJson[selectedLot].SalesRep;
            SubDInfoRegistry.Text = TestingLotJson[selectedLot].Registry;

        }
    }
}
