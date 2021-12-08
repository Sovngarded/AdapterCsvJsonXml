using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersMettlerToledoApp.Adapters;

namespace UsersMettlerToledoApp
{
    class Program
    {
        static string folderPath = @"C:\Users\Admin\Desktop\FileToObjectAdapter-JSON-XML-CSV-\Users\";
        static string jsonFileName = "Books.json";
        static string xmlFileName = "Books.xml";
        static string csvFileName = "Books.csv";

        public static void PrintBooks(FormatAdapter fileAdapter)
        {
            fileAdapter.ReadFromFile();
            Console.WriteLine(fileAdapter.GetBooksInfo());
        }

        public static void ChangeFilePaths()
        {
            Console.WriteLine("введите путь к папке");
            folderPath = Console.ReadLine();

            Console.WriteLine("введите имя файла json");
            jsonFileName = Console.ReadLine();

            Console.WriteLine("введите имя файла xml");
            xmlFileName = Console.ReadLine();

            Console.WriteLine("введите имя файла csv");
            csvFileName = Console.ReadLine();

        }



        static void Main(string[] args)
        {
             

            Console.WriteLine("Если вы хотите ввести другую папку и путь к файлу, введите 1:");
            if(Console.ReadLine()=="1")
            {
                ChangeFilePaths();
            }

            try
            {
                List<FormatAdapter> fileAdapters = new List<FormatAdapter>
            {
                new JsonAdapter(folderPath + jsonFileName),
                new XmlAdapter(folderPath + xmlFileName),
                new CsvAdapter(folderPath + csvFileName)
            };

                foreach (var fileAdapter in fileAdapters)
                {
                    PrintBooks(fileAdapter);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            
            Console.ReadLine();

        }
    }
}
