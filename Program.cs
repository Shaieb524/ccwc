public class Program
{
    public static void Main(string[] args) 
    {
        try 
        {
            var cmdOption = args[0].ToLower();
            var inputFilePath = args[1];

            var inputFile = new FileInfo(inputFilePath);


            switch (cmdOption)
            {
                case "-cc":
                    Console.WriteLine($"{inputFile.Length} {inputFile.Name}");
                    break;
                
                case "-l":
                    Console.WriteLine($"{File.ReadAllLines(inputFilePath).Count()} {inputFile.Name}");
                    break;
            
            }
        } 
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Please make sure to provide option and file path with the command input");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e}");
        }
        
    } 

}

