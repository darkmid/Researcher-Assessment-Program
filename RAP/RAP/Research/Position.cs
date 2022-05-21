using System;
using System.ComponentModel;


namespace RAP.Research
{
    //different level for staff
    public enum EmploymentLevel
    {
        [Description("All Categories")] Unspecified, Student,
        [Description("Post-Doctoral")] A,
        [Description("Lecturer")] B,
        [Description("Senior Lecturer")] C,
        [Description("Associate Professor")] D
    }

    class Position
    {
        public EmploymentLevel Level { get; set; }//Position's level
        public DateTime Start { get; set; }//Position's start
        public DateTime End { get; set; }//Position's End

        public string Title { get; set; }//The title of position
    }
}
