using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace INCAL_Server
{
    public class AndroidGCMPushNotification
    {
        public AndroidGCMPushNotification()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void SendNotification()
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "POST";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AIzaSyBtKwUmTj4XZIkQwDnj4sVue52fZGLfgK0"));
            //Sender Id - From firebase project setting 
            tRequest.ContentType = "application/json";
            tRequest.Headers.Add(string.Format("Sender: id={0}", "118956844564"));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = "/topics/all",
                priority = 10,
                content_available = true,
                notification = new
                {
                    title = "새로운 숙제가 도착했어요!",
                    body = "클릭해서 확인하세요"
                }
            };

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (HttpWebResponse tResponse = (HttpWebResponse)tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                Console.WriteLine(tResponse.StatusCode.ToString());
                                String sResponseFromServer = tReader.ReadToEnd();
                                Console.WriteLine(sResponseFromServer);
                                //result.Response = sResponseFromServer;
                            }
                    }
                }
            };
        }
    }
}
