using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;

using Microsoft.Health;
using Microsoft.Health.ItemTypes;

namespace HAMS.HV
{
    public static class CustomType
    {
        public static Guid Id = new Guid("a5033c9d-08cf-4204-9bd3-cb412ce39fc0");

        public static string SubtypeTag = "wrapper";

        public static void Register()
        {
            ItemTypeManager.RegisterTypeHandler(Id, typeof(CustomHealthTypeWrapper), true);
        }
    }

    public class HealthRecordItemCustomBase
    {
        protected CustomHealthTypeWrapper wrapper;
        protected HealthServiceDateTime when;

        public CustomHealthTypeWrapper Wrapper
        {
            get { return wrapper; }
            set { wrapper = value; }
        }

        public virtual void ParseXml(XPathNavigator navigator) { }
        public virtual void WriteXml(XmlWriter writer) { }
    }


    public class CustomHealthTypeWrapper : ApplicationSpecific
    {
        const string NullObjectTypeName = "NULLOBJECT";

        private HealthRecordItemCustomBase wrappedObject = null;

        public CustomHealthTypeWrapper() : this(null, new HealthServiceDateTime(DateTime.Now)) { }

        public CustomHealthTypeWrapper(HealthRecordItemCustomBase wrappedInstance, HealthServiceDateTime when)
        {
            wrappedObject = wrappedInstance;
            When = when;

            if (wrappedInstance != null)
            {
                wrappedInstance.Wrapper = this;
            }
        }

        public HealthRecordItemCustomBase WrappedObject
        {
            get { return wrappedObject; }
            set { wrappedObject = value; }
        }

        public override void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("null writer");
            }

            writer.WriteStartElement("app-specific");

            writer.WriteStartElement("format-appid");
            writer.WriteValue("Custom");
            writer.WriteEndElement();

            string wrappedTypeName = NullObjectTypeName;

            if (wrappedObject != null)
            {
                Type type = wrappedObject.GetType();
                wrappedTypeName = type.FullName;
            }

            writer.WriteStartElement("format-tag");
            writer.WriteValue(wrappedTypeName);
            writer.WriteEndElement();

            this.When.WriteXml("when", writer);

            writer.WriteStartElement("summary");
            writer.WriteValue("");
            writer.WriteEndElement();

            if (wrappedObject != null)
            {
                writer.WriteStartElement("CustomType");
                wrappedObject.WriteXml(writer);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        protected override void ParseXml(IXPathNavigable typeSpecificXml)
        {
            XPathNavigator navigator = typeSpecificXml.CreateNavigator();
            navigator = navigator.SelectSingleNode("app-specific");

            if (navigator == null)
            {
                throw new ArgumentNullException("null navigator");
            }

            XPathNavigator when = navigator.SelectSingleNode("when");

            this.When = new HealthServiceDateTime();
            this.When.ParseXml(when);

            XPathNavigator formatAppid = navigator.SelectSingleNode("format-appid");
            string appid = formatAppid.Value;

            XPathNavigator formatTag = navigator.SelectSingleNode("format-tag");
            string wrappedTypeName = formatTag.Value;

            if (wrappedTypeName != NullObjectTypeName)
            {
                wrappedObject = (HealthRecordItemCustomBase)CreateObjectByName(wrappedTypeName);

                if (wrappedObject != null)
                {
                    wrappedObject.Wrapper = this;
                    XPathNavigator customType = navigator.SelectSingleNode("CustomType");

                    if (customType != null)
                    {
                        wrappedObject.ParseXml(customType);
                    }
                }
            }
        }

        public object CreateObjectByName(string typeName)
        {
            Type type = Type.GetType(typeName);
            object o = null;

            if (type != null)
            {
                if (type.BaseType != typeof(HealthRecordItemCustomBase))
                {
                    throw new ApplicationException("Custom type not derived from HealthRecordItemCustomBase");
                }

                o = Activator.CreateInstance(type);
            }

            return o;
        }
    }
}