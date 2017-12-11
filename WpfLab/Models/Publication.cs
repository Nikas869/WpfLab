using System;

namespace WpfLab.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISSN { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public virtual Publishing Publishing { get; set; }
    }
}
