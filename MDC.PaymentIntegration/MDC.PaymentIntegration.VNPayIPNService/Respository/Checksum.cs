using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MDC.PaymentIntegration.VNPayPayment
{
    internal class Checksum
    {
        private void Sort(JObject jObj)
        {
            var props = jObj.Properties().ToList();
            foreach (var prop in props)
            {
                prop.Remove();
            }

            foreach (var prop in props.OrderBy(p => p.Name))
            {
                jObj.Add(prop);
                if (prop.Value is JObject)
                    Sort((JObject)prop.Value);
            }
            
        }
        
        public string generateCheckSum(Object objRequest, string apiKey)
        {
            JObject jObj;
            string result;
            string sortString = apiKey;

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            string jsonRequest = JsonConvert.SerializeObject(objRequest, Formatting.None, jsonSettings);
            jObj = (JObject)JsonConvert.DeserializeObject(jsonRequest);

            Sort(jObj);

            var props = jObj.Properties().ToList();
            foreach (var prop in props)
            {
                string value;
                if (prop.Value.Type == JTokenType.String)
                {
                    value = prop.Value.ToString().Substring(1, prop.Value.ToString().Length - 2);
                }
                else
                {
                    value = prop.Value.ToString(Formatting.None);
                }
                sortString += prop.Name + "=" + value + "&";
            }
            sortString = sortString.Substring(0, sortString.Length - 1);
            result = Checksum.MD5Hash(sortString);

            return result;
        }

        public static string MD5Hash(string text)
        {
            MD5 mD5 = MD5CryptoServiceProvider.Create();
            //compute hash from the bytes of text  
            /*byte[] hashedBytes = mD5.ComputeHash(Encoding.UTF8.GetBytes(text));
            string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedString;*/

            mD5.ComputeHash(Encoding.UTF8.GetBytes(text));
            //get hash result after compute it  
            byte[] result = mD5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
