using CsvHelper;
using CsvHelper.Configuration;

//using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
using TAICodingExercise.DTO;

namespace TAICodingExercise
{
    public class FileReader
    {
        public List<Insured> ReadInsuredData(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //Provide mappings for Insured and Policy objects
                csv.Context.RegisterClassMap<InsuredReadMap>();
                csv.Context.RegisterClassMap<PolicyReadMap>();

                List<Insured> result = new List<Insured>();
                var isHeader = true;
                int csvLine = 0;
                while (csv.Read())
                {
                    csvLine++;
                    if (isHeader)
                    {
                        csv.ReadHeader();
                        isHeader = false;
                        continue;
                    }
                    try
                    {
                        Insured ins = csv.GetRecord<Insured>(); //Get data for Insured
                        Policy p = csv.GetRecord<Policy>(); //Get data for Policy

                        //Validate Data based on Annotations 
                        List<ValidationResult> insuredErrorResults = null;
                        List<ValidationResult> policyErrorResults = null;
                        if (!Validate(ins, out insuredErrorResults) | !Validate(p, out policyErrorResults))
                        {
                            Console.WriteLine($"Input File failed data validation on Line #{csvLine}. This line will be omitted from processing.");
                            Console.WriteLine(String.Join("\n", insuredErrorResults.Select(o => o.ErrorMessage)));
                            Console.WriteLine(String.Join("\n", policyErrorResults.Select(o => o.ErrorMessage)));
                            continue;
                        }

                        //Add Insured and/or Policy to result list
                        Insured? update = result.FirstOrDefault(x => x.ID == ins.ID && x.LastName == ins.LastName && x.FirstName == ins.FirstName && x.Gender == ins.Gender && x.DateOfBirth == ins.DateOfBirth);
                        //Check to see if this Insured does not exist yet in result list
                        if (update == null)
                        {
                            ins.AddPolicy(p);
                            result.Add(ins);
                        }
                        //Insured already exists so just add the policy to the existing record rather than adding Insured again
                        else update.AddPolicy(p);
                    }
                    //Unhandled Exceptions
                    //ToDo:Implement better handling of these errors.
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Input File failed data validation on Line #{csvLine}. This line will be omitted from processing.");
                        Console.WriteLine($"Malformed data in row.  It is likely missing a comma separator or has an invalid data type.");
                        continue;

                    }
                }

                return result;
            }
        }
        public bool Validate<T>(T obj, out List<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
