using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace MobileApp.Model
{
    [Table("Ranking")]
    public class Ranking
    {
        [Unique, AutoIncrement]
        public int ID { get; set; }
        public int Score { get; set; }
        
        public Ranking()
        { }

        public Ranking(int Id, int score)
        {
            
            ID = Id;
            Score = score;
        }
    }
}