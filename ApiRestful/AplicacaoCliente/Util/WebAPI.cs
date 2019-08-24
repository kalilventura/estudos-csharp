using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoCliente.Util
{
    public class WebAPI
    {
        public static string URI = "http://localhost:44144/api/cliente/";
        public static string TOKEN = "123sfas146sdf46165546dsf";

        private static string RequesteGET_DELETE(string metodo, string parametro, string tipo)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo + "/" + parametro);
            request.Headers.Add("Token", TOKEN);
            request.Method = tipo;
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        public static string RequestGET(string metodo, string parametro)
        {
            return RequesteGET_DELETE(metodo, parametro, "GET");
        }

        public static string RequestDELETE(string metodo, string parametro)
        {
            return RequesteGET_DELETE(metodo, parametro, "DELETE");
        }

        public static string RequestPOST(string metodo, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo);            
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "POST";
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        public static string RequestPUT(string metodo, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + metodo);
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "PUT";
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
