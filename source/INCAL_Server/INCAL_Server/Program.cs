using System;
using System.Net;
using System.Net.Sockets;
using System.Data.SQLite;
using System.Globalization;
using System.Threading;
using System.Text;
using System.Data.SqlClient;

using System.Threading.Tasks;

namespace INCAL_Server
{
    public class ServerClass
    {
        public static Socket Server, Server2, Server3, Client, Client2, Client3;
        public static byte[] getByte = new byte[1024];
        public static byte[] setByte = new byte[1024];
        static string strConn = "Data Source=incal.iptime.org;Initial Catalog=INCAL;User ID=sa;Password=tr2042255";
        static SQLiteConnection conn = null;
        public const int sPort = 1501;
        public const int sport2 = 1502;
        public const int sport3 = 1503;
        public static Command console_command;
        [STAThread]
        static void Main(string[] args)
        {
            IPAddress serverIP = IPAddress.Parse("110.10.38.94");
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, sPort);
            Console.WriteLine("INCAL Server v.1.0.0");
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server3 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Server.Bind(serverEndPoint);
            serverEndPoint.Port = sport2;
            Server2.Bind(serverEndPoint);
            serverEndPoint.Port = sport3;
            Server3.Bind(serverEndPoint);
            Thread server_teacher = new Thread(new ThreadStart(Server_teacher));
            server_teacher.Start();
            Thread server_app = new Thread(new ThreadStart(Server_app));
            server_app.Start();
            Thread server_noti = new Thread(new ThreadStart(Server_noti));
            server_noti.Start();
            
            while (true)
            {
                try
                {
                    console_command = new Command(new SQLiteConnection(strConn));
                    console_command.CommandLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Server_app()
        {
            while (true)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        Server2.Listen(10);

                        Client2 = Server2.Accept();
                        console_command.Showip(Client2);
                        if (Client2.Connected)
                        {
                            DbControll.Del();
                            var cmd = new SqlCommand("select * from Homework", conn);
                            var rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                Send(Client2, (string)rdr["Subject"]);

                                //Send(Client2, (string)rdr[1]);

                                Send(Client2, (string)rdr["T_Name"]);

                                Send(Client2, (string)rdr["Contents"]);

                                //Send(Client2, (string)rdr[4]);

                                Send(Client2, (string)rdr["Title"]);

                                Send(Client2, Convert.ToDateTime(rdr["date"]).ToString("dd/MM/yyyy"));
                            }
                            Send(Client2, "EOF");
                            rdr.Close();
                            Client2.Close();
                        }
                    }
                }
                catch (System.Net.Sockets.SocketException socketEx)
                {
                    Console.WriteLine("[Error]:{0}", socketEx.Message);
                }
                catch (System.Exception commonEx)
                {
                    Console.WriteLine("[Error]:{0}", commonEx.Message);
                }
            }
        }

        public static void Server_noti()
        {
            while (true) {
                Server3.Listen(10);
                Client3 = Server3.Accept();

                if(Client3.Connected) { 
                    sendnoti();
                }
            }
        }
        public static bool Send(Socket sock, String msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            int size = data.Length;

            byte[] data_size = new byte[4];
            data_size = BitConverter.GetBytes(size);
            sock.Send(data_size);

            sock.Send(data, 0, size, SocketFlags.None);
            return true;
        }
        public static bool Recieve(Socket sock, ref String msg)
        {
            byte[] data_size = new byte[4];
            sock.Receive(data_size, 0, 4, SocketFlags.None);
            int size = BitConverter.ToInt32(data_size, 0);
            byte[] data = new byte[size];
            sock.Receive(data, 0, size, SocketFlags.None);
            msg = Encoding.Default.GetString(data);
            return true;
        }

        public static int byteArrayDefrag(byte[] sData)
        {
            int endLength = 0;

            for (int i = 0; i < sData.Length; i++)
            {
                if ((byte)sData[i] != (byte)0)
                {
                    endLength = i;
                }
            }

            return endLength;
        }
        static void sendnoti()
        {
            try
            {
                AndroidGCMPushNotification noti = new AndroidGCMPushNotification();
                noti.SendNotification();
            }
            catch (Exception e)
            {
                Console.WriteLine("오류가 발생했습니다.\n" + e.Message);
            }
            Console.WriteLine("알림을 정상적으로 발신했습니다.");
        }
    }
    public static class DbControll
    {
        public static void Del()
        {
            string strConn = "Data Source=incal.iptime.org;Initial Catalog=INCAL;User ID=sa;Password=tr2042255";
            using (SqlConnection conn = new SqlConnection(strConn)) { 
                var cmd = new SqlCommand("delete from Homework where Date < GETDATE()", conn);
            }
        }
    }
    public class Command
    {
        private SQLiteConnection sqlconn;
        public Command(SQLiteConnection sqlconn1)
        {
            sqlconn = sqlconn1;
            sqlconn.Open();
        }
        public void Showip(Socket Client)
        {
            Console.WriteLine("{0} \"{1}\" IP connected",DateTime.Now.ToLocalTime(), Client.RemoteEndPoint.ToString());
            //string sql = string.Format("insert into Log (IPAdress,Date) values (\"{0}\",\"{0}\")", DateTime.Now.ToLocalTime() + DateTime.Now.ToLongDateString(), Client.RemoteEndPoint.ToString());
            //SQLiteCommand command = new SQLiteCommand(sql, sqlconn);
            //command.ExecuteNonQuery();

        }
        public void CommandLine()
        {
            String cmd = Console.ReadLine();
            if (string.Compare("ShowData", cmd) == 0)
            {
                ShowData();
            }
            else if (string.Compare("del", cmd) == 0)
            {
                cmd = Console.ReadLine();
                del(cmd);
            }
            else if (string.Compare("ipban", cmd) == 0)
            {
                //구현되지 않은 부분
            }
        }
        private void ShowData()
        {
            using (sqlconn)
            {
                var cmd = new SQLiteCommand("select * from INCAL_DATA", sqlconn);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.Write((string)rdr["Subject"] + '|');

                    //Send(Client2,(string)rdr[1]);

                    Console.Write((string)rdr["T_Name"] + '|');

                    Console.Write((string)rdr["Contents"] + '|');

                    //Send(Client2, (string)rdr[4]);

                    Console.Write((string)rdr["Title"] + '|');

                    Console.WriteLine((string)rdr["Date"]);
                }
                rdr.Close();
            }
        }
        private void del(string cmd)
        {
            using(sqlconn)
            {
                string sql = string.Format("delete from INCAL_DATA where Title = {0}",cmd);
                SQLiteCommand command = new SQLiteCommand(sql,sqlconn);
                command.ExecuteNonQuery();
                Console.WriteLine(command.CommandText);
            }
        }
    }
    public class Data
    {
        public string Subject { get; set; }
        public string T_Name { get; set; }
        public string Contents { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}

