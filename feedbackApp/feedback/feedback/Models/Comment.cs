using System;
using SQLite;

namespace feedback.Models
{
    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Opinion { get; set; }

        public Comment()
        {

        }
    }
}
