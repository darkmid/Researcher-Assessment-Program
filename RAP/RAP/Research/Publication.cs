using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public enum OutputType { Conference, Journal, Other};

    class Publication
    {
        //fields for values from database
        public string Doi { get; set; }//Digital object identifier
        public string Title { get; set; }//Publication Title
        public string Authors { get; set; }//Publication Authors
        public int PublicationYear { get; set; }//Publication year
        public OutputType Type { get; set; }//Publication's output type
        public string CiteAs { get; set; }//Publication's Citation
        public DateTime Available { get; set; } //Date of availabilty
        public int Age { get { return DateTime.Today.Year - PublicationYear; } }//The age of the publication
    }
}
