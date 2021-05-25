using NewsProject.ClientWPF.Views;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for DetailNewsView.xaml
    /// </summary>
    public partial class DetailNewsView : Page
    {
        private Window window;
        private SimpleNewsVilew _page1;
        public DetailNewsView(string newsId , SimpleNewsVilew simpleNews , Window _window)
        {
            window = _window;
            InitializeComponent();

            DataContext = new  DetailNewsViewModel(newsId);
            _page1 = simpleNews;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           window.Content = _page1;
        }
    }
}
