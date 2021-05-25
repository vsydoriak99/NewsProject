using GalaSoft.MvvmLight.Command;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using NewsProject.ClientWPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsProject.ClientWPF
{
    public class SimpleNewsViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<SimpleNews> ListNews { get; set; }
        private ICommand m_ButtonCommand;
        public ICommand LikeCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public SimpleNewsViewModel()
        {
            ListNews = new ObservableCollection<SimpleNews>();
            InitData();
        }

        private async void InitData()
        {
            var
                Query = @"{
                news{
                        id
                      title
                        dateOfPublication
                    likesCount
                     
                    }
                }";
            var graphQLResponse = await GraphQlClientService.ExecuteQueryAsyn<ObservableCollection<SimpleNews>>("news", Query);
            foreach (var gq in graphQLResponse)
            {
                ListNews.Add(gq);
            }

        }




        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
