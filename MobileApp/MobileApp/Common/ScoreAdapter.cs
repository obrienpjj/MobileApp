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
using MobileApp.Model;

namespace MobileApp.Common
{
    class ScoreAdapter : BaseAdapter
    {
        public List<Ranking> rankings;
        Context context;
        TextView txtTop;


        public ScoreAdapter(Context context, List<Ranking> Rankings)
        {
            this.context = context;
            this.rankings = Rankings;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var ScoreListViewview = convertView;
            ScoreAdapterViewHolder holder = null;

            

            if (ScoreListViewview == null)
            {
                var inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                ScoreListViewview = inflater.Inflate(Resource.Layout.ScoreListView, null);

                txtTop = ScoreListViewview.FindViewById<TextView>(Resource.Id.txtTop);

                ScoreListViewview.Tag = holder;

                //Have to create adapterviewholder class
            }


            //fill in your items
            //holder.Title.Text = "new text here";

            var cachedScoreListViewHolder = ScoreListViewview.Tag as ScoreAdapterViewHolder;

            txtTop.Text = $"{rankings[position].Score}";

            return ScoreListViewview;
        }

        
        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return rankings.Count;
            }
        }

    }

    
}