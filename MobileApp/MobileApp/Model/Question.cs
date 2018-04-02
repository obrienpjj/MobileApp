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
    class Question
    {
        private int ID { get; set; }
        private string Country { get; set; }
        private string AnswerA { get; set; }
        private string AnswerB { get; set; }
        private string AnswerC { get; set; }
        private string AnswerD { get; set; }
        private string CorrectAnswer { get; set; }

        public Question() { }

        public Question(int iD, string country, string answerA, string answerB, string answerC, string answerD, string correctAnswer)
        {
            ID = iD;
            Country = country;
            AnswerA = answerA;
            AnswerB = answerB;
            AnswerC = answerC;
            AnswerD = answerD;
            CorrectAnswer = correctAnswer;
        }
    }
}