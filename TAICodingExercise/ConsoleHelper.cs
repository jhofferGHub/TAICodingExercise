namespace TAICodingExercise
{
    public class ConsoleHelper
    {
        public static string GetValidInputFilePath()
        {
            Console.WriteLine("Please enter the input file path including filename and extension.");
            while (true)
            {
                string inPath = @"" + Console.ReadLine();
                if (File.Exists(inPath)) return inPath;
                else Console.WriteLine("Invalid File Path. Please enter a valid file path.");
            }

        }
        public static string GetOuputFolderPath()
        {
            Console.WriteLine("Please enter a valid directory path for the output file.");
            while (true)
            {
                string outPath = @"" + Console.ReadLine();
                try
                {
                    if (!Directory.Exists(outPath)) Directory.CreateDirectory(outPath);
                    return outPath;
                }
                catch (Exception ex) //Catch all possible exceptions creating directory
                {
                    Console.WriteLine("Invalid Directory Path.  Please enter a valid directory path.");
                }
            }
        }
    }
}
