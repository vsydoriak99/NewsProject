using NewsProject.ClientWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace NewsProject.ClientWPF
{
    public class DetailNews : BaseModel, INotifyPropertyChanged
    {

        private string id { get; set; }
        private string url { get; set; }
        private string title { get; set; }
        private string author { get; set; }
        private List<string> keywords { get; set; }
        private string dateOfPublication { get; set; }
        private string description { get; set; }
        private List<string> likes { get; set; }
        private int likesCount { get; set; }

        [JsonPropertyName("id")]
        public string Id
        {

            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("id");
            }
        }

        [JsonPropertyName("url")]
        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                OnPropertyChanged("url");
            }
        }

        [JsonPropertyName("title")]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("title");
            }
        }

        [JsonPropertyName("author")]
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("author");
            }
        }

        [JsonPropertyName("keywords")]
        public List<string> Keywords
        {
            get { return keywords; }
            set
            {
                keywords = value;
                OnPropertyChanged("keywords");
            }
        }

        [JsonPropertyName("dateOfPublication")]
        public string DatePublication
        {
            get { return dateOfPublication; }
            set
            {
                dateOfPublication = value;
                OnPropertyChanged("dateOfPublication");
            }
        }

        [JsonPropertyName("description")]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("description");
            }
        }

        [JsonPropertyName("likes")]
        public List<string> Likes
        {
            get { return likes; }
            set
            {
                likes = value;
                OnPropertyChanged("likes");
            }
        }

        [JsonPropertyName("likesCount")]
        public int LikesCount
        {
            get { return likesCount; }
            set
            {
                likesCount = value;
                OnPropertyChanged("likesCount");
            }
        }

        [JsonIgnore]
        public bool UserLikesThis
        {
            get =>  likes!= null ? likes.Contains(Session.UserId) : false;
            set
            {
                if (value)
                {
                    if (!likes?.Contains(Session.UserId) ?? false)
                    {
                        likes.Add(Session.UserId);
                    }
                }
                else
                {
                    likes?.Remove(Session.UserId);
                }

                OnPropertyChanged("userLikesThis");
            }
        }

        [JsonIgnore]
        public string KeywordStr
        {
            get => Keywords !=null ? String.Join(", ", Keywords.ToArray()) : ""; 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
