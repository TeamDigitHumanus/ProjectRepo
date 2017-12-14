using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace Login
{
    public class Person
    {

        private string fName;
        private string lName;
        private char gender;

        public string FName { get; set; }
        public string LName { get; set; }
        public char Gender { get; set; }

    }

    public class Personal : Person
    {

        private string rolls;
        private string department;

        public string Rolls { get; set; }
        public string Department { get; set; }
    }

    public class Patient : Person
    {
        private string personNummer;
        private string adress;
        private string postNr;
        private string postOrt;
        private string telNr;
        private string eMail;

        public Patient(string pNr, string firstName, string surName, string adr, string pstNr, string ort, string tNr, string ePost, char gend)
        {
            PersonNummer = pNr;
            FName = firstName;
            LName = surName;
            Adress = adr;
            PostNr = pstNr;
            PostOrt = ort;
            TelNr = tNr;
            EMail = ePost;
            Gender = gend;
        }

        public Patient() { }

        public string PersonNummer { get; set; }
        public string Adress { get; set; }
        public string PostNr { get; set; }
        public string PostOrt { get; set; }
        public string TelNr { get; set; }
        public string EMail { get; set; }



    }


}



