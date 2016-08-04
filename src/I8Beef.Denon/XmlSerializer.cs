using System.IO;
using System.Text;
using System.Xml;

namespace I8Beef.Denon
{
    public static class XmlSerializer<TType> where TType : class
    {
        /// <summary>
        /// Serializes an object to XML
        /// </summary>
        public static string Serialize(TType instance)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TType));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false);
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, instance);
                }

                return textWriter.ToString();
            }
        }

        /// <summary>
        /// DeSerializes an object from XML
        /// </summary>
        public static TType Deserialize(string json)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TType));

                return serializer.Deserialize(stream) as TType;
            }
        }
    }
}
