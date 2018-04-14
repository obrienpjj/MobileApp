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
    internal class CountDown : CountDownTimer
    {
        PlayActivity playing;

        public CountDown(PlayActivity playActivity, long TotalTime, long interval):base(TotalTime, interval)
        {
            playing = playActivity;
        }

        public override void OnFinish()
        {
            Cancel();
            playing.ShowQuestion(++playing.index);
        }

        public override void OnTick(long millisUntilFinished)
        {
        }
    }
}