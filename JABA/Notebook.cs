using System;
using System.Collections.Generic;
using System.Text;

namespace Laba
{
    public class Notebook
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public string OtherNotes { get; set; }
        public static List<Notebook> notes = new List<Notebook>();
        public static int conatactsCounter;

        public Notebook(string name, string secondName, string phoneNumber, string country)
        {
            Name = name;
            SecondName = secondName;
            PhoneNumber = phoneNumber;
            Country = country;
        }
    }
}
