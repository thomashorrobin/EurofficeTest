using System;
using System.Collections.Generic;
using System.Xml;

namespace Euroffice.Services
{
	public class CatApiService : ICatApiService
	{
		public List<Category> GetCategories()
		{

			//List<Category> categories = new List<Category>();
   //         XmlDocument xmlDoc = new XmlDocument();
   //         xmlDoc.Load("http://thecatapi.com/api/categories/list");
   //         XmlNodeList x = xmlDoc.DocumentElement.FirstChild.FirstChild.ChildNodes;

   //         foreach (XmlNode node in x)
   //         {
   //             System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Category));
   //             byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(node.OuterXml);
   //             System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

   //             Category category = (Category)xmlSerializer.Deserialize(XmlReader.Create(stream));
			//	categories.Add(category);
   //         }

			//return categories;

			return GetFromXML<Category>("http://thecatapi.com/api/categories/list");
		}

		public List<Image> GetImages(string categoryName){
			
			//List<Image> images = new List<Image>();
   //         XmlDocument xmlDoc = new XmlDocument();
			//xmlDoc.Load("http://thecatapi.com/api/images/get?format=xml&amp;results_per_page=20&amp;category=" + categoryName);
    //        XmlNodeList x = xmlDoc.DocumentElement.FirstChild.FirstChild.ChildNodes;

    //        foreach (XmlNode node in x)
    //        {
				//System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Image));
    //            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(node.OuterXml);
    //            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

				//Image category = (Image)xmlSerializer.Deserialize(XmlReader.Create(stream));
				//images.Add(category);
            //}

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

                T category = (T)xmlSerializer.Deserialize(XmlReader.Create(stream));
				list.Add(category);
            }

			return list;
		}
    }
}
