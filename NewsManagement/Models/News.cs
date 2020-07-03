using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsManagement.Models
{
    public class News
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int categoryId { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }

        public string categoryName { get; set; }
        public string userNickname { get; set; }
    }
}