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

		static void Method02(int[] arr)
		{
			// Call the QuickSort function to sort the entire array
			QuickSort(arr, 0, arr.Length - 1);
		}

		// Recursive QuickSort function to sort the array
		static void QuickSort(int[] arr, int low, int high)
		{
			if (low < high)
			{
				// Partition the array and get the pivot index
				int pivotIndex = Partition(arr, low, high);

				// Recursively sort elements before and after partition
				QuickSort(arr, low, pivotIndex - 1);
				QuickSort(arr, pivotIndex + 1, high);
			}
		}

		// Function to partition the array and return the pivot index
		static int Partition(int[] arr, int low, int high)
		{
			// Choose the last element as the pivot
			int pivot = arr[high];
			int i = low - 1;

			// Rearrange elements based on pivot
			for (int j = low; j < high; j++)
			{
				if (arr[j] < pivot)
				{
					i++;
					// Swap elements at i and j
					int temp = arr[i];
					arr[i] = arr[j];
					arr[j] = temp;
				}
			}

			// Swap the pivot element to its correct position
			int tempPivot = arr[i + 1];
			arr[i + 1] = arr[high];
			arr[high] = tempPivot;

			return i + 1;
		}
	}
}
