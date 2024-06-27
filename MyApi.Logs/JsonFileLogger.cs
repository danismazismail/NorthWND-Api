using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Logs
{
    public class JsonFileLogger<T> : LogBase<T> where T : class
    {
        public JsonFileLogger(string fileName = "yzl8150.json", string filePath = "C:\\")
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        private string _filePath;
        private string _fileName;

        public override void DoLog(T logSubject, DateTime logDate, string logState)
        {
            string serialization = JsonConvert.SerializeObject(new
            {
                Tarih = logDate,
                Durum = logState,
                Bilgi = logSubject
            });
            File.WriteAllText(System.IO.Path.Combine(_filePath, _fileName), serialization);
        }

    }
}
