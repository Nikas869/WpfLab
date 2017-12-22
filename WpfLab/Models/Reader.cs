using System;

namespace WpfLab.Models
{
    public class Reader
    {
        internal Reader()
        {
        }

        public Reader(string name, string phone, DateTime birthday)
        {
            Name = name;
            Phone = phone;
            Birthday = birthday;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
    }
}
