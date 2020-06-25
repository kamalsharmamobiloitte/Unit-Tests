
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTestLib
{
    public class TestCases
    {
        [Fact]
        public void Task_Add_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 6;

            // Act  
            var sum = MathOperation.Add(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, sum);
        }

        [Fact]
        public void Task_Subtract_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = -0.2;

            // Act  
            var sub = Math.Round(MathOperation.Subtract(num1, num2),2);

            //Assert  
            Assert.Equal(expectedValue, sub);
        }

        [Fact]
        public void Task_Multiply_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 8.99;

            // Act  
            var mult = MathOperation.Multiply(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, mult);
        }

        [Theory]
        [InlineData(5, 2, 3)]
        //[InlineData(-4, -6, -10)]
        //[InlineData(-2, 2, 0)]
        //[InlineData(int.MinValue, -1, int.MaxValue)]
        public void CanSubtractTheory(int value1, int value2, int expected)
        {
          

            var result = MathOperation.Subtract(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void CanAddTheory(int value1, int value2, int expected)
        {
            var result = MathOperation.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        [MemberData(nameof(GetData),parameters:2)]
        [MemberData(nameof(Data),MemberType = typeof(TestData))]
        public void CanAddTheoryMemberDataProperty(int value1, int value2, int expected)
        {
             

            var result = MathOperation.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
            };

        public static IEnumerable<object[]> GetData(int numTests)
        {
            var allData = new List<object[]>
        {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
        };

            return allData.Take(numTests);
        }


        [Fact]
        public void Task_Divide_TwoNumber()
        {
            // Arrange  
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 0.94; //Rounded value  

            // Act  
            var div =  Math.Round(MathOperation.Divide(num1, num2),2);

            //Assert  
            Assert.Equal(expectedValue, div);
        }

        private class TestData : System.Collections.Generic.IEnumerable<object[]>
        {
            public static IEnumerable<object[]> Data =>
           new List<object[]>
           {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
           };

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 1,2,3};
                yield return new object[] { 1, 2, 5 };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
