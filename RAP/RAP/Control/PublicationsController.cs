using System;
using System.Collections.Generic;
using RAP.Research;
using RAP.Database;
using System.Linq;

namespace RAP.Control
{
    class PublicationsController
    {
        public static List<Publication> Publication { get; set; }//a list stored all publications of selected researcher
        public static Publication CurrentPublication { get; set; }//current selected publication
        public static List<String> PublicationYears = new List<String>();//a list stored years from the year of the earliest publication to current year

        public static List<Publication> LoadPublicationsFor(Researcher researcher)
        {
            
            Publication = ERDAdapter.fetchBasicPublicationDetails(researcher);
            LoadPublicationYears(researcher);
            
            
            return Publication;
        }

        public static void LoadCurrentPublicationDetails(object selected)
        {
            CurrentPublication = ERDAdapter.completePublicationDetails((Publication)selected);
        }

        public static void LoadPublicationYears(Researcher researcher)
        {
            PublicationYears.Clear();

            int earliestStart = researcher.EarliestStart.Year;
            int curYear = DateTime.Today.Year;

            PublicationYears.Insert(0, "");

            for (int i = earliestStart; i <= curYear; i++)
            {
                PublicationYears.Add(i.ToString());
            }
        }

        //return publications of current researcher in a sepecific period of years
        public static List<Publication> FilterBy(int yearfrom, int yearto)
        {
            var query = from entry in Publication
                        where entry.PublicationYear >= yearfrom &&
                              entry.PublicationYear <= yearto
                        select entry;

            return query.ToList();
        }

        //return a list described the count of current selected researcher's publications by year 
        public static List<Tuple<int, int>> CumulativeCount()
        {
            List<Tuple<int, int>> results = new List<Tuple<int, int>>();
            Researcher researcher = ResearcherController.CurrentResearcher;

            if (researcher != null)
            {
                int start = researcher.EarliestStart.Year;
                int current = DateTime.Today.Year;

                for (int year = start; year <= current; year++)
                {

                    var filterQuery =
                        from entry in PublicationsController.Publication
                        where entry.PublicationYear == year
                        select entry;

                    results.Add(new Tuple<int, int>(year, filterQuery.Count()));
                }

                return results;
            }

            return null;
        }
    }
}
