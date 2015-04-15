using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Health;
using Microsoft.Health.ItemTypes;

using Newtonsoft.Json.Linq;

namespace HAMS.HV
{
    public static class Types
    {
        public class ThingTypeDefinition
        {
            public string Label { get; set; }
            public Func<HealthRecordItem, JObject> Transformation { get; set; }
        }

        public static Dictionary<Guid, ThingTypeDefinition> TypeDefinitions = new Dictionary<Guid, ThingTypeDefinition>() {
        {
            Weight.TypeId,
            new ThingTypeDefinition {
                Label = "weight",
                Transformation = record => new JObject (
                    new JProperty("time", ((Weight)record).When.ToDateTime()),
                    new JProperty("value", ((Weight)record).Value.Value)
                )
            }
        },
        {
            BloodPressure.TypeId,
            new ThingTypeDefinition {
                Label = "bloodPressure",
                Transformation = record => new JObject (
                    new JProperty("time", ((BloodPressure)record).When.ToDateTime()),
                    new JProperty("systolic", ((BloodPressure)record).Systolic),
                    new JProperty("diastolic", ((BloodPressure)record).Diastolic)
                )
            }
        },
        {
            BloodGlucose.TypeId,
            new ThingTypeDefinition {
                Label = "bloodGlucose",
                Transformation = record => new JObject (
                    new JProperty("time", ((BloodGlucose)record).When.ToDateTime()),
                    new JProperty("value", ((BloodGlucose)record).Value)
                )
            }
        },
        {
            CholesterolProfileV2.TypeId,
            new ThingTypeDefinition {
                Label = "cholesterol",
                Transformation = record => new JObject (
                    new JProperty("time", ((CholesterolProfileV2)record).When.ToDateTime()),
                    new JProperty("hdl", ((CholesterolProfileV2)record).LDL.Value),
                    new JProperty("hdl", ((CholesterolProfileV2)record).HDL.Value),
                    new JProperty("total", ((CholesterolProfileV2)record).TotalCholesterol.Value)
                )
            }
        }
    };
    }
}