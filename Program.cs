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
                    Stream inputStream = Console.OpenStandardInput();
                    using (StreamReader reader = new StreamReader(inputStream))
                    {
                        string input = reader.ReadToEnd();
                        HanldeOptionsForTextInput(args, input);
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
                HanldeOptionsForTextFile(args);  
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

    // Duplicate functions for file input and standard input to preserve the "Do One Thing" principle.
    #region Standard Input
    static void HanldeOptionsForTextInput(string[] args, string standardInput)
    {
        var cmdOption = args[0].ToLower();

        switch (cmdOption)
        {
            case "-cc":
                Console.WriteLine($"{standardInput.Length}");
                break;
            
            case "-l":
                Console.WriteLine($"{GetLinesCountInTextInputByRegex(standardInput)}");
                break;

            case "-w":
                Console.WriteLine($"{GetWordsCountInTextInputByRegex(standardInput)}");
                break;
            case "-m":
                Console.WriteLine($"{GetCharsCountInTextInput(standardInput)}");
                break;

            default:
                break;
        }
    }

    static int GetLinesCountInTextInputByRegex(string content)
    {
        Regex wordRegex = new Regex(@"\n");
        MatchCollection matches = wordRegex.Matches(content);

        return matches.Count;
    }

    static int GetWordsCountInTextInputByRegex(string content)
    {
        // a word is a sequence of one character or more (\w+) between two boundaries (\b)
        Regex wordRegex = new Regex(@"\b\w+\b");
        MatchCollection matches = wordRegex.Matches(content);

        return matches.Count;
    }

    static int GetCharsCountInTextInput(string content)
    {
        return content.Length;
    }
    #endregion

    #region File Input
    static void HanldeOptionsForTextFile(string[] args)
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
    #endregion
}

