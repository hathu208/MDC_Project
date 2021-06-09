using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MDC.PaymentIntegration.PaymentIntegration.Configure
{
    public class PaymentIntegrationConfig
    {
        private static readonly string configureName = "PaymentIntegration.config";
        private static string configurePath;
        private static bool isLoaded = false;

        private VNPayPaymentConfig vnPayPayment;

        public VNPayPaymentConfig VNPayPayment
        {
            get { return vnPayPayment; }
            set { vnPayPayment = value; }
        }

        private static PaymentIntegrationConfig paymentConfig;

        public static PaymentIntegrationConfig PaymentConfig
        {
            get
            {
                return LoadConfig();
            }
        }

        private static string FullConfigurePath
        {
            get
            {
                if (!string.IsNullOrEmpty(configurePath) && !string.IsNullOrEmpty(configureName))
                    return Path.Combine(configurePath, configureName);
                return null;
            }
        }

        private PaymentIntegrationConfig()
        {
            vnPayPayment = new VNPayPaymentConfig();
        }

        private static PaymentIntegrationConfig LoadConfig()
        {
            if (!isLoaded)
            {
                try
                {
                    configurePath = Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                }
                catch (Exception)
                {
                    throw new Exception("Cannot get payment integration configure path from application.");
                }

                if (FullConfigurePath != null)
                {
                    try
                    {
                        ReadConfig();
                        if (paymentConfig == null)
                        {
                            WriteConfig();
                        }

                        isLoaded = true;
                    }
                    catch(Exception)
                    {
                        throw new Exception("Reading configured file is error.");
                    }
                }
                else
                {
                    throw new Exception("Cannot get payment integration configuration path from application.");
                }
            }

            return paymentConfig;
        }

        private static void WriteConfig()
        {
            if (paymentConfig == null)
                paymentConfig = new PaymentIntegrationConfig();

            string data = ObjectToXML<PaymentIntegrationConfig>(paymentConfig);
            File.WriteAllText(FullConfigurePath, data);
        }

        private static void ReadConfig()
        {
            if (File.Exists(FullConfigurePath))
            {
                string text = File.ReadAllText(FullConfigurePath);
                paymentConfig = XMLToObject<PaymentIntegrationConfig>(text);
            }
        }

        private static string ObjectToXML<T>(T list)
        {
            string XML = "";
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, list);
                try
                {
                    XML = sw.ToString();
                }
                catch (Exception e)
                {
                    XML = e.ToString();
                }
            }
            return XML;
        }

        private static T XMLToObject<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var textReader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(textReader))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }

    }

    
}
