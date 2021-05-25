using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using NewsProject.ClientWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewsProject.ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Session.UserId = "603e9caf2301ae5293e780e2";
            InitializeComponent();
            Content = new SimpleNewsVilew(this);
        }


  
    }
}
