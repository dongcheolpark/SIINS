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

namespace INCAL_android3
{
    [Activity(Label ="@string/app_name")]
    class contentspage : Activity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);

            SetContentView(Resource.Layout.contentspage);

            var title = FindViewById<TextView>(Resource.Id.title);
            var contents = FindViewById<TextView>(Resource.Id.contents);
            title.Text = Intent.GetStringExtra("titlename") ?? "Data not available";
            contents.Text = Intent.GetStringExtra("contents") ?? "Data not available";

        }
    }
}