using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json.Linq;


namespace Nest1
{
    class Program
    {
        static void Main(string[] args)
        {
            ambientTemperature();
            Console.ReadLine();
        }

        static void ambientTemperature()
        {
            //Server

            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://www.mappit.us/nest.txt");
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();

            //temperature

            JObject results = JObject.Parse(content);
            JObject devices = (JObject)results["devices"];
            JObject thermostat = (JObject)devices["thermostats"];
            JObject id = (JObject)thermostat["peyiJNo0IldT2YlIVtYaGQ"];
            JValue temperature = (JValue)id["ambient_temperature_c"];

            //XML

            string path = @"E:\XML\test.xml";
            string text = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><configurations xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"configurations.xsd\"><temperature>" + temperature + "</temperature></configurations>";
            File.WriteAllText(path, text);

            Console.WriteLine("Temperature : " + temperature.Value);
            
        }
    }

}