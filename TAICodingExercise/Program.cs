//using CsvHelper;
//using System.Globalization;
//using System.Net;
//using System.Net.Http.Headers;
//using System.Text;
using TAICodingExercise;
using TAICodingExercise.DTO;

//Define threshold
const decimal RiskThreshold = 300000.00M;

//Get File Input Location from user
string inputFilePath = ConsoleHelper.GetValidInputFilePath();

//Read data from provided input (CSV) File
List<Insured> insuredList = new FileReader().ReadInsuredData(inputFilePath);  

//Sort & Filter List for Export
List<Insured> outputList = new InsuredProcessor().FilterInsuredList(insuredList, RiskThreshold);

//Get Output Folder Location from user
string exportDirectory = ConsoleHelper.GetOuputFolderPath();

//Write Ouput file and add closing remarks to user
string exportedFilePath = new FileWriter().WriteResultCsv(outputList,exportDirectory);
Console.WriteLine($"The results have been saved to {exportedFilePath}.  Have a great day!");


