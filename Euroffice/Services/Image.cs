namespace Euroffice.Services
{
    [System.Xml.Serialization.XmlRoot("image")]
    public class Image
    {
        public string url
        {
            get;
            set;
        }
        public string id
        {
            get;
            set;
        }
        public string source_url
        {
            get;
            set;
        }
    }
}
