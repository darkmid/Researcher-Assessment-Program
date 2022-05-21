using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Database;
using RAP.View;
using System.ComponentModel;
using RAP.Control;

namespace RAP.Research
{
    //present different school location
    public enum Campus { Hobart, Launceston, [Description("Cradle Coast")] CradleCoast };

    class Researcher
    {
        //some basic main attributes for researchers
        public int id { get; set; }//Student ID
        public string Type { get; set; }//Researcher type (Student/Staff)
        public string Title { get; set; }//Title e.g. Mr, Mrs
        public string GivenName { get; set; }//First Name
        public string FamilyName { get; set; }//Last Name
        public EmploymentLevel currentJob { get; set; }//Fetch the level of researcher,eg. A,B,C
        public Campus Campus { get; set; }//Main campus of the researcher
        public string School { get; set; }//Faculty of the researcher
        public string Email { get; set; }//Researcher's email
        public string PhotoURL { get; set; }//the URl of researcher's photo
        public string CurrentJobTitle { get; set; }//Translate level to the exact job title, eg. B->Lecturer 

        //Attributes for student
        public string Supervisor { get; set; }//full name of supervisor
        public string SupervisorID { get; set; }//the supervisor's ID
        public string Degree { get; set; }//Current degree of the student

        //Attribute for staff
        public List<Position> Positions { get; set; }//list of staff's career
        public List<string> Supervises { get; set; }//list of students who are supervised 
        public double ExpectedPublications { get; set; }//Expected number based on level

        //methods
        public Position GetCurrentJob { get; set; }
        public Position GetEarliestJob { get; set; }
        public DateTime CurrentJobStart { get; set; }
        public DateTime EarliestStart { get; set; }
        public int PublicationsCount { get; set; }
        public double ThreeYearAverage { get; set; }
        public double Performance { get; set; }


        public double Tenure { get { return  Math.Round(DateTime.Today.Subtract(EarliestStart).TotalDays / 365.0, 2); } }//the number of years since the researcher started with the University

    }
}
