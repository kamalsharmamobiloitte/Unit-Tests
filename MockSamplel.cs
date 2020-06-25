using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestLib
{
    public class MockSamplel
    {

        [Fact]
        public void Test1()
        {
            var mock = new Mock<IFoo>();


            #region Property
            mock.Setup(x => x.Name).Returns("foo");
            mock.SetupProperty(f => f.Name, "foo");
            #endregion




            #region Methods
            mock.Setup(x => x.DoSomething("foo")).Returns(true);
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>())).Returns((string s) => s.ToLower());
            mock.Setup(x => x.DoSomething(It.IsAny<int>(),It.IsAny<string>())).Returns((int x, string s) => (x==1 && s=="foo"));
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);
            mock.Setup(foo => foo.DoSomething("error")).Throws<OutOfMemoryException>();
            mock.Setup(foo => foo.Add(It.IsInRange<int>(0, 10, Moq.Range.Inclusive))).Returns(true);
            #endregion


            #region Events


            #endregion

            IFoo foo = mock.Object;
            Assert.Equal("foo", foo.Name);
            Assert.True(foo.DoSomething("foo"));
            Assert.True(foo.DoSomething(1,"foo"));
            string s = "8";
            Assert.True(foo.TryParse("ping", out s));
            Assert.True(s== "ack");
            Assert.True(foo.DoSomething("error"));
            Assert.Equal("foo", foo.DoSomethingStringy("FOO"));
        }



    }
}
