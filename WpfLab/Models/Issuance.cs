using System;
using System.Collections.Generic;

namespace WpfLab.Models
{
    public class Issuance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Reader Reader { get; set; }
        public Publication Publication { get; set; }
        public int Quantity { get; set; }
    }
}
