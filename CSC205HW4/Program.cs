using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC205HW4
{
	class Program
	{
		static void Main(string[] args)
		{
			// Define the file name where the numbers will be saved
			string fileName = "numbers.txt";
			// Create a Stopwatch instance to measure the time taken for sorting
			Stopwatch stopwatch = new Stopwatch();
			// Generate a file with random numbers
			Method01(fileName, 1000, 1, 1001);
			// Read all lines from the generated file into an array of strings
			string[] lines = File.ReadAllLines(fileName);
			// Convert the array of strings to an array of integers
			int[] values = new int[lines.Length];
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = Convert.ToInt32(lines[i]);
			}

			// Start the stopwatch to measure sorting time
			stopwatch.Start();
			Console.WriteLine("starting ... ");
			// Sort the array of integers
			Method02(values);
			Console.WriteLine("done! ... ");
			// Stop the stopwatch after sorting
			stopwatch.Stop();
			// Print the time taken for sorting
			Console.WriteLine("time measured: {0} ms", stopwatch.ElapsedMilliseconds);
			// Print the sorted array
			foreach (int value in values)
				Console.Write(value + " ");
			Console.WriteLine();
		}

		// Method to generate a file with random integers
		static void Method01(string fileName, int total, int lowerRange, int upperRange)
		{
			// Create a StreamWriter to write to the specified file
			using (var writer = new StreamWriter(fileName))
			{
				// Create a Random object to generate random numbers
				Random r = new Random();
				int number = 0;
				{
					// Loop to generate the specified number of random integers
					// Note: We generate total - 1 numbers since the loop starts at 1
					for (int i = 1; i < total; i++)
					{
						// Generate a random integer within the specified range
						number = r.Next(lowerRange, upperRange);
						// Write the number to the file
						writer.WriteLine(number);
					}
				}
			}
			// The StreamWriter is automatically closed and disposed of when exiting the using block
		}

		// Method to sort an array of integers using the selection sort algorithm
		static void Method02(int[] arr)
		{
			// Loop through each element in the array
			for (int start = 0; start < arr.Length - 1; start++)
			{
				// Assume the current position is the minimum
				int posMin = start;
				// Find the minimum element in the unsorted portion of the array
				for (int i = start + 1; i < arr.Length; i++)
				{
					if (arr[i] < arr[posMin])
					{
						posMin = i;
					}
				}
				// Swap the found minimum element with the element at the start position
				int tmp = arr[start];
				arr[start] = arr[posMin];
				arr[posMin] = tmp;
			}
		}
	}
}
