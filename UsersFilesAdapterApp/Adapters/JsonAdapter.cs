using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UsersMettlerToledoApp
{
    class JsonAdapter : FormatAdapter
    {
        public JsonAdapter(string filePath) : base(filePath)
        {
            FilePath = filePath;
        }
        public override void ReadFromFile()
        {
                string JsonString = File.ReadAllText(FilePath);

                Books = JsonSerializer.Deserialize<List<Books>>(JsonString);                 
        }

     
    }
}
