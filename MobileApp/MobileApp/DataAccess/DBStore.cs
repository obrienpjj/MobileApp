using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;
using SQLite;
using MobileApp.Model;

namespace MobileApp.DataAccess
{
    class DBStore
    {
        public static string DBLocation
        {
            get;
        }

        static DBStore()
        {
            if (string.IsNullOrEmpty(DBLocation))
            {
                DBLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                                          "MobileApp.db3");
                InitialiseDB();
            }
        }

        private static void InitialiseDB()
        {
            try
            {
                using (SQLiteConnection cxn = new SQLiteConnection(DBLocation))
                {
                    //Make DB Here
                    cxn.CreateTable<Ranking>();
                    cxn.CreateTable<Question>();
                    TableQuery<Question> query = cxn.Table<Question>();
                    if (query.Count() == 0)
                    {
                        Question q1 = new Question()
                        {
                            Country = "Ireland",
                            AnswerA = "Kairo",
                            AnswerB = "Belfast",
                            AnswerC = "Dublin",
                            AnswerD = "London",
                            CorrectAnswer = "Dublin"
                        };

                        Question q2 = new Question()
                        {
                            Country = "England",
                            AnswerA = "London",
                            AnswerB = "Paris",
                            AnswerC = "New York",
                            AnswerD = "Florida",
                            CorrectAnswer = "London"
                        };

                        Question q3 = new Question()
                        {
                            Country = "Scotland",
                            AnswerA = "Belfast",
                            AnswerB = "Wellington",
                            AnswerC = "St. Paulo",
                            AnswerD = "Edinburgh",
                            CorrectAnswer = "Edinburgh"
                        };

                        Question q4 = new Question()
                        {
                            Country = "France",
                            AnswerA = "Bruge",
                            AnswerB = "Paris",
                            AnswerC = "Toulouse",
                            AnswerD = "Vienne",
                            CorrectAnswer = "Paris"
                        };

                        Question q5 = new Question()
                        {
                            Country = "Belgium",
                            AnswerA = "Brussels",
                            AnswerB = "Jerusalem",
                            AnswerC = "Dublin",
                            AnswerD = "Monte Carlo",
                            CorrectAnswer = "Brussels"
                        };

                        Question q6 = new Question()
                        {
                            Country = "Spain",
                            AnswerA = "Brussels",
                            AnswerB = "Rome",
                            AnswerC = "Lisbon",
                            AnswerD = "Madrid",
                            CorrectAnswer = "Madrid"
                        };

                        Question q7 = new Question()
                        {
                            Country = "Portugal",
                            AnswerA = "Copenhagen",
                            AnswerB = "Nottingham",
                            AnswerC = "Lisbon",
                            AnswerD = "Genoa",
                            CorrectAnswer = "Lisbon"
                        };

                        Question q8 = new Question()
                        {
                            Country = "Germany",
                            AnswerA = "Oslo",
                            AnswerB = "Munich",
                            AnswerC = "The Hague",
                            AnswerD = "Inverness",
                            CorrectAnswer = "Munich"
                        };

                        Question q9 = new Question()
                        {
                            Country = "Switzerland",
                            AnswerA = "Bern",
                            AnswerB = "Grenwich",
                            AnswerC = "Stuttgart",
                            AnswerD = "Istanbul",
                            CorrectAnswer = "Bern"
                        };

                        Question q10 = new Question()
                        {
                            Country = "Luxembourg",
                            AnswerA = "Jerusalem",
                            AnswerB = "Oregon",
                            AnswerC = "Sydney",
                            AnswerD = "Luxembourg City",
                            CorrectAnswer = "Luxembourg City"
                        };

                        Question q11 = new Question()
                        {
                            Country = "Italy",
                            AnswerA = "Genoa",
                            AnswerB = "Rome",
                            AnswerC = "Bologne",
                            AnswerD = "Tivoli",
                            CorrectAnswer = "Rome"
                        };

                        Question q12 = new Question()
                        {
                            Country = "Denmark",
                            AnswerA = "Stockholm",
                            AnswerB = "Copenhagen",
                            AnswerC = "Malmo",
                            AnswerD = "Aarhus",
                            CorrectAnswer = "Copenhagen"
                        };

                        Question q13 = new Question()
                        {
                            Country = "Sweden",
                            AnswerA = "Gothenburg",
                            AnswerB = "Helsinki",
                            AnswerC = "Oslo",
                            AnswerD = "Stockholm",
                            CorrectAnswer = "Stockholm"
                        };

                        cxn.Insert(q1);
                        cxn.Insert(q2);
                        cxn.Insert(q3);
                        cxn.Insert(q4);
                        cxn.Insert(q5);
                        cxn.Insert(q6);
                        cxn.Insert(q7);
                        cxn.Insert(q8);
                        cxn.Insert(q9);
                        cxn.Insert(q10);
                        cxn.Insert(q11);
                        cxn.Insert(q12);
                        cxn.Insert(q13);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<Question> GetQuestion(string mode)
        {
            List<Question> list = new List<Question>();

            int limit = 0;
            


            if (mode.Equals(Common.Common.EASY_MODE_NUM.ToString()))
            {
                limit = Common.Common.EASY_MODE_NUM;
            }
            if (mode.Equals(Common.Common.MEDIUM_MODE_NUM.ToString()))
            {
                limit = Common.Common.MEDIUM_MODE_NUM;
            }
            if (mode.Equals(Common.Common.HARD_MODE_NUM.ToString()))
            {
                limit = Common.Common.HARD_MODE_NUM;
            }
            if (mode.Equals(Common.Common.INSANE_MODE_NUM.ToString()))
            {
                limit = Common.Common.INSANE_MODE_NUM;
            }

            try
            {
                using (SQLiteConnection cxn = new SQLiteConnection(DBStore.DBLocation))
                {
                    IEnumerable<Question> questions = cxn.Query<Question>($"SELECT * FROM Question ORDER BY Random() LIMIT {limit}");


                    foreach (Question question in questions)
                    {
                        list.Add(question);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return list;
        }

        public void InsertScore(int score)
        {
            try
            {
                using (SQLiteConnection cxn = new SQLiteConnection(DBLocation))
                {
                    TableQuery<Ranking> query = cxn.Table<Ranking>();
                    Ranking rank = new Ranking()
                    {
                        Score = score
                    };

                    cxn.Insert(rank);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        public List<Ranking> GetRanking()
        {
            List<Ranking> list = new List<Ranking>();
            try
            {
                using (SQLiteConnection cxn = new SQLiteConnection(DBStore.DBLocation))
                {
                    IEnumerable<Ranking> ranks = cxn.Query<Ranking>($"SELECT * FROM Ranking ORDER BY Score");


                    foreach (Ranking rank in ranks)
                    {
                        list.Add(rank);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return list;

        }
    }
}