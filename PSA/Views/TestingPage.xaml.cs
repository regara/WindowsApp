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
using Microsoft.Toolkit.Uwp.UI.Extensions;
using Telerik.UI.Xaml.Controls.Data.ListView.Commands;
using TextBlock = Windows.UI.Xaml.Controls.TextBlock;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PSA.Views
{
    public sealed partial class TestingPage : Page
    {
        private List<SubDivision> TestingLotJson = new List<SubDivision>();
        private SubDivision subDivision = new SubDivision();


        public int subSIndexToDelete { get; set; } = -1;
        public int subDSelectedLot { get; set; } = -1;
        public string subDListNameRightClicked { get; set; } = "";
        public static string TempSelectedID = "";

        public TestingPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
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
            catch (Exception dd)
            {

                Console.WriteLine(dd); ;
            }

                  

        }

        private async void TestingLotList_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            subDSelectedLot = (sender as ListView).SelectedIndex;

            TempSelectedID = (sender as ListView).SelectedItem.ToString().Split(" ")[0];

            // Star GET Requests
            HttpClient client = new HttpClient();

            // Plans
            var JsonResponsePlans = await client.GetStringAsync("http://localhost:62611/api/plans");
            var lotResultPlans = JsonConvert.DeserializeObject<List<PlanModel>>(JsonResponsePlans).Where(ee => ee.SubDivisionID.ToString() == TempSelectedID);

            // Lots
            var JsonResponseLot = await client.GetStringAsync("http://localhost:62611/api/Lots");
            var lotResultLot = JsonConvert.DeserializeObject<List<LotModel>>(JsonResponseLot).Where(ee => ee.SubDivisionID.ToString() == TempSelectedID);

            PlansList.ItemsSource = lotResultPlans;
            LotsList.ItemsSource = lotResultLot;
            // End GET Requests


            SubDInfoCity.Text = TestingLotJson[subDSelectedLot].City;
            SubDInfoState.Text = TestingLotJson[subDSelectedLot].State;
            SubDInfoZip.Text = TestingLotJson[subDSelectedLot].Zip.ToString();
            SubDInfoCrossSt.Text = TestingLotJson[subDSelectedLot].CrossSt;
            SubDInfoClimateZone.Text = TestingLotJson[subDSelectedLot].ClimateZone.ToString();
            SubDInfoDivision.Text = TestingLotJson[subDSelectedLot].Division;
            SubDInfoStartDate.Text = TestingLotJson[subDSelectedLot].StartDate;
            //            SubDInfoCompDate.Text = TestingLotJson[subDSelectedLot].CompDate;
            SubDInfoCompDate.Text = "";
            SubDInfoSalesRep.Text = TestingLotJson[subDSelectedLot].SalesRep;
            SubDInfoRegistry.Text = TestingLotJson[subDSelectedLot].Registry;


            NumOfLots.Text = LotsList.ItemsSource.OfType<object>().Count().ToString();

        }

        private void TestingLotList_OnRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ListView listView = (ListView)sender;
            subDListNameRightClicked = ((FrameworkElement)e.OriginalSource).DataContext.ToString();
            var b = TestingLotJson.FirstOrDefault(v => v.Id == int.Parse(subDListNameRightClicked.Split(' ')[0]));

            SubDInfoCity.Text = b.Id.ToString();
            subSIndexToDelete = b.Id;





            //            var tappedItem = (UIElement)e.OriginalSource;
            //            var attachedFlyout = (MenuFlyout)FlyoutBase.GetAttachedFlyout(MyListView);
            //
            //            attachedFlyout.ShowAt(tappedItem, e.GetPosition(tappedItem));


            MenuFlyout myFlyout = new MenuFlyout();
            MenuFlyoutItem deleteItem = new MenuFlyoutItem { Text = "Delete"};
            deleteItem.Click += MenuFlyoutHandler_Click;
            deleteItem.Tag = "Delete";
            myFlyout.Items.Add(deleteItem);

            FrameworkElement senderElement = sender as FrameworkElement;

            //the code can show the flyout in your mouse click 
            myFlyout.ShowAt(sender as UIElement, e.GetPosition(sender as UIElement));
            Console.WriteLine(myFlyout);
        }




        private async void MenuFlyoutHandler_Click(object sender, RoutedEventArgs e)
        {
                var client = new HttpClient();
                await client.DeleteAsync("http://localhost:62611/api/SubDivisions/" + subSIndexToDelete);
//                subDInformationColumn.
        }

        private void SubDInfoCity_OnTextChanged(object sender, TextChangedEventArgs e)
        {
//            var element = sender as TextBox;
//
//
//            var client = new HttpClient();
//
//            subDivision.City = SubDInfoCity.Text;
//
//             var lotJson = JsonConvert.SerializeObject(subDivision);
//
//            var HttpContent = new StringContent(lotJson);
//            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
//
//            await client.PutAsync("http://localhost:62611/api/SubDivisions/" + subDSelectedLot, HttpContent);
        }
    }
}
