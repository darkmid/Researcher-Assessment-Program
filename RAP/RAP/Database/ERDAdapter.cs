using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using RAP.Research;
using RAP.View;

namespace RAP.Database
{
    class ERDAdapter
    {
        //create connection to remote database
        private static MySqlConnection connection = null;

        //set login information for database connection
        private const string data = "kit206";//Database
        private const string user = "kit206";//Username
        private const string pass = "kit206";//Password
        private const string serv = "alacritas.cis.utas.edu.au";//Database server

        //return database connection (database does not open now)
        private static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionDetails = String.Format
                    ("Database={0}; Data Source={1}; User Id={2}; Password={3}",data,serv,user,pass);
                connection = new MySqlConnection(connectionDetails);
            }

            return connection;
        }

        /// <summary>
        /// get basic results of researchers from database
        /// </summary>
        public static List<Researcher> fetchBasicReseacrherDetails()
        {
            List<Researcher> researchers = new List<Researcher>();
            MySqlConnection connection = GetConnection();

            //use MySqlReader to "read" database entries
            MySqlDataReader reader = null;

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand
                    ("select type, id, title, given_name, family_name, level from researcher", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if(reader.GetString(0) == "Student")
                    {
                        researchers.Add(new Researcher
                        {
                            id = reader.GetInt32(1),
                            Title = reader.GetString(2),
                            GivenName = reader.GetString(3),
                            FamilyName = reader.GetString(4),
                            currentJob = reader.GetString(0).ToEnum<EmploymentLevel>()
                        });
                    }
                    else if (reader.GetString(0) == "Staff")
                    {
                        researchers.Add(new Researcher
                        {
                            id = reader.GetInt32(1),
                            Title = reader.GetString(2),
                            GivenName = reader.GetString(3),
                            FamilyName = reader.GetString(4),
                            currentJob = reader.GetString(5).ToEnum<EmploymentLevel>()
                        });
                    }
                }
            }
            catch (MySqlException error)
            {
                Console.WriteLine("Error: " + error);
            }
            finally
            {
                //close connections
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }

            researchers.Sort((researcher_one, researcher_two) => researcher_one.FamilyName.CompareTo(researcher_two.FamilyName));
            return researchers;
        }



        /// <summary>
        /// Fill details of selected researcher from database
        /// </summary>
        public static Researcher fetchFullResearcherDetails(Researcher researcher)
        {
            MySqlConnection connection = GetConnection();
            MySqlCommand command = null;
            MySqlDataReader reader = null;

            if (researcher != null)
            {
                try
                {
                    connection.Open();
                    command = new MySqlCommand
                        ("select type, unit, campus, email, photo, utas_start, current_start, supervisor_id, degree from researcher where id = '" + researcher.id + "'", connection);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        researcher.Type = reader.GetString(0);
                        researcher.School = reader.GetString(1);
                        researcher.Campus = reader.GetString(2).EnumValue<Campus>();
                        researcher.Email = reader.GetString(3);
                        researcher.PhotoURL = reader.GetString(4);
                        researcher.EarliestStart = reader.GetDateTime(5);
                        researcher.CurrentJobStart = reader.GetDateTime(6);

                        if (researcher.Type == "Student")
                        {
                            researcher.Degree = reader.GetString(8);
                            researcher.SupervisorID = reader.GetString(7);
                            reader.Close();

                            command = new MySqlCommand
                                ("select given_name, family_name, title from researcher where id = '" + researcher.SupervisorID + "'", connection);
                            reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                researcher.Supervisor = string.Format("{0} {1} {2}", reader.GetString(2), reader.GetString(1), reader.GetString(0));
                                
                            }
                        }
                    }
                }
                catch (MySqlException error)
                {
                    Console.WriteLine("Error:" + error);
                }
                finally
                {
                    if (reader != null) { reader.Close(); }
                    if (connection != null) { connection.Close(); }
                }
            }
                return researcher;
        }

        /// <summary>
        /// get basic results of selected researcher's publication from database
        /// </summary>
        public static List<Publication> fetchBasicPublicationDetails (Researcher researcher)
        {
            List<Publication> Pubs = new List<Publication>();
            MySqlConnection connection = GetConnection();
            MySqlDataReader reader = null;

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("select p.doi, p.year, p.title from  researcher_publication as rp, publication as p where rp.researcher_id='" + researcher.id + "' and rp.doi = p.doi", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pubs.Add(new Publication
                    {
                        Doi = reader.GetString(0),
                        PublicationYear = reader.GetInt32(1),
                        Title=reader.GetString(2)
                    });
                }
            }
            catch (MySqlException error)
            {
                Console.WriteLine("Error: " + error);
            }
            finally
            {
                if (reader != null){reader.Close();}
                if (connection != null) { connection.Close();}
            }

            Pubs.Sort((pub_one, pub_two) => pub_one.PublicationYear.CompareTo(pub_two.PublicationYear));

            return Pubs;
        }

        /// <summary>
        /// Fill details of selected publication from database
        /// </summary>
        public static Publication completePublicationDetails(Publication publication)
        {
            MySqlConnection connection = GetConnection();
            MySqlDataReader reader = null;

            if (publication != null)
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("select authors, type, cite_as, available from publication where doi = '" + publication.Doi + "'", connection);
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        publication.Authors = reader.GetString(0);
                        publication.Type = reader.GetString(1).ToEnum<OutputType>();
                        publication.CiteAs = reader.GetString(2);
                        publication.Available = reader.GetDateTime(3);

                    }

                }
                catch (MySqlException error)
                {
                    Console.WriteLine("Error: " + error);
                }
                finally
                {
                    if (reader != null) { reader.Close(); }
                    if (connection != null) { connection.Close(); }
                }
            }

           return publication;
        }

        /// <summary>
        /// count number of publications in the period of time
        /// </summary>
        public static int fetchPublicationCounts(DateTime from, DateTime to)
        {
            int counter = 0;

            MySqlConnection connection = GetConnection();
            MySqlDataReader reader = null;
            List<Publication> pubs = new List<Publication>();
            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("select doi, title from publication where available between '" + from + "' and '" + to + "'", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pubs.Add(new Publication
                    {
                        Doi = reader.GetString(0),
                        Title = reader.GetString(1)
                    });
                    counter++;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: " + error);
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }


            return counter;
        }
    }
}
