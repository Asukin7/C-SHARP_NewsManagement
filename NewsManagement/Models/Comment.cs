using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsManagement.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int newsId { get; set; }
        public int status { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }

        public string newsTitle { get; set; }
        public string userNickname { get; set; }
    }
}