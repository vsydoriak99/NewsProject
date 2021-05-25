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

namespace NewsProject.ClientWPF.Views
{
    /// <summary>
    /// Interaction logic for SimpleNewsVilew.xaml
    /// </summary>
    public partial class SimpleNewsVilew : Page
    {
        private Window window;
        public SimpleNewsVilew(Window _window)
        {
            window = _window;
            InitializeComponent();
            DataContext = new SimpleNewsViewModel();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var list =(ListBox)e.Source;
            var selnews= (SimpleNews)list.SelectedItem;
            var page2 = new DetailNewsView(selnews.id , this, window);
            window.Content = page2;
           
        }
    }
}
