using Android.App;
using Android.Widget;
using Android.OS;
using MobileApp.DataAccess;
using Android.Content;
using System;
using static Android.Widget.SeekBar;
using MobileApp.Common;

namespace MobileApp
{
    [Activity(Label = "MobileApp", MainLauncher = true)]

    public class MainActivity : Activity,IOnSeekBarChangeListener
    {
        SeekBar seekBar;
        TextView txtMode;
        Button btnPlay, btnScore;
        DBStore db;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            seekBar = FindViewById<SeekBar>(Resource.Id.seekBar);
            txtMode = FindViewById<TextView>(Resource.Id.txtMode);
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnScore = FindViewById<Button>(Resource.Id.btnScore);

            seekBar.SetOnSeekBarChangeListener(this);

            btnPlay.Click += delegate
            {
                Intent intent = new Intent(this, typeof(PlayActivity));
                intent.PutExtra("MODE", getPlayMode());
                StartActivity(intent);
                Finish();
            };
            btnScore.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ScoreActivity));
                StartActivity(intent);
                Finish();
            };
        }

        private String getPlayMode()
        {
            if (seekBar.Progress == 0)
            {
                return Common.Common.MODE.Easy.ToString();
            }
            else if (seekBar.Progress == 1)
            {
                return Common.Common.MODE.Medium.ToString();
            }
            else if (seekBar.Progress == 2)
            {
                return Common.Common.MODE.Hard.ToString();
            }
            else
            {
                return Common.Common.MODE.INSANE.ToString();
            }
        }

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
                txtMode.Text = getPlayMode();
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
          
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
           
        }
    }
}

