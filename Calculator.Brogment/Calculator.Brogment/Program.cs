using System.Text.RegularExpressions;
using CalculatorLibrary;

bool endApp = false;
List<double> pastResults = [];
// Display title as the C# console calculator app.
Console.WriteLine("Console Calculator in C#\r");
Console.WriteLine("------------------------\n");


// Program.cs
Calculator calculator = new Calculator();
while (!endApp)
{
    // Declare variables and set to empty.
    // Use Nullable types (with ?) to match type of System.Console.ReadLine
  
    double result = 0;

    Console.WriteLine($"Times calculator used: {pastResults.Count}");

    // Ask the user to type the first number.
    Console.Write("Type a number, and then press Enter: ");
    double cleanNum1 = GetNumericInput();

    // Ask the user to type the second number.
    Console.Write("Type another number, and then press Enter: ");
    double cleanNum2 = GetNumericInput();

    // Ask the user to choose an operator
    Console.WriteLine($"x = {cleanNum1} | y = {cleanNum2}");
    Console.WriteLine("Choose an operator from the following list:");
    Console.WriteLine("\ta - Add");
    Console.WriteLine("\ts - Subtract");
    Console.WriteLine("\tm - Multiply");
    Console.WriteLine("\td - Divide");
    Console.WriteLine("\tr - Take the y Root of x");
    Console.WriteLine("\te - Raise x to the Power of y");

    Console.Write("Your option? ");

    string? op = Console.ReadLine();

    // Validate input is not null, and matches the pattern
    if (op == null || !Regex.IsMatch(op, "[a|s|m|d|r|e]"))
    {
        Console.WriteLine("Error: Unrecognized input.");
    }
    else
    {
        try
        {
            result = calculator.DoOperation(cleanNum1, cleanNum2, op);
            if (double.IsNaN(result))
            {
                Console.WriteLine("This operation will result in a mathematical error.\n");
            }
            else
            {
                Console.WriteLine("Your result: {0:0.##}\n", result);
                pastResults.Add(result);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
        }
    }
    Console.WriteLine("------------------------\n");

    // Wait for the user to respond before closing.
    Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
    if (Console.ReadLine() == "n") endApp = true;

    Console.WriteLine("\n"); // Friendly linespacing.
}

double GetNumericInput()
{
    double cleanNum = 0;
    while (!double.TryParse(Console.ReadLine(), out cleanNum))
    {
        Console.Write("This is not valid input. Please enter a numeric value: ");
    }
    return cleanNum;
}

calculator.Finish();