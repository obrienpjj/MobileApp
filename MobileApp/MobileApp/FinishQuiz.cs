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
using MobileApp.DataAccess;

namespace MobileApp.Model
{
    [Activity(Label = "FinishQuiz")]
    public class FinishQuiz : Activity
    {

        Button btnTryAgain;
        TextView txtTotalScore;
        TextView txtTotalQuestion;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.FinishQuizLayout);

            DBStore db = new DBStore();

            btnTryAgain = FindViewById<Button>(Resource.Id.btnTryAgain);
            txtTotalQuestion = FindViewById<TextView>(Resource.Id.txtTotalQuestion);
            txtTotalScore = FindViewById<TextView>(Resource.Id.txtTotalScore);

            btnTryAgain.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                Finish();
            };

            Bundle bundle = Intent.Extras;
            if (bundle != null)
            {
                int score = bundle.GetInt("Score");
                int totalQuestion = bundle.GetInt("Total");
                int correctAnswer = bundle.GetInt("Correct");

                txtTotalScore.Text = $"Score: {score}";
                txtTotalQuestion.Text = $"You got {correctAnswer}/{totalQuestion}";

                db.InsertScore(score);
            }
        }
    }
}