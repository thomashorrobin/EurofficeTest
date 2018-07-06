using System;
using System.Collections.Generic;
using System.Xml;

namespace Euroffice.Services
{
	public class CatApiService : ICatApiService
	{
		public List<Category> GetCategories()
		{         
			return GetFromXML<Category>("http://thecatapi.com/api/categories/list");
		}

		public List<Image> GetImages(string categoryName)
		{
			return GetFromXML<Image>("http://thecatapi.com/api/images/get?format=xml&amp;results_per_page=20&amp;category=" + categoryName);
		}

		private List<T> GetFromXML<T>(string uri)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(uri);
			XmlNodeList x = xmlDoc.DocumentElement.FirstChild.FirstChild.ChildNodes;

			var list = new List<T>();

			foreach (XmlNode node in x)
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(node.OuterXml);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

				T item = (T)xmlSerializer.Deserialize(XmlReader.Create(stream));
				list.Add(item);
            }

			return list;
		}
    }
}
