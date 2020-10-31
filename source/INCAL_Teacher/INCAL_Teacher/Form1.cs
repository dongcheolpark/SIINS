using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INCAL_Teacher
{

    public partial class Form1 : Form
    {
        private string file_save_text = "INCAL Teacher program savefile. do not remove this sentence";
        private Data WriteData = new Data();
        private static Data[] datas = new Data[100];
        public Socket Sclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WriteData.Date = DateTime.Now;
            label1.Text = DateTime.Now.Date.ToString();
            for (int i = 0; i < 100; i++)
            {
                datas[i] = new Data();
            }
            List_add();
            /*try
            {
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127. 0. 0. 1"), 8081);
                Sclient.Connect(iPEndPoint);
            }
            catch(Exception exception)
            {
                MessageBox.Show("오류가 발생하였습니다." + exception.Message);
            }*/

        }

        private void Subject_TextBox_TextChanged(object sender, EventArgs e)
        {
            WriteData.Subject = Subject_TextBox.Text;
        }

        private void Title_TextBox_TextChanged(object sender, EventArgs e)
        {
            WriteData.Title = Title_TextBox.Text;
        }

        private void T_Name_TextBox_TextChanged(object sender, EventArgs e)
        {
            WriteData.T_Name = T_Name_TextBox.Text;
        }

        private void Contents_RichTextBox_TextChanged(object sender, EventArgs e)
        {
            WriteData.Contents = Contents_RichTextBox.Text;

        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string a = string.Format("SaveFile/" + WriteData.Title + "_" + WriteData.Subject + ".txt");
                string info = Application.StartupPath + "\\SaveFile";
                DirectoryInfo directoryInfo = new DirectoryInfo(info);
                if (directoryInfo.Exists == false)
                {
                    directoryInfo.Create();
                }
                WriteData.Contents = WriteData.Contents.Replace("\n", "\r\n");
                File.WriteAllText(@a, string.Format(file_save_text + "\r\n" + WriteData.Subject + "\r\n" + WriteData.T_Name + "\r\n" + WriteData.Title + "\r\n" + WriteData.Contents + "\r\n" + "///this is contents endline" + "\r\n" + WriteData.Date));
            }
            catch (Exception E)
            {
                MessageBox.Show("오류가 발생하였습니다.\n" + E.Message);
                return;
            }
            MessageBox.Show("저장이 정상적으로 완료되었습니다.");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Date.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            WriteData.Date = dateTimePicker1.Value;
        }

        private void Load_Button_Click(object sender, EventArgs e)
        {
            string file_path = null;
            DirectoryInfo a = new DirectoryInfo(Application.StartupPath + @"\SaveFile");
            if (a.Exists == true)
            {
                openFileDialog1.InitialDirectory = Application.StartupPath + @"\SaveFile";
            }
            else
            {
                MessageBox.Show("저장된 파일이 없습니다.");
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file_path = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("불러올 수 없거나 손상된 파일입니다.");
                return;
            }
            StreamReader stream = new StreamReader(file_path);
            if (stream.ReadLine() != file_save_text)
            {
                MessageBox.Show("불러올 수 없거나 손상된 파일입니다.");
                return;
            }

            Subject_TextBox.Text = stream.ReadLine();
            T_Name_TextBox.Text = stream.ReadLine();
            Title_TextBox.Text = stream.ReadLine();
            string contents = null, line;
            line = stream.ReadLine();
            while (string.Compare(line, "///this is contents endline") != 0)
            {
                contents += (line + "\n");
                line = stream.ReadLine();
            }
            line = stream.ReadLine();
            Contents_RichTextBox.Text = contents;
            DateTime dateTime = new DateTime();
            //DateTime.TryParse(stream.ReadLine(),out dateTime);
            //dateTimePicker1.Value = dateTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grade_class a = new grade_class();
            a.ShowDialog();
            //a.class_checked
        }

        private void UpLoad_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Socket client;
                byte[] getbyte = new byte[1024];
                byte[] setbyte = new byte[1024];

                const int sPort = 1501;

                string sendstring = null;
                string getstring = null;

                IPAddress serverIP = IPAddress.Parse("110.10.38.94");
                IPEndPoint serverEndPoint = new IPEndPoint(serverIP, sPort);

                client = new Socket(
                  AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(serverEndPoint);
                Send(client, WriteData.Subject);
                Send(client, WriteData.T_Name);
                Send(client, WriteData.Contents);
                Send(client, WriteData.Title);
                Send(client, WriteData.Date.ToShortDateString());
                client.Close();
                MessageBox.Show("정상적으로 업로드 되었습니다.");
            }
            catch (SocketException scke)
            {
                MessageBox.Show("오류가 발생하였습니다.\n" + scke.Message);
            }
        }
        public static bool Send(Socket sock, String msg)
        {
            byte[] data = Encoding.Default.GetBytes(msg);
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
        public void List_add()
        {
            socket sck = new socket();
            sck.Socket_test();
            view_data.Items.Clear();
            for(int i = 0;i<sck.data_size;i++)
            {
                datas[i].Contents = sck.data[i].Contents;
                datas[i].Title = sck.data[i].Title;
                datas[i].T_Name = sck.data[i].T_Name;
                datas[i].Subject = sck.data[i].Subject;
                datas[i].Date = sck.data[i].Date;
                view_data.Items.Add(string.Format(datas[i].Subject+"-"+datas[i].Title));

            }
        }

        private void view_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = view_data.SelectedItem.ToString();
            int index = view_data.FindString(curItem);
            if (index == -1) {
                MessageBox.Show("찾을 수 없습니다.");
                return;
            }
            Subject_TextBox.Text = datas[index].Subject;
            Title_TextBox.Text = datas[index].Title;
            T_Name_TextBox.Text = datas[index].T_Name;
            Contents_RichTextBox.Text = datas[index].Contents;
            dateTimePicker1.Value = datas[index].Date;
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            List_add();
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
