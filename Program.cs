using System.Text.RegularExpressions;
using System.CommandLine;

class Program
{
    static int Main(string[] args) 
    {
        var filePahtArg = new Argument<string?>(
            name: "--file",
            description: "The input file path (leave empty to use standard input)"
        );

        var countBytesOpt = new Option<bool>(
            name: "-b",
            description: "Count bytes in text file or standard input."
        );

        var countLinesOpt = new Option<bool>(
            name: "-l",
            description: "Count lines in text file or standard input."
        );

        var countWordsOpt = new Option<bool>(
            name: "-w",
            description: "Count words in text file or standard input."
        );

        var countCharsOpt = new Option<bool>(
            name: "-ch",
            description: "Count characters in text file or standard input."
        );


        var rootCommand = new RootCommand
        {
            Description = "Text input analyzer",
        };

        rootCommand.AddArgument(filePahtArg);
        rootCommand.AddOption(countBytesOpt);
        rootCommand.AddOption(countLinesOpt);
        rootCommand.AddOption(countWordsOpt);
        rootCommand.AddOption(countCharsOpt);

        rootCommand.SetHandler(CommandHandler, filePahtArg, countBytesOpt, countLinesOpt, countWordsOpt, countCharsOpt);

        return rootCommand.InvokeAsync(args).Result;

    }

    static void CommandHandler(string filePath, bool b, bool l, bool w, bool ch)
    {
        Console.WriteLine("FILEEEEE : ", filePath);
        // TODO check what the F going on here
        try
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                // TODO dont forget the no option thing
                // file path input
                var inputFile = new FileInfo(filePath);
                HandleFileOptions(filePath, b, l, w, ch, inputFile);
            }
            else if (filePath.StartsWith("-"))
            {
                // standard input
                Console.WriteLine("GHHHHHHHHHHHHHH");
                var inputStream = Console.OpenStandardInput();
                using (var reader = new StreamReader(inputStream))
                {
                    var input = reader.ReadToEnd();
                    HandleStandardInputOptions(b, l, w, ch, input);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e}");
        }
    }

    // **IMPORTANT** duplicated the functions for file input and standard input to preserve the "Do One Thing" principle.

    #region  Statndard Input
    static void HandleStandardInputOptions(bool b, bool l, bool w, bool ch, string input)
    {
        if (b) Console.WriteLine($"{input.Length}");
        if (l) Console.WriteLine($"{GetLinesCountInTextInputByRegex(input)}");
        if (w) Console.WriteLine($"{GetWordsCountInTextInputByRegex(input)}");
        if (ch) Console.WriteLine($"{GetCharsCountInTextInput(input)}");
    }

    static int GetLinesCountInTextInputByRegex(string content)
    {
        var wordRegex = new Regex(@"\n");
        var matches = wordRegex.Matches(content);
        return matches.Count;
    }

    static int GetWordsCountInTextInputByRegex(string content)
    {
        var wordRegex = new Regex(@"\b\w+\b");
        var matches = wordRegex.Matches(content);
        return matches.Count;
    }

    static int GetCharsCountInTextInput(string content)
    {
        return content.Length;
    }
    #endregion

    #region File Input

    static void HandleFileOptions(string filePath, bool b, bool l, bool w, bool ch, FileInfo inputFile)
    {
        if (b) Console.WriteLine($"{inputFile.Length} {inputFile.Name}");
        if (l) Console.WriteLine($"{GetLinesCountInTextFileByRegex(filePath)} {inputFile.Name}");
        if (w) Console.WriteLine($"{GetWordsCountInTextFileByRegex(filePath)} {inputFile.Name}");
        if (ch) Console.WriteLine($"{GetCharsCountInTextFile(filePath)} {inputFile.Name}");
    }

    static int GetLinesCountInTextFileByRegex(string filePath)
    {
        var content = File.ReadAllText(filePath);
        var wordRegex = new Regex(@"\n");
        var matches = wordRegex.Matches(content);
        return matches.Count;
    }

    static int GetWordsCountInTextFileByRegex(string filePath)
    {
        var content = File.ReadAllText(filePath);
        var wordRegex = new Regex(@"\b\w+\b");
        var matches = wordRegex.Matches(content);
        return matches.Count;
    }

    static int GetCharsCountInTextFile(string filePath)
    {
        var content = File.ReadAllText(filePath);
        return content.Length;
    }
    #endregion
}

