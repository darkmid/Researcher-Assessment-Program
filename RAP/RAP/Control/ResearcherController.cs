using RAP.Research;
using System;
using System.Collections.Generic;
using RAP.Database;
using System.Linq;
using System.Windows;
using RAP.View;

namespace RAP.Control
{
    class ResearcherController
    {
        public static List<Researcher> Researchers { get;  set; }//List contains all researchers
        public static Researcher CurrentResearcher { get;  set; }//Current selected researcher
        public static List<Researcher> Supervisions = new List<Researcher>();//List stored students who are supervised by current selected researcher
        public static List<String> Report = new List<String>() { "Poor", "Below Exp.", "Minimum", "Star" };//String list contain all levels of performance for generating report


        //get basic details of researchers, such as: family name, given name, email etc.
        public static List<Researcher> LoadResearchers()
        {
            Researchers = ERDAdapter.fetchBasicReseacrherDetails();
            return Researchers;
        }

        //define methods which allow users to complete filter search
        // 1. search by level
        public static List<Researcher> FilterBy(object type)
        {
            List<Researcher> researchers = Researchers;
            EmploymentLevel level = type.ToString().ToEnum<EmploymentLevel>();

            if (level != EmploymentLevel.Unspecified)
            {
                var query1 = from entry in Researchers
                            where entry.currentJob == level
                            select entry; 

                researchers = query1.ToList();
            }
            return researchers;
        }

        // 2. search by name, users type in search box
        public static List<Researcher> FilterByName(string name)
        {
            List<Researcher> researchers = Researchers;
            name = name.ToUpper(); //all letters convert to upper case, ignore case issue

            if(name != "")
            {
                var query = from entry in researchers
                            where (entry.GivenName.ToUpper().Contains(name) || entry.FamilyName.ToUpper().Contains(name))
                            select entry;
                researchers = query.ToList();
            }

            return researchers;
        }

        //show details results of researchers
        public static void LoadResearcherDetails(object selected)
        {
            if (selected != null)
            {
                CurrentResearcher = ERDAdapter.fetchFullResearcherDetails((Researcher)selected);
                FetchTheJob();
                FetchThreeYearAverage();
                CountPerformance();
                FetchSupervisions();
            }
        }

        //fill the current job title and expected publication score for current selected researcher
        public static void FetchTheJob()
        {
            if (CurrentResearcher != null)
            {
                string level = CurrentResearcher.currentJob.ToString();

                switch (level)
                {
                    case "Student":
                        CurrentResearcher.CurrentJobTitle = "Student";
                        break;

                    case "A":
                        CurrentResearcher.CurrentJobTitle = "Postdoc";
                        CurrentResearcher.ExpectedPublications = 0.5;
                        break;

                    case "B":
                        CurrentResearcher.CurrentJobTitle = "Lecturer";
                        CurrentResearcher.ExpectedPublications = 1;
                        break;

                    case "C":
                        CurrentResearcher.CurrentJobTitle = "Senior Lecturer";
                        CurrentResearcher.ExpectedPublications = 2;
                        break;

                    case "D":
                        CurrentResearcher.CurrentJobTitle = "Associate Professor";
                        CurrentResearcher.ExpectedPublications = 3.2;
                        break;

                    case "E":
                        CurrentResearcher.CurrentJobTitle = "Professor";
                        CurrentResearcher.ExpectedPublications = 4;
                        break;
                }

            }
        }

        //fill the previous three year average of publications for current selected researcher
        public static void FetchThreeYearAverage()
        {
            if (PublicationsController.Publication != null)
            {
                var query = from i in PublicationsController.Publication
                            where i.PublicationYear >= (DateTime.Today.Year - 2) &&
                                  i.PublicationYear <= DateTime.Today.Year
                            select i;

                CurrentResearcher.ThreeYearAverage=Math.Round(query.ToList().Count()/3.0,2);
            }
        }

        //fill performance mark for current selected researcher
        public static void CountPerformance()
        {
            if (!CurrentResearcher.Type.Equals("Student"))
            {
                CurrentResearcher.Performance = (CurrentResearcher.ThreeYearAverage / CurrentResearcher.ExpectedPublications)*100;
            }
        }

        //fill the supersisees list for current selected staff
        public static void FetchSupervisions()
        {
            if (CurrentResearcher.Type.Equals("Staff"))
            {
                Supervisions.Clear();
                foreach (var entry in Researchers)
                {
                    if (entry.SupervisorID == CurrentResearcher.id.ToString())
                    {
                        Supervisions.Add(entry);
                    }
                }

            }
        }

        //method for generating the list of researchers based on selected report level
        public static List<Tuple<double, string,int>> FetchReportReseachers(string level)
        {
            List<Tuple<double, string,int>> ReportResearchers = new List<Tuple<double, string,int>>();

            foreach(var entry in Researchers)
            {
                PublicationsController.Publication = ERDAdapter.fetchBasicPublicationDetails(entry);
                CurrentResearcher = ERDAdapter.fetchFullResearcherDetails((Researcher)entry);
                
                if (entry.Type.Equals("Staff"))
                {
                    FetchTheJob();
                    FetchThreeYearAverage();
                    CountPerformance();
                    
                    if (level != null)
                    {
                        switch (level)
                        {
                            case "Poor":
                                if (CurrentResearcher.Performance <= 70)
                                {
                                    
                                    ReportResearchers.Add(new Tuple<double, string,int>(CurrentResearcher.Performance,string.Format("{0} {1} {2}",entry.Title,entry.GivenName,entry.FamilyName), entry.id));
                                }
                                break;

                            case "Below Exp.":
                                if (CurrentResearcher.Performance > 70 && entry.Performance < 110)
                                {
                                    ReportResearchers.Add(new Tuple<double, string,int>(CurrentResearcher.Performance, string.Format("{0} {1} {2}", entry.Title, entry.GivenName, entry.FamilyName), entry.id));
                                }
                                break;

                            case "Minimum":
                                if (CurrentResearcher.Performance >= 110 && entry.Performance < 200)
                                {
                                    ReportResearchers.Add(new Tuple<double, string,int>(CurrentResearcher.Performance, string.Format("{0} {1} {2}", entry.Title, entry.GivenName, entry.FamilyName), entry.id));
                                }
                                break;

                            case "Star":
                                if (CurrentResearcher.Performance >= 200)
                                {
                                    ReportResearchers.Add(new Tuple<double, string,int>(CurrentResearcher.Performance, string.Format("{0} {1} {2}", entry.Title, entry.GivenName, entry.FamilyName), entry.id));
                                }
                                break;
                        }
                    }
                }
            }
            foreach(var i in ReportResearchers)
            {
                Console.WriteLine(i.Item1);
            }

            return ReportResearchers;
            
        }

        //method for copying the email of current selected researcher to clipboard
        public static void LoadEmails(object target)
        {
            Researcher targetedResearcher=new Researcher();
            targetedResearcher.id = ((Tuple<double, string, int>)target).Item3;

            targetedResearcher=ERDAdapter.fetchFullResearcherDetails(targetedResearcher);

            Clipboard.SetText(targetedResearcher.Email);
        }
    }
}
