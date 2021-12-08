using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace UsersMettlerToledoApp
{
    class XmlAdapter : FormatAdapter
    {
        public XmlAdapter(string filePath) : base(filePath)
        {
            FilePath = filePath;
        }

        public override void ReadFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BooksXML));
            BooksXML booksXML;

            using (Stream reader = new FileStream(FilePath, FileMode.Open))
            {
                booksXML = (BooksXML)serializer.Deserialize(reader);                
            }
            SetBooks(booksXML);          
        }


        private void SetBooks(BooksXML booksXML)
        {
            List<Books> books = new List<Books>();

            foreach (var bookXML in booksXML.BooksList)
            {
                books.Add(new Books { Author = bookXML.Author, Name = bookXML.Name, Year = bookXML.Year, Genre= bookXML.Genre, Pages = bookXML.Pages });

            }
            Books = books;

        }         
        
    }
    [XmlRoot("Books")]
    public class BooksXML
    {
        [XmlElement("Book",Type = typeof(BookXML))]
        public List<BookXML> BooksList;
    }

    [XmlRoot("Book")]
    public class BookXML
    {
        [XmlElement]
        public string Author { get; set; }
        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public string Year { get; set; }
        [XmlElement]
        public string Genre { get; set; }
        [XmlElement]
        public string Pages { get; set; }
    }
}
