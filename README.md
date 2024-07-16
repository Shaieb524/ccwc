
# CCWC Project

## Overview

The CCWC project is a command-line application written in C# that analyzes text input from a file or standard input. The application provides options to count bytes, lines, words, and characters in the text input.

## Project Structure

- **ccwc.sln**: The solution file for the project.
- **ccwc.csproj**: The project file containing project-specific configurations and dependencies.
- **Program.cs**: The main entry point for the application containing the logic for text analysis.
- **.gitignore**: Specifies files and directories that should be ignored by Git.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) version 5.0 or later.

## Getting Started

### Cloning the Repository

Clone the repository to your local machine using Git:

```bash
git clone https://github.com/yourusername/ccwc.git
cd ccwc
```

### Building the Project

Navigate to the project directory and build the solution:

```bash
dotnet build ccwc.sln
```

### Running the Application

Run the application using the following command:

```bash
dotnet run --project ccwc -- --file <file-path> [-b] [-l] [-w] [-ch]
```

### Command Line Options

- `--file <file-path>`: Specifies the input file path (leave empty to use standard input).
- `-b`: Count bytes in the text input.
- `-l`: Count lines in the text input.
- `-w`: Count words in the text input.
- `-ch`: Count characters in the text input.

### Examples

1. **Count bytes in a file**:
   ```bash
   dotnet run --project ccwc -- --file example.txt -b
   ```

2. **Count lines in a file**:
   ```bash
   dotnet run --project ccwc -- --file example.txt -l
   ```

3. **Count words in a file**:
   ```bash
   dotnet run --project ccwc -- --file example.txt -w
   ```

4. **Count characters in a file**:
   ```bash
   dotnet run --project ccwc -- --file example.txt -ch
   ```

5. **Use standard input**:
   ```bash
   echo "Hello World" | dotnet run --project ccwc -- -w
   ```


