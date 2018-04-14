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
using MobileApp.Common;
using MobileApp.DataAccess;
using MobileApp.Model;

namespace MobileApp
{
    [Activity(Label = "Score")]
    public class Score : Activity
    {
        ListView listView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Score);
            // Create your application here

            listView = FindViewById<ListView>(Resource.Id.listView);

            DBStore db = new DBStore();
            List<Ranking> rankings = new List<Ranking>();

            if (rankings.Count >0)
            {
                ScoreAdapter adapter = new ScoreAdapter(this, rankings);
                listView.Adapter = adapter;
            }
        }
    }
}