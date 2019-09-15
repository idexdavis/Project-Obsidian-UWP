﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Project_Obsidian_UWP.Models
{
    public class Post
    {
        public Category category { get; set; }
        public DateTime createDate { get; set; }
        public DateTime publishDate { get; set; }
        public string fileName { get; set; }
        public string displayName { get; set; }
        public string fileExt { get; set; }
        public string fullFileName
        {
            get { return $"{ publishDate }-{ fileName }{ fileExt }"; }
        }
        public string title { get; set; }
        public string description { get; set; }
        public string filePath { get; set; }
        public string content { get; set; }

        public Post(string fileName, string fileExt,
                    string title, string publishDate,
                    string description, string filePath,
                    Category category,
                    string content = "")
        {

        }
    }

    public class PostsManager
    {
        private ObservableCollection<Post> _posts = new ObservableCollection<Post>();

        public void AddPost(Post post)
        {
            _posts.Add(post);
        }

        public void AddPosts(List<Post> posts)
        {
            foreach (Post post in posts)
            {
                _posts.Add(post);
            }
        }

        public ObservableCollection<Post> GetPosts()
        {
            return _posts;
        }

        public void MovePost(int oldIndex, int newIndex)
        {
            _posts.Move(oldIndex, newIndex);
        }
    }
}
