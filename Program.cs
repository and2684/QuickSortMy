namespace QuickSortMy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 11, 96, 14, 75, 222, 1, 14, 223, 25, 45, 6, 20 };

            var sortedArray = QuickSortMy(array, 0, array.Length - 1);

            Console.WriteLine($"Sorted array: {String.Join(", ", sortedArray)}");

            var sortedByLinqArray = QuickSortMyLinq(array);
            Console.WriteLine($"Sorted by Linq array: {String.Join(", ", sortedByLinqArray)}");
            Console.ReadKey();
        }

        private static int[] QuickSortMy(int[] array, int min, int max)
        {
            if (min >= max)
            {
                return array;
            }

            var pivot = GetPivot(array, min, max);

            QuickSortMy(array, min, pivot - 1);
            QuickSortMy(array, pivot + 1, max);

            return array;
        }

        private static void Swap(ref int item1, ref int item2)
        {
            int t = item1;
            item1 = item2;
            item2 = t;
        }

        private static int GetPivot(int[] array, int min, int max)
        {
            var pivot = min - 1;
            for (var i = min; i <= max; i++)
            {
                if (array[i] < array[max])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[max]);
            return pivot;
        }

        private static int[] QuickSortMyLinq(int[] array)
        {
            if (!array.Any()) return new int[] { };

            var pivot = array.First();

            var leftSide = array.Skip(1).Where(x => x < pivot).ToArray();
            QuickSortMyLinq(leftSide);
            var rightSide = array.Skip(1).Where(x => x >= pivot).ToArray();
            QuickSortMyLinq(rightSide);

            return array;
        }
    }
}