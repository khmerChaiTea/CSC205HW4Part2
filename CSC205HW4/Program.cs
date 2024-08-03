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
			// Call the MergeSort function to sort the entire array
			MergeSort(arr, 0, arr.Length - 1);
		}

		// Recursive MergeSort function to sort the array
		static void MergeSort(int[] arr, int left, int right)
		{
			// Base case: if the array has one or zero elements, it's already sorted
			if (left < right)
			{
				// Find the middle point
				int mid = (left + right) / 2;

				// Recursively sort the first half
				MergeSort(arr, left, mid);

				// Recursively sort the second half
				MergeSort(arr, mid + 1, right);

				// Merge the two sorted halves
				Merge(arr, left, mid, right);
			}
		}

		// Function to merge two sorted halves of the array
		static void Merge(int[] arr, int left, int mid, int right)
		{
			// Find the sizes of the two subarrays to be merged
			int n1 = mid - left + 1;
			int n2 = right - mid;

			// Create temporary arrays to hold the subarrays
			int[] L = new int[n1];
			int[] R = new int[n2];

			// Copy data to temporary arrays L[] and R[]
			Array.Copy(arr, left, L, 0, n1);
			Array.Copy(arr, mid + 1, R, 0, n2);

			// Merge the temporary arrays back into the original array

			int i = 0; // Initial index of the first subarray
			int j = 0; // Initial index of the second subarray
			int k = left; // Initial index of the merged subarray

			while (i < n1 && j < n2)
			{
				if (L[i] <= R[j])
				{
					arr[k] = L[i];
					i++;
				}
				else
				{
					arr[k] = R[j];
					j++;
				}
				k++;
			}

			// Copy the remaining elements of L[], if any
			while (i < n1)
			{
				arr[k] = L[i];
				i++;
				k++;
			}

			// Copy the remaining elements of R[], if any
			while (j < n2)
			{
				arr[k] = R[j];
				j++;
				k++;
			}
		}

	}
}
