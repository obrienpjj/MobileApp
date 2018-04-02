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

            int limit;
            


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


            using (SQLiteConnection cxn = new SQLiteConnection(DBStore.DBLocation))
            {
                IEnumerable<Question> questions = cxn.Query<Question>("SELECT * FROM Question ORDER BY Random() LIMIT {limit}");

                foreach (Question question in questions)
                {
                    list.Add(question);
                }
            }

            return list;
        }
    }
}