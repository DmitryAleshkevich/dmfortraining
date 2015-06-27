using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DALClassLibrary.DAL;

namespace BLClassLibrary
{
    class FileAnalyser
    {
        private readonly SellsRepository _sells = new SellsRepository();

        public async Task ParseFile(string filePath, string fileName)
        {
            try
            {
                using (var reader = (StreamReader)TextReader.Synchronized(new StreamReader(filePath)))
                {
                    string line;
                    var nameManager = Regex.Split(fileName, @"_");
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        var data = Regex.Split(line,@";");
                        CreateSell(data, nameManager[0]);
                    }
                    _sells.SaveSells();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Coudn`t read file {0}, because of {1}",filePath,exception.Message);
            }               
        }

        private void CreateSell(string[] dataStrings, string nameManager)
        {
            var date = Convert.ToDateTime(dataStrings[0]);
            var client = new Client(dataStrings[1],null);
            var good = new Good(dataStrings[2],"");
            var sum = (float)Convert.ToDouble(dataStrings[3]);
            var manager = new Manager(nameManager);
            _sells.Add(new Sell(date,client,good,manager,sum));
        }
    }
}
