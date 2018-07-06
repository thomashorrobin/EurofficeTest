using System;
using System.Collections.Generic;
using System.Xml;

namespace Euroffice.Services
{
    public class CatApiService : ICatApiService
	{
		public List<Category> GetCategories()
		{

			List<Category> categories = new List<Category>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://thecatapi.com/api/categories/list");
            XmlNodeList x = xmlDoc.DocumentElement.FirstChild.FirstChild.ChildNodes;

            foreach (XmlNode node in x)
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Category));
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(node.OuterXml);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

                Category category = (Category)xmlSerializer.Deserialize(XmlReader.Create(stream));
				categories.Add(category);
            }

			return categories;
		}

		public List<Image> GetImages(string categoryName){
			
			List<Image> images = new List<Image>();
            XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load("http://thecatapi.com/api/images/get?format=xml&amp;results_per_page=20&amp;category=" + categoryName);
            XmlNodeList x = xmlDoc.DocumentElement.FirstChild.FirstChild.ChildNodes;

            foreach (XmlNode node in x)
            {
				System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Image));
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(node.OuterXml);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

				Image category = (Image)xmlSerializer.Deserialize(XmlReader.Create(stream));
				images.Add(category);
            }

			return images;
		}
    }
   
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
