using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersMettlerToledoApp
{
    abstract class FormatAdapter
    {
        public string FilePath { get; protected set; }
        public FormatAdapter(string filePath)
        {
            FilePath = filePath;
        }

        public List<Books> Books
        {
            get;
            protected set;
        }

        public string GetBooksInfo()
        {
            if(Books==null)
            {
                return "Файл пуст";
            }


         
            StringBuilder strBuilder = new StringBuilder();
            foreach (var book in Books)
            {
                strBuilder.AppendLine();
                strBuilder.Append(book.Author + " " + book.Name + " " + book.Year+" "+ book.Genre+" "+ book.Pages);
            }

            string bookInfo = strBuilder.ToString();

            return bookInfo;
        }
        public abstract void ReadFromFile();
    }
}
