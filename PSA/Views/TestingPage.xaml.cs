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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PSA.Views
{
    public sealed partial class TestingPage : Page
    {
        private const string ConnectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=PSA;Integrated Security=True;Pooling=False;UserID=CLEIT;Password=ApplestoApples1;";

        public TestingPage()
        {
            this.InitializeComponent();
        }

        private void sqlClick(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {


                try
                {
                    sqlConn.Open();
                    label1.Text = sqlConn.State.ToString();
                    sqlConn.Close();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception = " + ex.Message);
                }




//
            }
        }
    }
}
