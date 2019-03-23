using Xunit;
using Vojta;

namespace VojtaTest
{
    public class SortTest
    {
        [Fact]
        public void BubbleSortWorks()
        {
            var sorter = new Sorter();
            var numbers = new int[] { 6, 3, 2 };
            sorter.BubbleSort(numbers);
            Assert.Equal(new[] { 2, 3, 6 }, numbers);
        }

        [Fact]
        public void QuickSortWorks()
        {
            var sorter = new Sorter();
            var numbers = new int[] { 6, 3, 2 };
            sorter.QuickSort(numbers);
            Assert.Equal(new[] { 2, 3, 6 }, numbers);
        }
    }
}
