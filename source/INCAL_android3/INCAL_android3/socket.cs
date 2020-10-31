using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Preferences;

namespace INCAL_android3
{
    public class socket
    {
        static Socket sck;
        public int class_data;
        public int grade_data;
        public int  data_size { get; set;}
        public Data[] data = new Data[100];
        public bool Socket_test()
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("110.10.38.94"), 1502);

            for (int i = 0; i < 100; i++) 
            {
                data[i] = new Data();
            }
            try
            {
                sck.Connect(localEndPoint);
                
                int i = 0;
                while(true)
                {
                    String _data = "";
                    Recieve(sck, ref _data);
                    if (_data == "EOF") break;
                    data[i].Subject = _data;
                    Recieve(sck, ref _data);
                    data[i].T_Name = _data;

                    Recieve(sck, ref _data);
                    data[i].Contents = _data;

                    Recieve(sck, ref _data);
                    data[i].Title = _data;

                    Recieve(sck, ref _data);
                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    data[i].Date = Convert.ToDateTime(_data);//DateTime.Parse(_data, originalCulture,DateTimeStyles.NoCurrentDateDefault);
                    i++;
                }
                data_size = i;
            }
            catch (System.Net.Sockets.SocketException socketEx)
            {
                return false;
            }
            catch (System.Exception commonEx)
            {
                return false;
            }
            return true;
        }


        private static bool Recieve(Socket sock, ref String msg)
        {
            byte[] data_size = new byte[4];
            sock.Receive(data_size, 0, 4, SocketFlags.None);
            int size = BitConverter.ToInt32(data_size, 0);
            byte[] data = new byte[size];
            sock.Receive(data, 0, size, SocketFlags.None);
            msg = Encoding.Default.GetString(data);
            return true;
        }
    }
}