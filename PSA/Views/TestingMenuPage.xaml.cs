using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PSA.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestingMenuPage : Page
    {
        public TestingMenuPage()
        {
            this.InitializeComponent();
        }

        private void NavigateToSubDivision(object sender, TappedRoutedEventArgs e)
        {
            Grid grid = sender as Grid;
            string Path = grid.Children.OfType<StackPanel>().FirstOrDefault()
                .Children.OfType<StackPanel>().FirstOrDefault()
                .Children.OfType<TextBlock>().FirstOrDefault().Text;

            Type Page = null;

            switch (Path)
            {
                case "Sub Division":
                    Page = typeof(TestingPage);
                    break;
                case "Add a Customer":
                    Path = null;
                    break;
                case "View Schedule":
                    Path = null;
                    break;
                case "Reports":
                    Path = null;
                    break;
                case "Invoicing":
                    Path = null;
                    break;
                case "Scheduling":
                    Path = null;
                    break;
                case "Add / Remove a Tester":
                    Path = null;
                    break;
                case "Edit User":
                    Path = null;
                    break;
                case "User Changes":
                    Path = null;
                    break;
                default:
                    Path = null;
                    break;
            }

            if (Path != null)
                this.Frame.Navigate(Page);
        }
    }
}
