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
    [Table("Question")]
    class Question
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Country { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }

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