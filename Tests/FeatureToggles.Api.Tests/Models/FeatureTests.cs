namespace FeatureToggles.Api.Tests.Models
{
    using FeatureToggles.Api.Models;
    using System;
    using Xunit;
    using Moq;
    using System.Collections.Generic;

    public class FeatureTests
    {
        private readonly Feature _testClass;

        public FeatureTests()
        {
            _testClass = new Feature();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new Feature();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            var testValue = new Guid("fb88c738-2641-4918-ac6b-1f0e00ac8382");
            _testClass.Id = testValue;
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            var testValue = "TestValue1937786654";
            _testClass.Name = testValue;
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetEnabled()
        {
            var testValue = true;
            _testClass.Enabled = testValue;
            Assert.Equal(testValue, _testClass.Enabled);
        }

        [Fact]
        public void CanSetAndGetProductId()
        {
            var testValue = new Guid("59d36b14-686e-40e1-9c51-b6fd985add0a");
            _testClass.ProductId = testValue;
            Assert.Equal(testValue, _testClass.ProductId);
        }

        [Fact]
        public void CanSetAndGetProduct()
        {
            var testValue = new Product { Id = new Guid("1f2ba231-60b8-49d4-b0b2-829402865c9d"), Name = "TestValue1269580043", Features = new Mock<ICollection<Feature>>().Object };
            _testClass.Product = testValue;
            Assert.Equal(testValue, _testClass.Product);
        }

        [Fact]
        public void CanSetAndGetTenantOverrides()
        {
            var testValue = new Mock<List<TenantOverride>>().Object;
            _testClass.TenantOverrides = testValue;
            Assert.Equal(testValue, _testClass.TenantOverrides);
        }
    }
}