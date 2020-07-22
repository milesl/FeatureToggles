namespace FeatureToggles.Api.Tests.Models
{
    using FeatureToggles.Api.Models;
    using System;
    using Xunit;
    using Moq;
    using System.Collections.Generic;

    public class TenantOverrideTests
    {
        private readonly TenantOverride _testClass;

        public TenantOverrideTests()
        {
            _testClass = new TenantOverride();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new TenantOverride();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetTenantId()
        {
            var testValue = new Guid("0325b410-a6da-43ed-befd-c7029c6ce563");
            _testClass.TenantId = testValue;
            Assert.Equal(testValue, _testClass.TenantId);
        }

        [Fact]
        public void CanSetAndGetTenant()
        {
            var testValue = new Tenant { Id = new Guid("478f28ab-7168-43c4-a54a-4e0fcbe407b8"), Name = "TestValue1030700563", TenantOverrides = new Mock<ICollection<TenantOverride>>().Object };
            _testClass.Tenant = testValue;
            Assert.Equal(testValue, _testClass.Tenant);
        }

        [Fact]
        public void CanSetAndGetFeatureId()
        {
            var testValue = new Guid("42888a7d-f497-49d1-be74-39edd8fc400f");
            _testClass.FeatureId = testValue;
            Assert.Equal(testValue, _testClass.FeatureId);
        }

        [Fact]
        public void CanSetAndGetFeature()
        {
            var testValue = new Feature { Id = new Guid("a1b45519-0aa9-4ad8-be56-983de7e1c5f0"), Name = "TestValue863111879", Enabled = false, ProductId = new Guid("7aff8c3b-4ab1-4cfc-b477-dc9e1eb1214b"), Product = new Product { Id = new Guid("9f1bcd49-4283-4b25-80c0-2f9d8fab4292"), Name = "TestValue1582367612", Features = new Mock<ICollection<Feature>>().Object }, TenantOverrides = new Mock<ICollection<TenantOverride>>().Object };
            _testClass.Feature = testValue;
            Assert.Equal(testValue, _testClass.Feature);
        }

        [Fact]
        public void CanSetAndGetEnabled()
        {
            var testValue = true;
            _testClass.Enabled = testValue;
            Assert.Equal(testValue, _testClass.Enabled);
        }
    }
}