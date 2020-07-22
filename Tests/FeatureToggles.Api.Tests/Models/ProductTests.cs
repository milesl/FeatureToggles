namespace FeatureToggles.Api.Tests.Models
{
    using FeatureToggles.Api.Models;
    using System;
    using Xunit;
    using Moq;
    using System.Collections.Generic;

    public class ProductTests
    {
        private readonly Product _testClass;

        public ProductTests()
        {
            _testClass = new Product();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new Product();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            var testValue = new Guid("4031558b-3e6d-4f68-b0d4-3ad3140b0586");
            _testClass.Id = testValue;
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            var testValue = "TestValue543455476";
            _testClass.Name = testValue;
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetFeatures()
        {
            var testValue = new Mock<List<Feature>>().Object;
            _testClass.Features = testValue;
            Assert.Equal(testValue, _testClass.Features);
        }
    }
}