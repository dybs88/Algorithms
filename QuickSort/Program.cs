using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickSort
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Quick sort \n");

			var notSortedArray = new List<int>();

			for (var i = 0; i < 25; i++)
			{
				Random r = new Random();
				notSortedArray.Add(r.Next(0, 100));
			}

			Console.WriteLine("Not sorted");
			notSortedArray.ForEach(x => Console.Write($"{x}, "));
			Console.WriteLine("\n");

			var sortedArray = QuickSort(notSortedArray);

			Console.WriteLine("Sorted");
			sortedArray.ForEach(x => Console.Write($"{x}, "));
			Console.ReadLine();
		}

		private static List<int> QuickSort(List<int> arrayToSort)
		{
			if (arrayToSort.Count <= 1)
				return arrayToSort;

			var pivot = ChoosePivotValue(arrayToSort);

			var smallerThanPivot = arrayToSort.Where(x => x < pivot).ToList();
			var eqPivot = arrayToSort.Where(x => x == pivot).ToList();
			var higherThanPivot = arrayToSort.Where(x => x > pivot).ToList();

			var result = new List<int>();
			result.AddRange(QuickSort(smallerThanPivot));
			result.AddRange(eqPivot);
			result.AddRange(QuickSort(higherThanPivot));

			return result;
		}

		private static int ChoosePivotValue(List<int> arrayWithPivot)
		{
			if (arrayWithPivot.Count < 3)
				return arrayWithPivot[0];

			var distinctedArray = arrayWithPivot.Distinct().ToList();

			var list = new List<int>
				{
					distinctedArray[0],
					distinctedArray[(int)Math.Round((decimal)distinctedArray.Count / 2)],
					distinctedArray[distinctedArray.Count - 1]
				};

			list.Sort();

			return list[1];
		}
	}
}
