
namespace Vojta
{
    public class Sorter
    {
        public void BubbleSort(int[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
                for (var j = 0; j < numbers.Length - 1; j++)
                    if (numbers[j] > numbers[j + 1])
                    {
                        var storage = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = storage;
                    }
        }

        public void QuickSort(int[] numbers)
        {
            QuickSort(numbers, 0, numbers.Length);
        }

        void QuickSort(int[] numbers, int start, int end)
        {
            if (start == end) return;
            var middle = Partition(numbers, start, end);
            QuickSort(numbers, start, middle);
            QuickSort(numbers, middle + 1, end);
        }

        int Partition(int[] numbers, int start, int end)
        {
            var pivot = numbers[start];
            var l = start + 1;
            var r = end - 1;
            while (true)
            {
                while (l <= r && numbers[l] < pivot)
                    l++;
                while (numbers[r] > pivot && r >= l)
                    r--;
                if (l > r)
                    break;
                else
                    Swap(numbers, l, r);
            }
            Swap(numbers, start, r);
            return r;
        }

        void Swap(int[] numbers, int l, int r)
        {
            var storage = numbers[r];
            numbers[r] = numbers[l];
            numbers[l] = storage;
        }
    }
}
