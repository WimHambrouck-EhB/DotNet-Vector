using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VectorLib;
using Xunit;

namespace VectorLibTest
{
    public class VectorTests
    {
        [Fact]
        public void IsGeneric()
        {
            // Arrange
            Vector<int> vector = new Vector<int>();

            // Assert
            Assert.Equal(typeof(int), vector.GetType().GetGenericArguments()[0]);
        }

        [Fact]
        public void ConstructionWithCollectionInitialiser()
        {
            //Arrange
            var intVector = new Vector<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IList<int> iList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < iList.Count; i++)
            {
                // Assert
                Assert.Equal(intVector.GetItem(i), iList[i]);
            }
        }

        [Fact]
        public void ConstructionWithCtorSetsCapacity()
        {
            // Arrange
            var intVector = new Vector<int>(10);

            FieldInfo[] fields = intVector.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            object value = fields.FirstOrDefault(field => field.FieldType == typeof(int[])).GetValue(intVector);


            Assert.NotNull(value);
            Assert.IsType<int[]>(value);

            int[] elems = value as int[];

            Assert.Equal(10, elems.Length);
        }

        [Fact]
        public void ConstructionWithDefaultCtorSetsCapacity()
        {
            // Arrange
            var intVector = new Vector<int>();

            // Act
            int[] elems = intVector.GetType()
                .GetField("items", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(intVector) as int[];

            // Assert
            Assert.Single(elems);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4})]
        public void PushBack_Adds_Item(int[] items)
        {
            var intVector = new Vector<int>();

            foreach (int item in items)
            {
                intVector.PushBack(item);
            }

            for (int i = 0; i < items.Length; i++)
            {
                Assert.Equal(items[i], intVector.GetItem(i));
            }
        }
    }
}
