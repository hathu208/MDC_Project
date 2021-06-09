using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;

namespace MDC.PaymentIntegration.PaymentIntegration
{
    public class APIController
    {
        public static class APIMethod
        {
            public static string GET = "GET";
            public static string POST = "POST";
            public static string PUT = "PUT";
            public static string PATCH = "PATCH";
            public static string DELETE = "DELETE";
        }

        private HttpWebRequest httpRequest;
        public HttpWebRequest HttpRequest
        {
            get { return httpRequest; }
            set { httpRequest = value; }
        }

        private string apiKey;
        public string ApiKey
        {
            get
            {
                return apiKey;
            }
            set { apiKey = value; }
        }

        private string method;
        public string Method
        {
            get { return method; }
            set { method = value; }
        }

        private object data;
        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        private string url;
        public string Url
        {
            get
            {
                return url;
            }
            set { url = value; }
        }

        private int statusCode;
        public int StatusCode
        {
            get { return statusCode; }
            set { statusCode = value; }
        }

        private string responseString;
        public string ResponseString
        {
            get { return responseString; }
            set { responseString = value; }
        }

        public APIController(string _method, string _url, string _apiKey)
        {
            method = _method;
            url = _url;
            apiKey = _apiKey;
        }

        private void initRequest()
        {
            //set security Protocol for .net framework 3.5
            const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
            const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
            ServicePointManager.SecurityProtocol = Tls12;
            //--set security Protocol for .net framework 3.5
            httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = method;
            httpRequest.ContentType = "application/json; charset=utf-8";
            httpRequest.Headers.Add("Authorization", apiKey);
        }

        public void SendRequest()
        {
            initRequest();
            try
            {
                // Convert the string into a json. 
                string jsonData = string.Empty;
                if (data != null)
                {
                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    };
                    jsonData = JsonConvert.SerializeObject(data, Formatting.None, jsonSettings);

                    //httpRequest.ContentLength = jsonData.Length;
                }

                //request stream
                if (!string.IsNullOrEmpty(jsonData))
                {
                    Stream postStream = httpRequest.GetRequestStream();
                    StreamWriter postStreamWriter = new StreamWriter(postStream);
                    // Write to the request stream.
                    postStreamWriter.Write(jsonData);
                    postStreamWriter.Close();
                }

                //Reponse
                using (var response = (HttpWebResponse)httpRequest.GetResponse())
                {
                    statusCode = (int)response.StatusCode;

                    Stream stream = response.GetResponseStream();
                    StreamReader streamRead = new StreamReader(stream);
                    responseString = streamRead.ReadToEnd();

                    stream.Close();
                    streamRead.Close();
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (var sr = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        responseString = sr.ReadToEnd();
                    }
                }
                else
                    responseString = ex.Message;

            }
            catch (Exception ex)
            {
                responseString = ex.Message;
            }
        }

        public void SendRequest(Object objRequest)
        {
            initRequest();
            try
            {
                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };

                string jsonRequest = JsonConvert.SerializeObject(objRequest, Formatting.None, jsonSettings);
                //request stream
                if (!string.IsNullOrEmpty(jsonRequest))
                {
                    httpRequest.ContentLength = jsonRequest.Length;

                    Stream postStream = httpRequest.GetRequestStream();
                    StreamWriter postStreamWriter = new StreamWriter(postStream);
                    // Write to the request stream.
                    postStreamWriter.Write(jsonRequest);
                    postStreamWriter.Close();
                }

                //Reponse
                using (var response = (HttpWebResponse)httpRequest.GetResponse())
                {
                    statusCode = (int)response.StatusCode;

                    Stream stream = response.GetResponseStream();
                    StreamReader streamRead = new StreamReader(stream);
                    responseString = streamRead.ReadToEnd();

                    stream.Close();
                    streamRead.Close();
                }
            }
            catch (WebException ex)
            {
                using (var sr = new StreamReader(ex.Response.GetResponseStream()))
                {
                    responseString = sr.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                responseString = ex.Message;
            }
        }
    }
}
