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
            subDSelectedLot = (sender as ListView).SelectedIndex;


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

        private async void SubDInfoCity_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var element = sender as TextBox;


            var client = new HttpClient();

            subDivision.City = SubDInfoCity.Text;

             var lotJson = JsonConvert.SerializeObject(subDivision);

            var HttpContent = new StringContent(lotJson);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            await client.PutAsync("http://localhost:62611/api/SubDivisions/" + subDSelectedLot, HttpContent);
        }
    }
}
