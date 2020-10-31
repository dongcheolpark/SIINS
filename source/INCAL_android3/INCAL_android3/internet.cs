using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7;
using Android.Support.V7.App;
using Android.Util;

namespace INCAL_android3
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class internet : Activity
    {
        public void Oncreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.layout.layout1);
        }
    }
}