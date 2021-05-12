using System;
using System.Collections.Generic;
using System.Text;

namespace MartinPulgar.Models
{
    public class DataModel
    {
        public List<string> Images { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public string Area { get; set; }
        public string Category {get; set;}
        public string Tags { get; set; }
        public string Event { get; set; }
    }
}
