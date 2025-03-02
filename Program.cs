namespace ConsoleApp6
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
						Console.WriteLine(@"Please press ""y"" to perform another calculation or ""n"" to quit the app:");
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
