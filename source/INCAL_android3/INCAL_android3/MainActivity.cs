using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Collections.Generic;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Android.Graphics;
using Firebase;

namespace INCAL_android3
{
    [Activity(Label = "@string/Label")]
    public class MainActivity : Activity
    {
        List<Data> Datas = new List<Data>();
        ListView listView;
        TextView msgText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            FirebaseApp.InitializeApp(this);
            FirebaseMessaging.Instance.SubscribeToTopic("all");
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.workpage);
            listView = FindViewById<ListView>(Resource.Id.listView1);
            msgText = FindViewById<TextView>(Resource.Id.msgText);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetActionBar(toolbar);
            ActionBar.Title = "INCAL";
            get_date_from_server();
            listView.Adapter = new DataAdapter(this, Datas);
            listView.ItemClick += ListView_ItemClick;

        }
        void get_date_from_server()
        {
            socket sck = new socket();
            if (sck.Socket_test() == false)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);

                builder.SetPositiveButton("새로고침", (senderAlert, args) =>
                {
                    get_date_from_server();
                });

                builder.SetNegativeButton("종료", (senderAlert, args) =>
                {
                    Finish();
                });

                Android.App.AlertDialog alterDialog = builder.Create();
                alterDialog.SetTitle("알림");
                alterDialog.SetMessage("서버가 응답하지 않거나 인터넷이 연결돼 있지 않습니다. 다시 연결 하시겠습니까?");
                alterDialog.Show();
            }
            Datas = new List<Data>();
            for (int i = 0; i < sck.data_size; i++)
            {
                DateTime date1 = sck.data[i].Date;
                TimeSpan resultTime = date1 - DateTime.Now;
                var Dday = FindViewById<TextView>(Resource.Id.d_day);
                Color color = new Color();
                color = Color.DarkGreen;
                if (resultTime.Days + 1 <= 8)
                {
                    color = Color.DarkOrange;
                }

                if (resultTime.Days + 1 <= 3)
                {
                    color = Color.DarkRed;
                }
                if (resultTime.Days + 1 == 0)
                {
                    color = Color.Black;
                }
                Datas.Add(new Data()
                {
                    Color = color,
                    Title = sck.data[i].Title,
                    Date = sck.data[i].Date,
                    Contents = sck.data[i].Contents,
                    T_Name = sck.data[i].T_Name,
                    Subject = sck.data[i].Subject
                });

            }
            Datas.Sort(compare);
        }
        public int compare(Data x, Data y)
        {

            return x.Date.CompareTo(y.Date);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.tool_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (string.Compare(item.TitleFormatted.ToString(), "settings") == 0)
            {
                var intent = new Intent(this, typeof(settingspage));
                StartActivity(intent);
            }
            return base.OnOptionsItemSelected(item);
        }
        public override void OnBackPressed()
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);

            builder.SetPositiveButton("확인", (senderAlert, args) =>
            {
                Finish();
            });

            builder.SetNegativeButton("취소", (senderAlert, args) =>
            {
                return;
            });

            Android.App.AlertDialog alterDialog = builder.Create();
            alterDialog.SetTitle("알림");
            alterDialog.SetMessage("프로그램을 종료 하시겠습니까?");
            alterDialog.Show();
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            var second = new Intent(this, typeof(contentspage));

            second.PutExtra("Titlename", Datas[e.Position].Title);
            second.PutExtra("contents", Datas[e.Position].Contents);
            second.PutExtra("T_Name", Datas[e.Position].T_Name);
            second.PutExtra("Subject", Datas[e.Position].Subject);
            second.PutExtra("Date", Datas[e.Position].Date.ToShortDateString());
            StartActivity(second);
        }
    }
    public class DataAdapter : BaseAdapter<Data>
    {
        List<Data> items;
        Activity context;
        public DataAdapter(Activity context, List<Data> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Data this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            TimeSpan resultTime = item.Date - DateTime.Now;
            string a = string.Format("D-" + (resultTime.Days + 1));
            if (resultTime.Days + 1 == 0)
            {
                a = "D-Day";
            }
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.Listitem, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = String.Format("{0}년 {1}월 {2}일 까지", item.Date.Year, item.Date.Month, item.Date.Day);
            view.FindViewById<TextView>(Resource.Id.d_day).Text = a;
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetBackgroundColor(item.Color);

            return view;
        }
    }

    public class Data
    {

        public string Subject { get; set; }
        public string T_Name { get; set; }
        public string Contents { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Color Color { get; set; }
    }
}