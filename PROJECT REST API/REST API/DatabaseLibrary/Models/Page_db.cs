using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLibrary.Models
{
    public class Page_db
    {
        #region Constructors
        public Page_db()
        {
        }

        public Page_db(int id, string topic, string content, string author)
        {
            Id = id;
            Topic = topic;
            Content = content;
            Author = author;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string Topic { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        #endregion
    }
}