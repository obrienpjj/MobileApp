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

namespace MobileApp.Model
{
    public class Ranking
    {
        private int ID { get; set; }
        private int Score { get; set; }
        private string Name { get; set; }

        public Ranking(int Id, int score, string name)
        {
            
            ID = Id;
            Score = score;
            Name = Name;
        }
    }
}