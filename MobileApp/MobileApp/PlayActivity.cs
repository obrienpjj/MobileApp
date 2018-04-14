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
using MobileApp.Model;
using static Android.Views.View;

namespace MobileApp
{
    [Activity(Label = "PlayActivity")]
    public class PlayActivity : Activity,IOnClickListener
    {
        const int interval = 1000;
        const int timeOut = 6000;
        int processValue = 0;

        static CountDown mCountDown;
        List<Question> questions = new List<Question>();
        Question questionPlay = new Question();

        DBStore db = new DBStore();

        public int index, score, thisQuestion, totalQuestion, correctAnswer;
        string mode;

        Button btnA;
        Button btnB;
        Button btnC;
        Button btnD;

        TextView txtScore;
        TextView txtQuestionCity;
        TextView txtQuestionNo;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Playing);
            Bundle extra = Intent.Extras;
            if (extra != null)
                mode = extra.GetString("MODE");

            

            Button btnA = FindViewById<Button>(Resource.Id.btnA);
            Button btnB = FindViewById<Button>(Resource.Id.btnB);
            Button btnC = FindViewById<Button>(Resource.Id.btnC);
            Button btnD = FindViewById<Button>(Resource.Id.btnD);
            TextView txtQuestionNo = FindViewById<TextView>(Resource.Id.txtQuestionNo);
            TextView txtQuestionCity = FindViewById<TextView>(Resource.Id.txtQuestionCity);
            txtScore = FindViewById<TextView>(Resource.Id.txtScore);

            btnA.SetOnClickListener(this);
            btnB.SetOnClickListener(this);
            btnC.SetOnClickListener(this);
            btnD.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            mCountDown.Cancel();
            if (index < totalQuestion)
            {
                Button btnClicked = (Button)v;
                if (btnClicked.Text.Equals(questions[index].CorrectAnswer))
                {
                    score += 10;
                    correctAnswer++;
                    ShowQuestion(++index);
                }
                else
                {
                    ShowQuestion(++index);
                }
            }
            txtScore.Text = $"{score}";
                
            
        }

        public void ShowQuestion(int v)
        {
            if(index < totalQuestion)
            {
                thisQuestion++;
                txtQuestionNo.Text = $"{thisQuestion} / {totalQuestion}";

                btnA.Text = questions[index].AnswerA;
                btnB.Text = questions[index].AnswerB;
                btnC.Text = questions[index].AnswerC;
                btnD.Text = questions[index].AnswerD;

                mCountDown.Start();
            }

            else
            {
                Intent intent = new Intent(this, typeof(FinishQuiz));
                Bundle dataSend = new Bundle();
                dataSend.PutInt("Score", score);
                dataSend.PutInt("Total", totalQuestion);
                dataSend.PutInt("Correct", correctAnswer);

                intent.PutExtras(dataSend);
                StartActivity(intent);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            questions = db.GetQuestion(mode);
            totalQuestion = questions.Count;
            mCountDown = new CountDown(this, timeOut, interval);
            ShowQuestion(index);
        }
        

        
    }
}