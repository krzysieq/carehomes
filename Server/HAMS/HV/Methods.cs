using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

using Microsoft.Health;
using Microsoft.Health.Web;
using Microsoft.Health.ItemTypes;
using Microsoft.Health.PatientConnect;

using Newtonsoft.Json.Linq;

using HAMS.Models;

namespace HAMS.HV
{
    public static class Methods
    {
        public static JObject GetAllThings(Guid personId, Guid recordId)
        {
            Guid appId = new Guid(Connections.ApplicationId);
            OfflineWebApplicationConnection connection = Connections.CreateConnection(appId, personId);

            HealthRecordAccessor accessor = new HealthRecordAccessor(connection, recordId);
            HealthRecordSearcher searcher = new HealthRecordSearcher(accessor);

            List<Guid> queryOrder = Types.TypeDefinitions.Keys.ToList();
            queryOrder.Add(CustomType.Id);

            foreach (Guid thingType in queryOrder)
            {
                HealthRecordFilter filter = new HealthRecordFilter(thingType);
                if (Types.TypeDefinitions.ContainsKey(thingType) && !Types.TypeDefinitions[thingType].Persistent)
                {
                    filter.EffectiveDateMin = GetMinTime();
                }
                searcher.Filters.Add(filter);
            }

            ReadOnlyCollection<HealthRecordItemCollection> things = searcher.GetMatchingItems();

            return TransformThings(things, queryOrder);
        }

        private static JObject TransformThings(ReadOnlyCollection<HealthRecordItemCollection> things, List<Guid> queryOrder)
        {
            JObject output = new JObject();

            HealthRecordItemCollection thingCollection;
            Guid typeId;
            Types.ThingTypeDefinition hvTypeDefinition;
            EnvTypes.ThingTypeDefinition envTypeDefinition;

            for (int i = 0; i < queryOrder.Count; i++)
            {
                thingCollection = things[i];
                thingCollection.Sort(CompareByTimeAscending);
                typeId = queryOrder[i];

                if (typeId == CustomType.Id) // custom type
                {
                    foreach (CustomHealthTypeWrapper wrapper in thingCollection)
                    {
                        HealthRecordItemCustomBase item = wrapper.WrappedObject;

                        if (item == null)
                        {
                            continue;
                        }

                        envTypeDefinition = EnvTypes.TypeDefinitions[item.GetType().GUID];

                        if (output[envTypeDefinition.Label] == null)
                        {
                            output[envTypeDefinition.Label] = new JArray();
                        }

                        ((JArray)output[envTypeDefinition.Label]).Add(envTypeDefinition.Transformation(item));
                    }
                }
                else // HV standard type
                {
                    hvTypeDefinition = Types.TypeDefinitions[typeId];

                    JArray recordArray = new JArray();

                    foreach (HealthRecordItem item in thingCollection)
                    {
                        recordArray.Add(hvTypeDefinition.Transformation(item));
                    }

                    output[hvTypeDefinition.Label] = recordArray;
                }
            }

            return output;
        }

        public static void PostCustomThing(HealthRecordItemCustomBase thing, HealthServiceDateTime when,
            Guid personId, Guid recordId)
        {
            CustomHealthTypeWrapper wrapper = new CustomHealthTypeWrapper(thing, when);
            wrapper.When = when;

            PostThing(wrapper, personId, recordId);
        }

        public static void PostThing(HealthRecordItem thing, Guid personId, Guid recordId)
        {
            Guid appId = new Guid(Connections.ApplicationId);
            OfflineWebApplicationConnection connection = Connections.CreateConnection(appId, personId);

            HealthRecordAccessor accessor = new HealthRecordAccessor(connection, recordId);

            accessor.NewItem(thing);
        }

        public static void PurgeCustomData(Guid personId, Guid recordId)
        {
            Guid appId = new Guid(Connections.ApplicationId);
            OfflineWebApplicationConnection connection = Connections.CreateConnection(appId, personId);

            HealthRecordAccessor accessor = new HealthRecordAccessor(connection, recordId);

            foreach (ApplicationSpecific item in accessor.GetItemsByType(ApplicationSpecific.TypeId))
            {
                accessor.RemoveItem(item);
            }
        }

        public static DateTime GetMinTime()
        {
            return DateTime.Now.AddDays(-210);
        }

        public static int CompareByTimeAscending(HealthRecordItem a, HealthRecordItem b)
        {
            if (a.EffectiveDate < b.EffectiveDate)
            {
                return -1;
            }
            else if (a.EffectiveDate > b.EffectiveDate)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static void CheckForValidatedConnections()
        {
            Collection<ValidatedPatientConnection> connectionList = Connections.GetValidatedConnectionsInPastDays(0);
            using (var db = new HAMSContext())
            {
                try
                {
                    // reset connections
                    foreach (Participant participant in db.Participants)
                    {
                        participant.Activated = false;
                        participant.HVPersonId = null;
                        participant.HVRecordId = null;
                    }

                    // add validated connections
                    foreach (ValidatedPatientConnection connection in connectionList)
                    {
                        Guid participantId = Guid.Parse(connection.ApplicationPatientId);
                        Participant participant = db.Participants.Find(participantId);
                        if (participant == null || participant.Activated)
                        {
                            continue;
                        }
                        participant.Activated = true;
                        participant.HVPersonId = connection.PersonId;
                        participant.HVRecordId = connection.RecordId;
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: Unable to update Participants information: " + ex.Message.ToString(), ex);
                }
            }
        }
    }
}