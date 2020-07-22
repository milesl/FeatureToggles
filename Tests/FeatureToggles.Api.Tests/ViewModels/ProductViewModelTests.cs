namespace FeatureToggles.Api.Tests.ViewModels
{
    using FeatureToggles.Api.ViewModels;
    using System;
    using Xunit;
    using Moq;
    using System.Collections.Generic;

    public class ProductViewModelTests
    {
        private readonly ProductViewModel _testClass;

        public ProductViewModelTests()
        {
            _testClass = new ProductViewModel();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new ProductViewModel();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            var testValue = new Guid("6ef8202a-1a92-4d6d-a696-9c90873091d0");
            _testClass.Id = testValue;
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            var testValue = "TestValue1280557699";
            _testClass.Name = testValue;
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetFeatures()
        {
            var testValue = new Mock<List<FeatureViewModel>>().Object;
            _testClass.Features = testValue;
            Assert.Equal(testValue, _testClass.Features);
        }
    }
}