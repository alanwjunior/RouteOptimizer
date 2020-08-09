using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using TravelRouteOptimizer.Utils.Mappers;

namespace TravelRouteOptimizer.Utils
{
    public class CsvUtils<T> where T: class
    {
        public CsvUtils()
        {
        }
        public List<T> ReadCsvFile(string csvPath)
        {
            try
            {
                using (var reader = new StreamReader(String.Concat("data/", csvPath), Encoding.Default))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<T>().ToList<T>();
                        return records;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AppendData(string csvPath, List<T> records)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture);
                config.HasHeaderRecord = false;
                using (var writer = new StreamWriter(String.Concat("data/", csvPath), true))
                {
                    using (var csv = new CsvWriter(writer, config))
                    {
                        csv.WriteRecords(records);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
