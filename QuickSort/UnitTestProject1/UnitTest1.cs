using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickSortConsole;

namespace UnitTestProject1
{
    [TestClass]
    public class QuickSortTest
    {
        [TestMethod]
        public void TestSort3Elements()
        {
            var array = new int[] { 3, 2, 1 };
            Program.QuickSort(array);

            Assert.IsTrue(array[1] > array[0]);
            Assert.IsTrue(array[2] > array[1]);
        }

        [TestMethod]
        public void TestSort100Elements()
        {
            var array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = 88;
            }

            Program.QuickSort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                Assert.AreEqual(array[i], 88);
            }
        }

        [TestMethod]
        public void TestSort1000Elements()
        {
            var array = Program.GenerateArray(1000);
            bool b = false;

            Program.QuickSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= array[i])
                {
                    b = true;
                }
                Assert.AreEqual(b, true);
                b = false;
            }
        }

        [TestMethod]
        public void TestSortТullElements()
        {
            var array = new int[0];
            bool b = false;

            Program.QuickSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= array[i])
                {
                    b = true;
                }
                Assert.AreEqual(b, true);
                b = false;
            }
        }
    }
}