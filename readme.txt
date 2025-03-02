# Hello, Calculator!

In this tutorial, you will learn how to create a simple command-line calculator application using C#. This program will handle basic arithmetic operations: addition, subtraction, multiplication, and division on two decimal numbers. We will guide you step by step, from setting up the project to writing the code and building the application.


## You will need

- Microsoft Visual Studio (this guide is based on version 2022). As an individual developer, you can use a free Visual Studio Community Edition.
- Basic knowledge of C# (this tutorial assumes you are already familiar with fundamental concepts).
- 15–20 minutes of spare time.

## Creating the project

1. Open Microsoft Visual Studio.
2. From the **File** menu, click **New**, and then click **Project...**.
3. Select _C# Console App_ template and click **Next**.
4. Enter the project name (for example, _MyFirstCalculator_) and choose a folder where the project will be placed. Click **Next** to continue.
5. Select the version of the .NET framework, and ensure that the **Do not use top-level statements** option is selected (this allows you to see the full code).
6. Click **Create** create the project.

## Writing the code

Let's start by coding the basic mathematical operations.

While it is possible to embed these operations directly into the main calculation method (which we will cover later in this article), we will define a separate method for each operation. This will improve the readability of the code and allow for adding extra logic / functionality in the future.

```csharp
private static double Add(double x, double y)
{
	return x + y;
}

private static double Subtract(double x, double y)
{
	return x - y;
}

private static double Multiply(double x, double y)
{
	return x * y;
}

private static double Divide(double x, double y)
{
	return x / y;
}
```

That's it! These methods are quite self-explanatory, so it should be easy to understand the functionality of each one.

Now, let's move on to the most important part: the method that collects user input and performs the calculation. Since the calculator will allow users to perform multiple consecutive operations, we will place this code in a separate method rather than putting everything in the `Main` method.

```csharp
private static double Calc()
{
	// Declare variables
	double n1, n2;
	string op;
	// Parse user input
	// First operand
	Console.WriteLine("Enter the first number:");
	while(true)
	{
		if(double.TryParse(Console.ReadLine(), out n1)) break;
		else Console.WriteLine("Please enter a valid decimal number for the first operand:");
	}
	// Operator
	Console.WriteLine("Enter the operator (+, -, *, /):");
	while(true)
	{
		op = Console.ReadLine().Trim();
		if(op == "+" || op == "-" || op == "*" || op == "/") break;
		else Console.WriteLine("Please enter a supported operator (+, -, *, /):");
	}
	// Second operand
	Console.WriteLine("Enter the second number:");
	while(true)
	{
		if(double.TryParse(Console.ReadLine(), out n2)) break;
		else Console.WriteLine("Please enter a valid decimal number for the second operand:");
	}
	// Perform calculation
	switch(op)
	{
		case "+": return Add(n1, n2);
		case "-": return Subtract(n1, n2);
		case "*": return Multiply(n1, n2);
		case "/": return Divide(n1, n2);
		default: throw new Exception("Unhandled operation");
	}
}
```

The `Calc` method begins by declaring two numeric variables to capture the operands (`n1` and `n2`) and a string variable for the operator (`op`). This setup will allow the program to store the parameters of the mathematical operation.

Next, we will grab the user input from the console using the standard `Console.ReadLine()` method:

- First operand (decimal number)
- Operator of one of the supported types (+, -, \*, /)
- Second operand (decimal number)

To make our calculator more user-friendly, we need to handle basic input errors instead of throwing an exception. This can be done by attempting to parse the user input for each parameter inside a loop (`while(true){ ... }`). The loop will continue until the user enters a valid value. If the input is incorrect/unsupported, the program will prompt the user to re-enter the value in the next iteration. The loop will exit (using the `break` statement) once a valid input is provided.

**Warning!** Be very careful when using infinite loops (`while(true){ ... }`) in your code. If you do not explicitly break the loop, your program will run indefinitely, causing it to hang or become unresponsive. Always ensure that there is a valid condition to exit the loop, such as a `break` or `return` statement when the user provides correct input.

Now that we have all the elements of the equation, we can perform the calculation by calling one of the basic math methods created earlier. The appropriate method is selected using a `switch` statement, which compares the operator entered by the user (`op` variable) with one of the predefined values.

The result of the calculation (in `double` format) is then returned from the method as a return value.

Now that we have all the required code in place, let's modify the core of the program - the `Main` method. The `Main` method should already be present in your code when you created the project in Visual Studio. Simply modify the code inside it without altering the method declaration.

```csharp
public static void Main(string[] args)
{
	while(true)
	{
		// Perform calculation
		double result = Calc();
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine($"Result: {result}");
		Console.ResetColor();
		// Ask user if they want to continue
		Console.WriteLine("Perform another calculation? (y/n)");
		while(true)
		{
			char input = char.ToLowerInvariant(Console.ReadKey().KeyChar);
			if(input == 'y')
			{
				Console.Clear();
				break;
			}
			else if(input == 'n') return;
			else
			{
				Console.WriteLine("");
				Console.WriteLine(@"Please press ""y"" to perforem another calculation or ""n"" to quit the app:");
			}
		}
	}
}
```

Since we do not want the application to close after each calculation, we will use the same infinite loop technique (`while(true){ ... }`) we applied when verifying the input parameters. This will allow the program to keep running, enabling the user to perform multiple calculations without restarting the application. The loop will continue until the user decides to exit by pressing the **n** key.

The calculation is performed by calling the `Calc` method described earlier in this article. Once the result is obtained, it is output to the console in green (`Console.ForegroundColor = ConsoleColor.Green;`) to make it stand out.

After displaying the result, we prompt the user to decide whether they want to perform another calculation or quit. To improve the user experience, we use `Console.ReadKey()` to capture the user's input immediately, so they do not have to press _Enter_ after entering the response.

The user input is then compared case-insensitively (`char.ToLowerInvariant(Console.ReadKey().KeyChar)`) with one of the predefined values:

- `y` - the console is cleared (`Console.Clear()`) and the `Calc` method is called again in the next iteration.
- `n` - the program exits the loop and terminates (`return;`).

If any other key is pressed, the user will be prompted to press the correct key (y or n): `Console.WriteLine(@"Please press ""y"" to perforem another calculation or ""n"" to quit the app:");`

### Full code

```csharp
namespace MyFirstCalculator
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			while(true)
			{
				// Perform calculation
				double result = Calc();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"Result: {result}");
				Console.ResetColor();
				// Ask user if they want to continue
				Console.WriteLine("Perform another calculation? (y/n)");
				while(true)
				{
					char input = char.ToLowerInvariant(Console.ReadKey().KeyChar);
					if(input == 'y')
					{
						Console.Clear();
						break;
					}
					else if(input == 'n') return;
					else
					{
						Console.WriteLine("");
						Console.WriteLine(@"Please press ""y"" to perforem another calculation or ""n"" to quit the app:");
					}
				}
			}
		}

		private static double Calc()
		{
			// Declare variables
			double n1, n2;
			string op;
			// Parse user input
			Console.WriteLine("Enter the first number:");
			while(true)
			{
				if(double.TryParse(Console.ReadLine(), out n1)) break;
				else Console.WriteLine("Please enter a valid decimal number for the first operand:");
			}
			Console.WriteLine("Enter the operator (+, -, *, /):");
			while(true)
			{
				op = Console.ReadLine().Trim();
				if(op == "+" || op == "-" || op == "*" || op == "/") break;
				else Console.WriteLine("Please enter a supported operator (+, -, *, /):");
			}
			Console.WriteLine("Enter the second number:");
			while(true)
			{
				if(double.TryParse(Console.ReadLine(), out n2)) break;
				else Console.WriteLine("Please enter a valid decimal number for the second operand:");
			}
			// Perform calculation
			switch(op)
			{
				case "+": return Add(n1, n2);
				case "-": return Subtract(n1, n2);
				case "*": return Multiply(n1, n2);
				case "/": return Divide(n1, n2);
				default: throw new Exception("Unhandled operation");
			}
		}

		private static double Add(double x, double y)
		{
			return x + y;
		}

		private static double Subtract(double x, double y)
		{
			return x - y;
		}

		private static double Multiply(double x, double y)
		{
			return x * y;
		}

		private static double Divide(double x, double y)
		{
			return x / y;
		}
	}
}
```

## Running the app

Simply press **F5** to build the app. Enjoy!
