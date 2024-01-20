using CsvHelper;
//using System;
//using System.Collections.Generic;
using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using TAICodingExercise.DTO;

namespace TAICodingExercise
{
    public class FileWriter
    {
        public string WriteResultCsv(List<Insured> insuredList, string directoryPath)
        {
            string filePath = Path.Combine(directoryPath, $"ExceededThreshold_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv");
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<InsuredWriteMap>();
                csv.WriteHeader<Insured>();
                csv.NextRecord();
                csv.WriteRecords(insuredList);
            }
            return filePath;
        }
    }
}
