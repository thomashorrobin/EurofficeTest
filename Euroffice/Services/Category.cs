namespace Euroffice.Services
{
    [System.Xml.Serialization.XmlRoot("category")]
    public class Category
    {
        public int id
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }
    }
}
