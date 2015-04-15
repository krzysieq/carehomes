﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;

using Microsoft.Health;
using Microsoft.Health.ItemTypes;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HAMS.HV
{
    public static class EnvTypes
    {
        public class AmbientTemperature : HealthRecordItemCustomBase
        {
            public double Value;
            public DateTime Time;

            public override void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("value");
                writer.WriteValue(Value);
                writer.WriteEndElement();
            }

            public override void ParseXml(XPathNavigator navigator)
            {
                this.Value = navigator.SelectSingleNode("value").ValueAsDouble;
                this.Time = this.Wrapper.When.ToDateTime();
            }

        }



        public class ThingTypeDefinition
        {
            public string Label;
            public Func<HealthRecordItemCustomBase, JObject> Transformation;
        }

        public static Dictionary<Guid, ThingTypeDefinition> TypeDefinitions = new Dictionary<Guid, ThingTypeDefinition>() {
        {
            typeof(AmbientTemperature).GUID,
            new ThingTypeDefinition {
                Label = "ambientTemperature",
                Transformation = record => new JObject (
                    new JProperty("time", ((AmbientTemperature)record).Time),
                    new JProperty("value", ((AmbientTemperature)record).Value)
                )
            }
        }
    };
    }
}