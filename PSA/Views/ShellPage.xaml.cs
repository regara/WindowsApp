﻿using System;
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


            // Conditional Navigation Display
            foreach (var stackPanel in NavContainer.FindChildren<StackPanel>())
            {
                stackPanel.Visibility = Visibility.Collapsed;
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

                case "TestingMenuPage":
                    NavTesting.Visibility = Visibility.Visible;
                    break;

                default:
                    Console.WriteLine("Default case");
                    break;
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

        private void CloseApplication_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void Login_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            Console.WriteLine();
        }
    }
}
