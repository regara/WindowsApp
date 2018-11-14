using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel;
using PSA.Helpers;
using PSA.Services;

using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Extensions;
using Microsoft.Toolkit.Uwp.UI.Extensions;
using PSA.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Microsoft.Toolkit.Uwp.Helpers;

namespace PSA.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page, INotifyPropertyChanged
    {
        private NavigationViewItem _selected;

        public NavigationViewItem Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ShellPage()
        {
            InitializeComponent();
            HideNavViewBackButton();
            DataContext = this;
            Initialize();
        }

        private void Initialize()
        {
            NavigationService.Frame = shellFrame;
            NavigationService.Navigated += Frame_Navigated;
            KeyboardAccelerators.Add(ActivationService.AltLeftKeyboardAccelerator);
            KeyboardAccelerators.Add(ActivationService.BackKeyboardAccelerator);

            // Sets the Default Page View.
            shellFrame.Navigate(typeof(MainJobMenuPage));


            
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            Selected = navigationView.MenuItems
                            .OfType<NavigationViewItem>()
                            .FirstOrDefault(menuItem => IsMenuItemForPageType(menuItem, e.SourcePageType));


            // ******************* Conditional Navigation Display *******************

            try
            {
                foreach (var item in NavContainer.Children.OfType<StackPanel>())
                {
                    item.Visibility = Visibility.Collapsed;
                }

                switch (shellFrame.CurrentSourcePageType.Name)
                {
                    case "MainJobMenuPage":
                        NavHome.Visibility = Visibility.Visible;
                        break;

                    case "CustomersPage":
                        NavCustomers.Visibility = Visibility.Visible;
                        break;

                    case "TimePage":
                        NavTime.Visibility = Visibility.Visible;
                        break;

                    case "TestingPage":
                        NavTesting.Visibility = Visibility.Visible;
                        break;

                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
            catch (Exception ee)
            {

                Console.WriteLine(ee);
            }
        }

        private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType)
        {
            var pageType = menuItem.GetValue(NavHelper.NavigateToProperty) as Type;
            return pageType == sourcePageType;
        }

        private void OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = navigationView.MenuItems
                            .OfType<NavigationViewItem>()
                            .First(menuItem => (string)menuItem.Content == (string)args.InvokedItem);
            var pageType = item.GetValue(NavHelper.NavigateToProperty) as Type;
            NavigationService.Navigate(pageType);
        }

        private void HideNavViewBackButton()
        {
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 6))
            {
                navigationView.IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed;
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

        private void OnPageNavigation(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
             
        }

        private void Login_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            Console.WriteLine();
        }

        //        ******************* TIME ENTRY *******************

        private void AddNewTimeEntryPopout(object sender, RoutedEventArgs e)
        {
            AddTimeEntryPopup.IsOpen = true;
        }

        private void TimeEntryPopupClose(object sender, RoutedEventArgs e)
        {
            AddTimeEntryPopup.IsOpen = false;
        }

        private async void TimeEntrySaveEntry(object sender, RoutedEventArgs e)
        {

            try
            {
                var timeEntry = new TimeEntry()
                {
                    ProjId = Int32.Parse(TimeEProjID.Text),
                    Project = TimeEProject.Text,
                    Day = TimeEDay.Text,
                    Date = TimeEDate.Text,
                    ClassNum = Int32.Parse(TimeEClass.Text),
                    Hours = Int32.Parse(TimeEHours.Text),
                    Minutes = Int32.Parse(TimeEMinutes.Text),
                    OTHours = Int32.Parse(TimeEOTHours.Text),
                    OTMinutes = Int32.Parse(TimeEOTMinutes.Text),
                    VacationHours = Int32.Parse(TimeEVacHours.Text),
                    HolidayHours = Int32.Parse(TimeEHolMinutes.Text),
                    Notes = TimeENotes.Text
                };
                var lotJson = JsonConvert.SerializeObject(timeEntry);

                var client = new HttpClient();
                var HttpContent = new StringContent(lotJson);
                HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                await client.PostAsync("http://localhost:62611/api/TimeEntries", HttpContent);

                AddTimeEntryPopup.IsOpen = false;

                TimeEProjID.Text = "";
                TimeEProject.Text = "";
                TimeEDay.Text = "";
                TimeEDate.Text = "";
                TimeEClass.Text = "";
                TimeEHours.Text = "";
                TimeEMinutes.Text = "";
                TimeEOTHours.Text = "";
                TimeEOTMinutes.Text = "";
                TimeEVacHours.Text = "";
                TimeEHolMinutes.Text = "";
                TimeENotes.Text = "";
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            
        }

        //        Add New Sub Division

        private void AddNewSubDivPopup(object sender, RoutedEventArgs e)
        {
            AddSubDivisionPopup.IsOpen = true;
        }

        private void SubDivPopupClose(object sender, RoutedEventArgs e)
        {
            AddSubDivisionPopup.IsOpen = false;
        }

        private async void SubDivisionSaveEntry(object sender, RoutedEventArgs e)
        {

            try
            {
                var subDivisionEntry = new SubDivision()
                {
                    Name = SubDName.Text,
                    BuilderName = SubDBuilder.Text,
                    City = SubDCity.Text,
                    State = SubDState.Text,
                    StartDate = DateTime.Today.ToString("MM/dd/yyyy"),
                    Zip = Int32.Parse(SubDZip.Text),
                    BillableFrame = SubDBillable.IsOn,
                    CrossSt = SubDCrossSt.Text,
                    ClimateZone = Int32.Parse(SubDClimate.Text),
                    Division = SubDDivision.Text,
                    LotTotals = Int32.Parse(SubDLots.Text),
                    SalesRep = SubDSalesRep.Text,
                    UtilityProgram = SubDUtility.Text,
                    UtilityExpedition = SubDUtility2.Text,
                    Registry = SubDRegistry.Text
            };
                var lotJson = JsonConvert.SerializeObject(subDivisionEntry);

                var client = new HttpClient();
                var HttpContent = new StringContent(lotJson);
                HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                await client.PostAsync("http://localhost:62611/api/SubDivisions", HttpContent);

                AddSubDivisionPopup.IsOpen = false;

                SubDName.Text = "";
                SubDBuilder.Text = "";
                SubDCrossSt.Text = "";
                SubDCity.Text = "";
                SubDState.Text = "";
                SubDZip.Text = "";
                SubDClimate.Text = "";
                SubDDivision.Text = "";
                SubDLots.Text = "";
                SubDSalesRep.Text = "";
                SubDRegistry.Text = "";
                SubDUtility.Text = "";
                SubDUtility2.Text = "";
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        // Sub Div Plan
        private void AddNewSubDPlanPopup(object sender, RoutedEventArgs e)
        {
            AddSubDPlanPopup.IsOpen = true;
        }

        private void SubDPlanPopupClose(object sender, RoutedEventArgs e)
        {
            AddSubDPlanPopup.IsOpen = false;
        }


        // Sub Div Lot

        private void AddNewSubDLotPopup(object sender, RoutedEventArgs e)
        {
            AddSubDLotPopup.IsOpen = true;
        }

        private void SubDLotPopupClose(object sender, RoutedEventArgs e)
        {
            AddSubDLotPopup.IsOpen = false;
        }



        // ******************* CRUD Opperations *******************




        //
        //        private async void AddLotAdded(object sender, RoutedEventArgs e)
        //        {
        //            var lot = new Lot()
        //            {
        //                City = City.Text,
        //                State = State.Text,
        //                Zip = Int32.Parse(Zip.Text),
        //                Id = new Random().Next(999999999)
        //            };
        //            var lotJson = JsonConvert.SerializeObject(lot);
        //
        //            var client = new HttpClient();
        //            var HttpContent = new StringContent(lotJson);
        //            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //
        //            await client.PostAsync("http://localhost:53950/api/Lots", HttpContent);
        //
        //            Frame.GoBack();
        //        }

    }
}
