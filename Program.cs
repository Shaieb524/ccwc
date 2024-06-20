using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args) 
    {
        try 
        {
            string inputFilePath;
            FileInfo inputFile;

            if  (args.Length == 1)
            {
                var firstArg = args[0];

                if (firstArg.StartsWith("-"))
                {
                    // file name not passed
                    // TODO process from piped standard input
                    string s;
                    while ((s = Console.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
                else 
                {
                    // option not passed
                    inputFilePath = firstArg;
                    inputFile = new FileInfo(inputFilePath);
                    Console.WriteLine($"{GetLinesCountInTextFileByRegex(inputFilePath)} {GetWordsCountInTextFileByRegex(inputFilePath)} {GetCharsCountInTextFile(inputFilePath)} {inputFile.Name}");
                }
            }
            else 
            {
                HanldeOptions(args);  
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

    static void HanldeOptions(string[] args)
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
                Console.WriteLine($"{GetLinesCountInTextFileByRegex(inputFilePath)} {inputFile.Name}");
                break;

            case "-w":
                Console.WriteLine($"{GetWordsCountInTextFileByRegex(inputFilePath)} {inputFile.Name}");
                break;
            case "-m":
                Console.WriteLine($"{GetCharsCountInTextFile(inputFilePath)} {inputFile.Name}");
                break;

            default:
                break;
        }
    }

    static int GetLinesCountInTextFileByRegex(string filePath)
    {
        var content = File.ReadAllText(filePath);
        Regex wordRegex = new Regex(@"\n");
        MatchCollection matches = wordRegex.Matches(content);

        return matches.Count;
    }

    //TODO check why it is not accurate
    static int GetWordsCountInTextFileByRegex(string filePath)
    {
        var content = File.ReadAllText(filePath);
        // a word is a sequence of one character or more (\w+) between two boundaries (\b)
        Regex wordRegex = new Regex(@"\b\w+\b");
        MatchCollection matches = wordRegex.Matches(content);

        return matches.Count;
    }

    static int GetCharsCountInTextFile(string filePath)
    {
        string content = File.ReadAllText(filePath);
        return content.Length;
    }
}

