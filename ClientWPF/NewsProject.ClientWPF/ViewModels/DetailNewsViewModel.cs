using GalaSoft.MvvmLight.Command;
using NewsProject.ClientWPF.Helpers;
using NewsProject.ClientWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NewsProject.ClientWPF
{
    public class DetailNewsViewModel : INotifyPropertyChanged
    {
        private DetailNews currentNews;

        public DetailNews CurrentNews
        {
            get { return currentNews; }
            set
            {
                currentNews = value;
                OnPropertyChanged("CurrentNews");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand likeCommand;

        public ICommand LikeCommand
        {
            get
            {
                return likeCommand;
            }
            set
            {
                likeCommand = value;
            }
        }

        private ICommand backCommand;

        public ICommand BackCommand
        {
            get
            {
                return backCommand;
            }
            set
            {
                backCommand = value;
            }
        }


        public DetailNewsViewModel(string newsId)
        {
            CurrentNews = new DetailNews();
            InitDetailsNews(newsId);
            LikeCommand = new RelayCommand(LikesComm);
            
        }


        private async void InitDetailsNews(string newsId)
        {
            var
                Query = "{  newsById(id : \"" + newsId + "\"" + @"){
                        id,
                         likes, 
                         likesCount,
                         url, 
                         title,
                         author, 
                            description, 
                        keywords

                     
                    }
                }";
            var graphQLResponse = await GraphQlClientService.ExecuteQueryAsyn<DetailNews>("newsById", Query);
            CurrentNews = graphQLResponse;
            AddReads();

        }

        private void LikesComm() {
            if (currentNews.UserLikesThis)
                RemoveLike();
            else
                AddLike();
        }

        private async void RemoveLike()
        {

            var Mutation = "mutation {removeLikes(newsID: \"" + CurrentNews.id + "\", userID: \"" + Session.UserId + "\"" + @"){
                    id,
                         likes, 
                         likesCount,
                         url, 
                         title,
                         author, 
                            description, 
                        keywords
                    }
                }";
            var graphQLResponse = await GraphQlClientService.ExecuteMutationAsyn<DetailNews>("removeLikes", Mutation);
            CurrentNews = graphQLResponse;

        }

        private async void AddLike()
        {

            var Mutation = "mutation {addLikes(newsID: \"" + CurrentNews.id + "\", userID: \"" + Session.UserId + "\"" + @"){
                    id,
                         likes, 
                         likesCount,
                         url, 
                         title,
                         author, 
                            description, 
                        keywords
                    }
                }";
            var graphQLResponse = await GraphQlClientService.ExecuteMutationAsyn<DetailNews>("addLikes", Mutation);
            CurrentNews = graphQLResponse;


        }

        private async void AddReads()
        {

            var Mutation = "mutation {readNews(newsID: \"" + CurrentNews.id + "\", userID: \"" + Session.UserId + "\"" + @"){
                    id
                    }
                }";
            var graphQLResponse = await GraphQlClientService.ExecuteMutationAsyn<BaseModel>("readNews", Mutation);


        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }






    }
}
