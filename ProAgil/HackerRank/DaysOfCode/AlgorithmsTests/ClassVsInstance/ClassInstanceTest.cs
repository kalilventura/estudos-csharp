using DaysOfCode.ClassVsInstance;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlgorithmsTests.ClassVsInstance
{
    public class ClassInstanceTest
    {
        [Fact]
        public void Case01()
        {
            var person = new Person(-1);
            Assert.Equal(0, person.age);
        }

        [Fact]
        public void Case02()
        {
            var person = new Person(1);
            Assert.Equal(1, person.age);
        }

        [Fact]
        public void Case03()
        {
            var person = new Person(0);
            person.yearPasses();
            Assert.Equal(1, person.age);
        }
    }
}
