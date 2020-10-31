using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Views;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Webkit;

namespace INCAL_android3
{
    [Activity(Label ="@string/app_name")]
    class contentspage : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.contentspage);
            var title = FindViewById<TextView>(Resource.Id.title);
            var contents = FindViewById<WebView>(Resource.Id.contents);
            var T_name = FindViewById<TextView>(Resource.Id.T_name_text);
            var date = FindViewById<TextView>(Resource.Id.Date_text);
            var subject = FindViewById<TextView>(Resource.Id.Subject_text);
            contents.LoadData(Intent.GetStringExtra("contents") ?? "Data not available", "Text/Html; charset=UTF-8", null);
            T_name.Text = "선생님:" + Intent.GetStringExtra("T_Name") ?? "Data not available";
            date.Text = "기한:" + Intent.GetStringExtra("Date") ?? "Data not available" ;
            subject.Text = "과목:" + Intent.GetStringExtra("Subject") ?? "Data not available" ;
        }
        public override void OnBackPressed()
        {
            Finish();
            OverridePendingTransition(Resource.Animation.abc_popup_enter, Resource.Animation.abc_popup_exit);
        }
    }
}