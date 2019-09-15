using Project_Obsidian_UWP.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static Project_Obsidian_UWP.Utilities.Enumerations;

namespace Project_Obsidian_UWP.Models
{
    public class Post
    {
        public Category category { get; set; }
        public DateTime createDate { get; set; }
        public DateTime publishDate { get; set; }
        public PostLayout layout { get { return PostLayout.Post;  } }
        public string fileName { get; set; }
        public string fileExt { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string filePath { get; set; }
        public string content { get; set; }
        public string displayName
        {
            get
            {
                return $"{ publishDate.ToString(Constants.dateFormat) }-{ fileName }";
            }
            set
            {
                try
                {
                    publishDate = DateTime.ParseExact(value.Substring(0, 10), Constants.dateFormat, null);
                    fileName = value.Substring(11);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fail to parse post publish date. Detail: { ex.Message }");
                }
            }
        }
        public string fullFileName
        {
            get { return $"{ displayName }{ fileExt }"; }
        }

        public Post(string fileName, string fileExt,
                    string title,
                    string description, string filePath,
                    Category category,
                    string content = "")
        {
            this.displayName = fileName; this.fileExt = fileExt;
            this.title = title;
            this.description = description;
            this.filePath = filePath;
            this.category = category;
            this.content = content;
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
