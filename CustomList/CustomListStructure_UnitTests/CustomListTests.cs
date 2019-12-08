using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListStructure;

namespace CustomListStructure_UnitTests
{
    [TestClass]
    public class CustomListTests
    {
        #region AddMethod TestMethods
        [TestMethod]
        public void addValue_array_CountReflectsTrueSize()
        {
            //Arrange
            CustomList<int> testList1 = new CustomList<int>();
            int value1 = 5;
            int actual;
            int expected = 1; //expected size of list after addition

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
        #endregion

        #region RemoveMethod TestMethods
        [TestMethod]
        public void remove_sizeReflectsCorrectlyAfterRemove()
        {
            //arrange
            CustomList<int> list = new CustomList<int>();
            int val = 1;
            list.Add(0);
            list.Add(val);
            list.Add(2);
            list.Add(3);
            int expected = 3;

            //act
            list.Remove(val);
            int actual = list.Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void remove_IndexesRetainOrderAfterRemovalFirstPosition()
        {
            //arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            int expected = 2;
            //act
            list.Remove(1);
            int actual = list[0];
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void remove_IndexesRetainOrderAfterRemovalSecondPosition()
        {
            //arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            int expected = 2;
            //act
            list.Remove(4);
            int actual = list[1];
            //Assert
            Assert.AreEqual(expected, actual);
        }
        //By validating the first and second element retain position I am more thoroughly
        //validating order is correct in array size        
        [TestMethod]
        public void remove_LastItemIsItemREmovedFromArray()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            int expected = 5;

            //Act
            list.Add(5);
            list.Add(3);
            list.Remove(5);
            int actual = list.LastItemRemoved;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //removing if item is not present 
        [TestMethod]
        public void remove_ItemRemovedIsNotPresentInArray()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            int expected = 7;

            //Act
            list.Add(11);
            list.Add(12);
            list.Add(7);
            list.Remove(5);
            int actual = list[2];

            //Assert
            Assert.AreEqual(expected, actual);

        }
        //second test - prove that when something removed from list isnt present, count doesnt decrement

        [TestMethod]
        public void remove_CountStaysSameIfNothingRemoved()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            int expected = 2;

            //Act
            list.Add(10);
            list.Add(5);
            list.Remove(7);
            int actual = list.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region ToStringMethod TestMethods
        [TestMethod]
        public void ToString_ArrayActuallyReturned()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            string expected = "4, 8";
            list.Add(4);
            list.Add(8);

            //Act
            string actual = list.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ToString_ElementPrintedMatchesElementInArray()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(2);
            list.Add(4);
            list.Add(8);
            list.Add(8);
            list.Add(8);
            string expected = "2, 4, 8, 8, 8";

            //Act - note: have fun overriding this twice to be able to ToString a single variable
            string actual = list.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ToString_EmptyArrayReturnsEmptyString()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            string expected = "";
            //Act
            string actual = list.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region OverloadPlus TestMethods
        [TestMethod]
        public void OverloadPlus_CheckIfCorrectConcatenation()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            CustomList<int> listTwo = new CustomList<int>();
            CustomList<int> list3 = new CustomList<int>();
            string expected = "1, 2";

            //Act
            list.Add(1);
            listTwo.Add(2);
            list3 = (list + listTwo);
            string actual = list3.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OverloadPlus_CheckCorrectOutputIfOneListIsBlank()
        {
            //Arrange
            CustomList<int> lA = new CustomList<int>();
            CustomList<int> lB = new CustomList<int>();
            CustomList<int> lC = new CustomList<int>();
            lA.Add(1);
            lA.Add(2);
            lA.Add(3);
            string expected = "1, 2, 3";

            //Act
            lC = lA + lB;
            string actual = lC.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OverloadPlus_CheckCorrectOutputIfBothListsAreBlank()
        {
            //Arrange
            CustomList<int> lA = new CustomList<int>();
            CustomList<int> lB = new CustomList<int>();
            CustomList<int> lC = new CustomList<int>();
            string expected = "";

            //Act
            lC = lA + lB;
            string actual = lC.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }


}
