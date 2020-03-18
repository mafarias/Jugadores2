using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAPi
{
    public class Class1
    {
        public void EjecutarApi()
        {
            try
            {

                var url = "http://localhost:50788/api/TBL_EXCEPTIONS1";//ConfigurationManager.AppSettings["UrlApiExcepcion"]; 
                var json = JsonConvert.SerializeObject();
                var res = GetApiHttpPost(url, json);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetApiHttpPost(string path, string valor)
        {
            try
            {
                string url = path;
                string postdata = valor;
                byte[] data = Encoding.UTF8.GetBytes(postdata);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "POST";
                request.Timeout = 30000;
                // turn our request string into a byte stream
                byte[] postBytes = Encoding.UTF8.GetBytes(postdata);

                // this is important - make sure you specify type this way
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                request.ContentLength = postBytes.Length;

                Stream requestStream = request.GetRequestStream();

                // now send it
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                // grab te response and print it out to the console along with the status code
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string result;
                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    result = rdr.ReadToEnd();
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
