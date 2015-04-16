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
            public bool Persistent { get; set; }
        }

        public static Dictionary<Guid, ThingTypeDefinition> TypeDefinitions = new Dictionary<Guid, ThingTypeDefinition>() {
        {
            Weight.TypeId,
            new ThingTypeDefinition {
                Label = "weight",
                Transformation = record => new JObject (
                    new JProperty("time", ((Weight)record).When.ToDateTime()),
                    new JProperty("value", ((Weight)record).Value.Value)
                ),
                Persistent = false
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
                ),
                Persistent = false
            }
        },
        {
            BloodGlucose.TypeId,
            new ThingTypeDefinition {
                Label = "bloodGlucose",
                Transformation = record => new JObject (
                    new JProperty("time", ((BloodGlucose)record).When.ToDateTime()),
                    new JProperty("value", (Math.Round(((BloodGlucose)record).Value.Value * 18, 0)))
                ),
                Persistent = false
            }
        },
        {
            CholesterolProfileV2.TypeId,
            new ThingTypeDefinition {
                Label = "cholesterol",
                Transformation = record => new JObject (
                    new JProperty("time", ((CholesterolProfileV2)record).When.ToDateTime()),
                    new JProperty("ldl", (Math.Round(((CholesterolProfileV2)record).LDL.Value * 38.66976, 0))),
                    new JProperty("hdl", (Math.Round(((CholesterolProfileV2)record).HDL.Value * 38.66976, 0))),
                    new JProperty("total", (Math.Round(((CholesterolProfileV2)record).TotalCholesterol.Value * 38.66976, 0)))
                ),
                Persistent = false
            }
        },
        {
            Allergy.TypeId,
            new ThingTypeDefinition {
                Label = "allergies",
                Transformation = record => new JObject (
                    new JProperty("text", ((Allergy)record).AllergenType + " - " + ((Allergy)record).Name)
                ),
                Persistent = true
            }
        },
        {
            Condition.TypeId,
            new ThingTypeDefinition {
                Label = "conditions",
                Transformation = record => new JObject (
                    new JProperty("text", (
                        String.Format("{0}/{1}/{2}", 
                            ((Condition)record).OnsetDate.ApproximateDate.Day,
                            ((Condition)record).OnsetDate.ApproximateDate.Month,
                            ((Condition)record).OnsetDate.ApproximateDate.Year
                        ) + ": " + ((Condition)record).Name))
                ),
                Persistent = true
            }
        },
        {
            Medication.TypeId,
            new ThingTypeDefinition {
                Label = "medications",
                Transformation = record => new JObject (
                    new JProperty("text", (
                        String.Format("{0}/{1}/{2}", 
                            ((Medication)record).DateStarted.ApproximateDate.Day,
                            ((Medication)record).DateStarted.ApproximateDate.Month,
                            ((Medication)record).DateStarted.ApproximateDate.Year
                        ) + ": " + ((Medication)record).Name))
                ),
                Persistent = true
            }
        }
        };
    }
}