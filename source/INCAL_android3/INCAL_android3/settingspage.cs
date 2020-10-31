using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace INCAL_android3
{
    [Activity(Label = "PreActivity")]
    public class settingspage : PreferenceActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Layout.prfs);
            var d = PreferenceManager.GetDefaultSharedPreferences(this);
            String Grade_data = d.GetString("Grade", "1");
            String Class_data = d.GetString("Class", "1");
        }
        public override void OnBackPressed()
        {
            base.OnBackPressed();

        }
    }
}