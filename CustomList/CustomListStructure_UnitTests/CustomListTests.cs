using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListStructure;

namespace CustomListStructure_UnitTests
{
    [TestClass]
    public class CustomListTests
    {
        [TestMethod]
        public void addValue_array_CountReflectsTrueSize()
        {
            //Arrange
            CustomList<int> testList1 = new CustomList<int>();
            int value1 = 5;
            int actual;
            int expected = 1;

            //Act
            testList1.Add(value1);
            actual = testList1.Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void add_ToArray_LargerThanFourStillAddsToArray()
        {
            //Arrange
            CustomList<int> testList1 = new CustomList<int>();
            int value1 = 5;
            int actual;
            int expected = 7;

            //Act
            testList1.Add(value1);
            testList1.Add(value1);
            testList1.Add(value1);
            testList1.Add(value1);
            testList1.Add(value1);
            testList1.Add(value1);
            testList1.Add(value1);
            actual = testList1.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void add_array_retainOrderOfIndexOne()
        {
            //this test ensures indices are in proper order
            //Arrange
            CustomList<int> testList1 = new CustomList<int>();
            int actualOne;
            int expectedIndexOne = 2;
            //Act
            testList1.Add(1);
            testList1.Add(2);
            testList1.Add(3);

            actualOne = testList1[1];
            //Assert
            Assert.AreEqual(expectedIndexOne, actualOne);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //test to see if a string is added instead of an integer 
        public void add_array_largerSizeThrownException()
        {
            //arrange
            CustomList<int> testList = new CustomList<int>();
            testList.Add(1);
            int expected = 1;

            //act
            testList[7] = expected;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void add_array_ValueOutsideOfRangeEntered()
        {
            // arrange
            CustomList<int> testList = new CustomList<int>();
            int outOfRange = 1; //arbitrary value. Point is that we cant have out of range index at -2
            // act
            testList[-2] = outOfRange;
        }


    }


}
